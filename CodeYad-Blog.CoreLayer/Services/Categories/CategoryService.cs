using System;
using System.Collections.Generic;
using System.Linq;
using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.CoreLayer.Mappers;
using CodeYad_Blog.CoreLayer.Utilities;
using CodeYad_Blog.DataLayer.Context;
using CodeYad_Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeYad_Blog.CoreLayer.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _context;
        public CategoryService(BlogContext context)
        {
            _context = context;
        }
        public OperationResult CreateCategory(CreateCategoryDto command)
        {
            if (IsSlugExist(command.Slug))
                return OperationResult.Error("Slug Is Exist");

            var category = new Category()
            {
                Title = command.Title,
                IsDelete = false,
                ParentId = command.ParentId,
                Slug = command.Slug.Toslug(),
                MetaTag = command.MetaTag,
                MetaDescription = command.MetaDescription
            };
            _context.categories.Add(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }
        public OperationResult EditCategory(EditCategoryDto command)
        {
            var category = _context.categories.FirstOrDefault(c => c.Id == command.Id);
            if (category == null)
                return OperationResult.NotFound();

            if (command.Slug.Toslug() != category.Slug)
                if (IsSlugExist(command.Slug))
                    return OperationResult.Error("SlugIsExist");

            category.MetaDescription = command.MetaDescription;
            category.Slug = command.Slug.Toslug();
            category.Title = command.Title;
            category.MetaTag = command.MetaTag;

            //_context.Update(category);
            _context.SaveChanges();
            return OperationResult.Success();
        }
        public List<CategoryDto> GetAllCategory()
        {
            return _context.categories.Select(category => CategoryMapper.Map(category)).ToList();
        }
        public CategoryDto GetCategoryBy(int id)
        {
            var category = _context.categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }

        public CategoryDto GetCategoryBy(string slug)
        {
            var category = _context.categories.FirstOrDefault(c => c.Slug == slug);
            if (category == null)
                return null;
            return CategoryMapper.Map(category);
        }

        public bool IsSlugExist(string Slug)
        {
            return _context.categories.Any(c => c.Slug == Slug.Toslug());
        }
        public List<CategoryDto> GetChildCategories(int parentId)
        {
            return _context.categories.Where(r => r.ParentId == parentId)
                    .Select(Category => CategoryMapper.Map(Category)).ToList();
        }
    }
}
