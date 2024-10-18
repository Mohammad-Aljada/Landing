namespace Landing.PL.Helper
{
    public class FileSettings
    {
        public static string UploadFile( IFormFile File , string folderName) { 
            var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files" , folderName);
            var fileName = $"{Guid.NewGuid()}{File.FileName}";
            var filepath = Path.Combine(folderpath, fileName);

            var filestream = new FileStream(filepath , FileMode.Create);
            File.CopyTo(filestream);
            filestream.Close();
            return fileName;

        }
        public static void DeleteFile(string filename , string folderName) {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName , filename);
            if (File.Exists(filepath)) {
                File.Delete(filepath);
            }

        }
    }
}
