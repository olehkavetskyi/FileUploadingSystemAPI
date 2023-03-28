namespace FileUploadingSystemAPI.Entities;

public class RequestData
{
    public IFormFile File { get; set; } = null!;
    public string Email { get; set; } = null!;
}
