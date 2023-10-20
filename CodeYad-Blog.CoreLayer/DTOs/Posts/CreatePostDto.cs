﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeYad_Blog.CoreLayer.DTOs.Posts
{
    public  class CreatePostDto
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Title { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

    }
}
