using CodeYad_Blog.CoreLayer.Services.FileManager;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CodeYad_Blog.WEB.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
        private readonly IFileManager _fileManager;

       public UploadController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }
        [Route("/Upload/Article")]
        public IActionResult UploadArticleImage(IFormFile upload)
        {    
            if (upload == null)
                BadRequest();
            var imageName = _fileManager.SaveFileAndReturnName(upload, Directories.PostContentImage);
            return  Json(new { Uplaoded = true, url = Directories.GetPostContentImage(imageName) });
        }
    }
}
