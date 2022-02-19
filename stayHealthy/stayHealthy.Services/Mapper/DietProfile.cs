using AutoMapper;
using stayHealthy.DataAccess.Entities;
using stayHealthy.Services.Models.Diet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Mapper
{
    public class DietProfile : Profile 
    {
        public DietProfile()
        {
            CreateMap<DietEntity, DietDetailDto>()
                .ForMember(dest => dest.CreatedByData, opt => opt.MapFrom(src => src.CreatedBy.FirstName + " " + src.CreatedBy.LastName))
                .ForMember(dest => dest.DietCategoryName, opt => opt.MapFrom(src => src.DietCategory.Name));

            CreateMap<DietEntity, DietListItemDto>()
                .ForMember(dest => dest.CreatedByData, opt => opt.MapFrom(src => src.CreatedBy.FirstName + " " + src.CreatedBy.LastName))
                .ForMember(dest => dest.DietCategoryName, opt => opt.MapFrom(src => src.DietCategory.Name));
        }
    }
}
