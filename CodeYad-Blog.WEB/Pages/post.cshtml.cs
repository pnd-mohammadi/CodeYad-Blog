using CodeYad_Blog.CoreLayer.DTOs.Comments;
using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Services.Posts;
using CodeYad_Blog.CoreLayer.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.WEB.Pages
{
    [ValidateAntiForgeryToken]
    public class postModel : PageModel
    {
        private readonly IPostService _postService;
        
        public postModel (IPostService postService)
        {
            _postService = postService;
           
        }
  
        public PostDto Post { get; set; }

        [Required]
        [BindProperty]
        public string Text { get; set; }
        [BindProperty]
        public int PostId { get; set; }

        
        public List<PostDto> RelatedPosts { get; set; }
        public IActionResult OnGet(string slug)
        {
            Post = _postService.GetPostBySlug(slug);
            if (Post == null)
                return NotFound();

           
            return Page();
        }

      
    }
}
