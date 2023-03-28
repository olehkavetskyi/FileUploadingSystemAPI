namespace FileUploadingSystemAPI.Validators;

public static class FileValidator
{
    public static bool FileExists(this IFormFile file) => file != null && file.Length > 0;
    

    public static bool IsDocxFile(this IFormFile file)
    {
        if (!FileExists(file))
            return false;

        return Path.GetExtension(file.FileName) == ".docx";
    }
}
