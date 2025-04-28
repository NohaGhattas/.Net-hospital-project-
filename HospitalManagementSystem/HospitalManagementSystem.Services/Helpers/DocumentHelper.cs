using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Services.Helpers
{
    public static class DocumentHelper
    {
        public static string UploadFile(IFormFile file, string folderName, string name)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\files", folderName);
            string fileName = $"{name}-.{file.FileName}";
            string filePath = Path.Combine(folderPath, fileName);
            using var fileStr = new FileStream(filePath, FileMode.Create);
            string fileSrc = Path.Combine(@"\files", folderName, fileName);
            file.CopyTo(fileStr);
            return fileSrc;
        }
    }
}
