using CodeYad_Blog.CoreLayer.DTOs.Comments;
using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Services.Comments;
using CodeYad_Blog.CoreLayer.Services.Posts;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.WEB.Pages
{
    [ValidateAntiForgeryToken]
    public class testpostModel : PageModel
    {
         private readonly IPostService _postService;

        public testpostModel(IPostService postService)
        {
            _postService = postService;
        }
        public string slug;
        public PostDto Post { get; set; }
       
        public IActionResult OnGet(string slug)
        {
            Post = _postService.GetPostBySlug(slug);
            if (Post == null)
                return NotFound();
            return Page(); 
        }
    }
}

