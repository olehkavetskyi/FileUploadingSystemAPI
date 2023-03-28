using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using SendGrid;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace EmailNotificationFunction;

[StorageAccount("BlobConnectionString")]
public class EmailNotificationFunction
{
    [FunctionName("EmailNotificationFunction12")]
    public static async Task Run([BlobTrigger("uploadedfiles/{name}")] BlobClient myBlob, string name, ILogger log)
    {
        try
        {
            BlobProperties properties =  myBlob.GetProperties();
   
            if (properties.Metadata.ContainsKey("email"))
            {
                var client = new SendGridClient(Environment.GetEnvironmentVariable("SendGridAPIKey"));
                var from = new EmailAddress("test0for0app@gmail.com", "Oleh Kavetskyi");
                var subject = "New file uploaded";
                var to = new EmailAddress(properties.Metadata["email"]);
                var plainTextContent = "File Uploading System";
                var htmlContent = "<strong>The file is successfully uploaded.</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                log.LogInformation("Everything is done");
            }
            else
            {
                log.LogError($"A file {name} doesn't have metadata");
            }
        }
        catch (Exception ex)
        {
            log.LogError($"Error sending email: {ex.Message}");
        }
    }
}
