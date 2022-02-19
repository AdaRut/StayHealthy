using AutoMapper;
using stayHealthy.DataAccess.Entities;
using stayHealthy.Services.Models.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Mapper
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<MealEntity, MealDto>();
        }
    }
}
