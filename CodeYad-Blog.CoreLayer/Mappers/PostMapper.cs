using CodeYad_Blog.CoreLayer.DTOs.Posts;
using CodeYad_Blog.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto dto)
        {
            return new Post()
            {
            Description=dto.Description,
            CategoryId=dto.CategoryId,
            Slug=dto.Slug,
            Title=dto.Title,
            UserId=dto.UserId, 
            Visit=0,
            IsDelete=false,
            SubCategoryId=dto.SubCategoryId
            };

        }
        public static PostDto MapToDto(Post post)
        {
            return new PostDto()
            {
                Description = post.Description,
                CategoryId = post.CategoryId,
                Slug = post.Slug,
                Title = post.Title,
                UserFullName = post.User?.FullName,
                Visit = post.Visit,
                CreationDate=post.CreationDate,
                ImageName=post.ImageName,
                PostId=post.Id,
                Category = CategoryMapper.Map(post.Category),
                SubCategory=post.SubCategoryId == null ? null : CategoryMapper.Map(post.SubCategory)
            };

        }
        public static Post EditMapPost(EditPostDto editdto,Post post) 
        {
        post.Title=editdto.Title;
        post.Slug=editdto.Slug;
        post.CategoryId=editdto.CategoryId;
        post.SubCategoryId=editdto.SubCategoryId;
        post.Description=editdto.Description;
        return post;
        }
    }
}
