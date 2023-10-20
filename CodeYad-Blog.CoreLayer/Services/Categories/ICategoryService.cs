﻿using CodeYad_Blog.CoreLayer.DTOs.Categories;
using CodeYad_Blog.CoreLayer.Utilities;

namespace CodeYad_Blog.CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto command);
        OperationResult EditCategory(EditCategoryDto command);
        List<CategoryDto> GetAllCategory();
        CategoryDto GetCategoryBy(int id);
        CategoryDto GetCategoryBy(string slug);
        bool IsSlugExist(string Slug);
        List<CategoryDto> GetChildCategories(int parentId);

    }
}
