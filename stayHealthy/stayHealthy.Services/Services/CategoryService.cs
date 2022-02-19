using AutoMapper;
using stayHealthy.DataAccess.Interfaces;
using stayHealthy.Services.Interfaces;
using stayHealthy.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;
        private IMapper mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;

        }

        public async Task<IEnumerable<DietCategory>> GetAllAsync()
        {
            var dbEntities = await categoryRepository.GetAllAsync();
            return mapper.Map<IEnumerable<DietCategory>>(dbEntities);
        }
    }
}
