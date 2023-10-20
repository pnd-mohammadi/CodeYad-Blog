using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Services.FileManager
{
    public interface IFileManager
    {
        string SaveImageAndReturnImageName(IFormFile file, string savePath);
        string SaveFileAndReturnName(IFormFile file, string SavePath);
        void DeleteFile(string fileName, string path);

    }
}
