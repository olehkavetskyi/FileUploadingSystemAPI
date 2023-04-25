# API

File uploading system was created to test my practical skills of C#, Microsoft Azure and front-end.
This app represents a form that takes user's email and a file with '.docx' extension. It sends to the server where API part saves to Azure Blob Storage the file. In case of success azure function is triggered and with SendGrid sends notification about success to the user.

## Installation
To install the API repository, follow these steps:

1. Clone the repository to your local machine using Git.

```bash
git clone https://github.com/olehkavetskyi/FileUploadingSystemAPI
```

2. Install the .NET 6 on your machine if it is not already installed.

3. Navigate to the root of the repository using the command prompt.

4. Run the command dotnet restore to install the dependencies.

## Usage
To use the API repository, follow these steps:

1. Create an Azure Blob storage account in the Azure portal.

2. Create an Azure Function App in the Azure portal.

3. Configure the Azure Function App to use the Blob storage account as a trigger.

4. Run the command dotnet run to start the Azure Function App.

5. Upload a .docx file to the Blob storage to trigger the Azure Function App and send an email notification.

## Deployment
To deploy the API repository to an Azure Function App, follow these steps:

1. Navigate to the Deployment Center of the Azure Function App and choose GitHub as the source.

2. Select the API repository and configure the deployment options.

3. Wait for the deployment to finish and test the Azure Function App by uploading a .docx file to the Blob storage.

## Links

In order to see UI part follow [this](https://github.com/olehkavetskyi/FileUploadingSystemUI) link

A link to Azure Web Application - https://fileuploadingsystem.azurewebsites.net (deactivated)
