using AutoMapper;
using stayHealthy.DataAccess.Entities;
using stayHealthy.Services.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Mapper
{
    public class DietCategoryProfile : Profile
    {
        public DietCategoryProfile()
        {
            CreateMap<DietCategoryEntity, DietCategory>()
                .ForMember(dest => dest.CreatedByData, opt => opt.MapFrom(src => src.CreatedBy.FirstName + " " + src.CreatedBy.LastName));
        }
    }
}
