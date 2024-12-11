using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public class CategoryMapper
    {
        //From CategoryReq to Category
        public Category ToCategory(CategoryReq categoryReq)
        {
            return new Category
            {
                Name = categoryReq.Name,
                Description = categoryReq.Description
            };
        }

        //From Category to CategoryRes
        public CategoryRes ToResponse(Category category)
        {
            return new CategoryRes
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}
