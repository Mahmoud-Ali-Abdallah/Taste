using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taste.DataAccessLayer.Data.Repository.IRepository;
using Taste.Models;
using Taste.Models.DTO;
using Taste.Utility;

namespace Taste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = UserRoles.Admin)]
    public class FoodTypeController : ControllerBase
    {
        private readonly IUnitOfWork<IFoodTypeRepository> _unitOfWork;
        public FoodTypeController(IUnitOfWork<IFoodTypeRepository> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetFoodTypes")]
        public IEnumerable<FoodType> GetFoodTypes()
        {
            return _unitOfWork.Repository.GetAll();
        }

        [HttpGet]
        [Route("GetFoodTypeListForDropDown")]
        public IEnumerable<SelectListItemDTO> GetFoodTypeListForDropDown()
        {
            return _unitOfWork.Repository.GetFoodTypeListFromDropDown();
        }

        [HttpGet]
        [Route("GetFoodTypeById/{id:int}")]
        public FoodType GetCategoryById(int id)
        {
            return _unitOfWork.Repository.GetFirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("AddFoodType")]
        public bool AddCategory(FoodType newFoodType)
        {
            _unitOfWork.Repository.Add(newFoodType);

            return _unitOfWork.Save();
        }

        [HttpPut]
        [Route("UpdateFoodType/{id:int}")]
        public bool UpdateCategory(FoodType foodType)
        {
            _unitOfWork.Repository.Update(foodType);

            return _unitOfWork.Save();

        }

        [HttpDelete]
        [Route("DeleteFoodType/{id:int}")]
        public bool DeleteCategory(int id)
        {
            var obj = _unitOfWork.Repository.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
                return false;


            _unitOfWork.Repository.Remove(id);
            _unitOfWork.Save();

            return true;

        }
    }
}
