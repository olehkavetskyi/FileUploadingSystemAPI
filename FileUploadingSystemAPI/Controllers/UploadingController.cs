using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FileUploadingSystemAPI.Entities;
using FileUploadingSystemAPI.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadingSystemAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UploadingController : ControllerBase
{ 
    private readonly IConfiguration _config;

    public UploadingController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost]
    public async Task<ActionResult> AddBlobMetadataAsync([FromForm] RequestData requestData)
    {
        try
        {
            if (!requestData.File.IsDocxFile() || !requestData.File.FileExists())
                return BadRequest("File is invalid");

            Dictionary<string, string> metadata = new();

            metadata["email"] = requestData.Email;

            var connectionString = _config.GetConnectionString("AzureBlobStorageString");

            var containerName = "uploadedfiles"; 

            var fileName = Guid.NewGuid().ToString() + ".docx";

            BlobClient blobClient = new BlobClient(connectionString, containerName, fileName);

            BlobUploadOptions options = new BlobUploadOptions
            {
                Metadata = new Dictionary<string, string>
                {
                    { "email", requestData.Email }
                }
            };

            await blobClient.UploadAsync(await GetStream(requestData.File), options);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    private async Task<Stream> GetStream( IFormFile formFile)
    {
        var memoryStream = new MemoryStream();
        
        await formFile.CopyToAsync(memoryStream);
        memoryStream.Seek(0, SeekOrigin.Begin);

        return memoryStream;
    }
}
