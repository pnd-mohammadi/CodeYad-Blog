using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.DataLayer.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public int? ParentId { get; set; }
        [InverseProperty("Category")]
        public ICollection<Post> Posts { get; set; }
        [InverseProperty("SubCategory")]
        public ICollection<Post> SubPosts { get; set; }
    }
}
//FOREIGN KEY constraint "FK_posts_categories_SubCategoryId".
// The conflict occurred in database "test2",table "dbo.categories", column 'Id'.
