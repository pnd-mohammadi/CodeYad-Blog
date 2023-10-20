using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeYad_Blog.WEB.Pages
{
    public class QueModel : PageModel
    {
        private readonly IPostService _postService;

        public QueModel(IPostService postService)
        {
            _postService = postService;
        }
        public  PostFilterDto Filter{get; set;}
        public void OnGet(int pageId, string categorySlug, string q)
        {
            Filter = _postService.GetPostsByFilter(new PostFilterParams()
            {
            Title=q,
            CategorySlug=categorySlug,
            PageId=pageId,
            Take=2
            });

        }
    }
}
