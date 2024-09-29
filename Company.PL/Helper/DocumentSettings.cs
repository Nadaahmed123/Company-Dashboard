using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Company.PL.Helper
{
    public class DocumentSettings
    {
        //Method will UPLoad file,
        //return string because it return path that will put it at Database
        public static string UploadFile(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is not valid");

            var uploadsFolder = Path.Combine("wwwroot", "uploads", folderName);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"/uploads/{folderName}/{fileName}";
        }

        public static void DeleteFile(string fileName, string folderName)
        {

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);

        }
    }
}