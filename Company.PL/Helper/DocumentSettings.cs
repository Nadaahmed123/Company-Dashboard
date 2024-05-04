using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Company.PL.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is null or empty.", nameof(file));
            }

            try
            {
                // Create folder if it doesn't exist
                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName);
                Directory.CreateDirectory(folderPath);

                // Generate unique file name
                string fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

                // Combine folder path and file name to get full file path
                string filePath = Path.Combine(folderPath, fileName);

                // Save file to disk
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return fileName;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw ex;
            }
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(folderName))
            {
                throw new ArgumentException("File name or folder name is null or empty.");
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static void UpdateFile(string existingFileName, string folderName, IFormFile newFile)
        {
            if (string.IsNullOrEmpty(existingFileName) || string.IsNullOrEmpty(folderName) || newFile == null)
            {
                throw new ArgumentException("Existing file name, folder name, or new file is null or empty.");
            }

            DeleteFile(existingFileName, folderName);
            UploadFile(newFile, folderName);
        }
        
    }
}
