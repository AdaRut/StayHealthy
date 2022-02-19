using AutoMapper;
using stayHealthy.DataAccess.Entities;
using stayHealthy.DataAccess.Interfaces;
using stayHealthy.Services.Exceptions;
using stayHealthy.Services.Interfaces;
using stayHealthy.Services.Interfaces.Utils;
using stayHealthy.Services.Models.Diet;
using stayHealthy.Services.Models.Meal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stayHealthy.Services.Services
{
    public class DietService : IDietService
    {
        private IDietRepository dietRepository;
        private IMealRepository mealRepository;
        private IMapper mapper;
        private IAuthProvider authProvider;
        public DietService(
             IDietRepository dietRepository,
             IMealRepository mealRepository,
             IMapper mapper,
             IAuthProvider authProvider)
        {
            this.dietRepository = dietRepository;
            this.mealRepository = mealRepository;
            this.mapper = mapper;
            this.authProvider = authProvider;
        }
        public async Task<DietDetailDto> CreateDietAsync(DietCreateDto value, int userId)
        {
            var mealsEntities = new List<MealEntity>();
            foreach(var meal in value.Meals)
            {
                mealsEntities.Add(new MealEntity
                {
                    Name = meal.Name,
                    Calories = meal.Calories,
                    CreationDate = DateTime.Now,
                    CreatedById = userId,
                    IsDeleted = false
                });
            }

            var dietEntity = new DietEntity
            {
                Name = value.Name,
                MaxCalories = value.MaxCalories,
                DietCategoryId = value.DietCategoryId,
                Meals = mealsEntities,
                CreationDate = DateTime.Now,
                CreatedById = userId,
                IsDeleted = false
            };

            dietRepository.Add(dietEntity);
            await dietRepository.SaveChangesAsync();
            return await GetDietByIdAsync(dietEntity.Id);

        }

        public async Task<DietDetailDto> DeleteDietAsync(int id, int userId)
        {
            var dietEntity = await dietRepository.GetDietByIdAsync(id);
            if(dietEntity.CreatedById != userId)
            {
                throw new Exception();
            }
            dietEntity.IsDeleted = true;
            dietEntity.ModificationDate = DateTime.Now;
            dietEntity.ModifiedById = userId;
            var mealsEntities = await mealRepository.GetAllDietMealsAsync(dietEntity.Id);
            foreach(var mealEntity in mealsEntities)
            {
                mealEntity.IsDeleted = true;
                mealEntity.ModificationDate = DateTime.Now;
                mealEntity.ModifiedById = userId;
            }

            dietRepository.Update(dietEntity);
            mealRepository.UpdateRange(mealsEntities);
            await dietRepository.SaveChangesAsync();
            await mealRepository.SaveChangesAsync();
            return await GetDietByIdAsync(dietEntity.Id);
        }

        public async Task<IEnumerable<DietListItemDto>> GetAllDietsAsync()
        {
            var dbEntities = await dietRepository.GetAllAsync();
            return mapper.Map<IEnumerable<DietListItemDto>>(dbEntities);
        }

        public async Task<IEnumerable<DietListItemDto>> GetAllUserDietsAsync(int userId)
        {
            var dbEntities = await dietRepository.GetAllUserDietAsync(userId);
            return mapper.Map<IEnumerable<DietListItemDto>>(dbEntities);
        }

        public async Task<DietDetailDto> GetDietByIdAsync(int id)
        {
            var dbEntity = await dietRepository.GetDietByIdAsync(id);
            dbEntity.Meals = await mealRepository.GetAllDietMealsAsync(id);
            return mapper.Map<DietDetailDto>(dbEntity);
        }

        public async Task<DietDetailDto> UpdateDietAsync(DietUpdateDto value, int userId)
        {
            var dietEntity = await dietRepository.GetDietByIdAsync(value.Id);
            if (dietEntity.CreatedById != userId)
            {
                throw new Exception();
            }
            if(IsDietChanged(dietEntity, value))
            {
                dietEntity.Name = value.Name;
                dietEntity.MaxCalories = value.MaxCalories;
                dietEntity.DietCategoryId = value.DietCategoryId;
                dietEntity.ModificationDate = DateTime.Now;
                dietEntity.ModifiedById = userId;
            }

            var mealsEntities = await mealRepository.GetAllDietMealsAsync(value.Id);
            var mealsEntitiesToAdd = new List<MealEntity>();
            var mealsEntitiesToUpdate = new List<MealEntity>();
            
            foreach(var meal in value.Meals)
            {
                if (meal.Id == null)
                {
                    mealsEntitiesToAdd.Add(new MealEntity
                    {
                        Name = meal.Name,
                        Calories = meal.Calories,
                        DietId = dietEntity.Id,
                        CreatedById = userId,
                        CreationDate = DateTime.Now,
                        IsDeleted = false
                    });
                } else
                {
                    var mealEntity = mealsEntities.FirstOrDefault(x => x.Id == meal.Id);
                    if(mealEntity != null && IsMealChanged(mealEntity, meal))
                    {
                        mealEntity.Name = meal.Name;
                        mealEntity.Calories = meal.Calories;
                        mealEntity.ModificationDate = DateTime.Now;
                        mealEntity.ModifiedById = userId;

                        mealsEntitiesToUpdate.Add(mealEntity);
                    }
                }
            }

            var modifiedMealsIds = value.Meals.Select(x => x.Id);
            var mealsEntitesToDelete = mealsEntities.Where(x => !modifiedMealsIds.Contains(x.Id)).ToList();

            foreach(var mealEntity in mealsEntitesToDelete)
            {
                mealEntity.IsDeleted = true;
                mealEntity.ModificationDate = DateTime.Now;
                mealEntity.ModifiedById = userId;
            }

            dietRepository.Update(dietEntity);
            mealRepository.AddRange(mealsEntitiesToAdd);
            mealRepository.UpdateRange(mealsEntitiesToUpdate);
            mealRepository.UpdateRange(mealsEntitesToDelete);
            await dietRepository.SaveChangesAsync();
            await mealRepository.SaveChangesAsync();
            return await GetDietByIdAsync(dietEntity.Id);

        }

        private bool IsDietChanged(DietEntity dietEntity, DietUpdateDto dietUpdate)
        {
            return (dietEntity.Name != dietUpdate.Name ||
                dietEntity.MaxCalories != dietUpdate.MaxCalories ||
                dietEntity.DietCategoryId != dietUpdate.DietCategoryId);
        }

        private bool IsMealChanged(MealEntity mealEntity, MealUpdateDto mealUpdate)
        {
            return (mealEntity.Name != mealUpdate.Name ||
                mealEntity.Calories != mealUpdate.Calories);
        }
    }
}
