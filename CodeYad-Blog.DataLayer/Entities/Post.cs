using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.DataLayer.Entities
{
    public class Post : BaseEntity
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Title { get; set; }
        [Required]
        [MaxLength(400)]
        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int Visit { get; set; }
        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("SubCategoryId")]
        public Category SubCategory { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
        #endregion
    }
}
//SqlException: The INSERT statement conflicted with the FOREIGN KEY constraint
//    "FK_posts_categories_SubCategoryId". The conflict occurred in database "test2",
//    table "dbo.categories", column 'Id'.

