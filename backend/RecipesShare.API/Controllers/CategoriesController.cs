﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipesShare.BLL.Abstractions.Services;
using RecipesShare.Contracts.Common;
using RecipesShare.Contracts.DTOs.Category;

namespace RecipesShare.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllCategoriesAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _categoryService.GetCategoryByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error message: " + ex.Message);
            }
        }
        [Authorize(Roles = StaticUserRoles.ADMIN)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryDTO createCategoryDTO)
        {
            var result = await _categoryService.AddCategoryAsync(createCategoryDTO);
            return Ok(result);
        }
        [Authorize(Roles = StaticUserRoles.ADMIN)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCategoryDTO updateCategoryDTO)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, updateCategoryDTO);
            return Ok(result);
        }
        [Authorize(Roles = StaticUserRoles.ADMIN)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            return Ok(result);
        }
    }
}
