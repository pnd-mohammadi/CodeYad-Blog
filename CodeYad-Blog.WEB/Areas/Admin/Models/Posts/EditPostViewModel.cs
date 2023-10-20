using System.ComponentModel.DataAnnotations;

namespace CodeYad_Blog.WEB.Areas.Admin.Models.Posts
{
    public class EditPostViewModel
    {
        [Display(Name = " دسته بندی")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید ")]
        public int CategoryId { get; set; }

        [Display(Name = "زیردسته بندی")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید ")]
        public int SubCategoryId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید ")]
        public string Title { get; set; }

        [Display(Name = "slug")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید ")]
        public string Slug { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید ")]
        [UIHint("ckeditor4")]
        public string Description { get; set; }
        [Display(Name = "عکس")]
       
        public IFormFile ImageFile { get; set; }
    }
}
