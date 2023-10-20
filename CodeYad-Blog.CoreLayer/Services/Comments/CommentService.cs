using CodeYad_Blog.CoreLayer.DTOs.Comments;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using CodeYad_Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeYad_Blog.CoreLayer.Services.Comments
{
    public class CommentService : ICommentService
    {
        private readonly BlogContext _context;

        public CommentService(BlogContext context)
        {
            _context = context;
        }
        public OperationResult CreateComment(CreateCommentDto command)
        {
            var Comment = new PostComment()
            {
                PostId = command.PostId,
                Text = command.Text,
                UserId = command.UserId
            };
            _context.Add(command);
            _context.SaveChanges();
            return OperationResult.Success();
        }

       public List<CommentDto> GetPostComments(int postId)
        {
            return _context.postComments.Include(c => c.User).Where(c => c.PostId == postId)
               .Select(comment => new CommentDto()
               {
                   PostId = comment.PostId,
                   Text = comment.Text,
                   UserFullName = comment.User.FullName,
                   CommentId = comment.Id,
                   CreationDate= comment.CreationDate,
               }).ToList();
        }
    }
}
