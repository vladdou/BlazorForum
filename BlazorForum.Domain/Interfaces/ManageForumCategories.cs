﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlazorForum.Data;
using BlazorForum.Models;

namespace BlazorForum.Domain.Interfaces
{
    public interface IManageForumCategories
    {
        Task<List<ForumCategory>> GetForumCategoriesAsync();

        Task<List<ForumCategory>> GetForumCategoriesAsync(int forumId);
        Task<ForumCategory> GetForumCategoryAsync(int categoryId);
        Task<bool> CreateCategoryAsync(ForumCategory newCategory);
        Task<bool> UpdateCategoryAsync(ForumCategory editedCategory);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }

    public class ManageForumCategories : IManageForumCategories
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public ManageForumCategories(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<ForumCategory>> GetForumCategoriesAsync() => 
            await new Data.Repository.ForumCategories(_dbFactory).GetForumCategoriesAsync();

        public async Task<List<ForumCategory>> GetForumCategoriesAsync(int forumId) => 
            await new Data.Repository.ForumCategories(_dbFactory).GetForumCategoriesAsync(forumId);

        public async Task<ForumCategory> GetForumCategoryAsync(int categoryId) => 
            await new Data.Repository.ForumCategories(_dbFactory).GetForumCategory(categoryId);

        public async Task<bool> CreateCategoryAsync(ForumCategory newCategory) => 
            await new Data.Repository.ForumCategories(_dbFactory).CreateCategoryAsync(newCategory);

        public async Task<bool> UpdateCategoryAsync(ForumCategory editedCategory) =>
            await new Data.Repository.ForumCategories(_dbFactory).UpdateCategoryAsync(editedCategory);

        public async Task<bool> DeleteCategoryAsync(int categoryId) =>
            await new Data.Repository.ForumCategories(_dbFactory).DeleteCategoryAsync(categoryId);
    }
}
