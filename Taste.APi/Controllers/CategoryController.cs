using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Taste.DataAccessLayer.Data.Repository.IRepository;
using Taste.Models;
using Taste.Models.DTO;
using Taste.Utility;

namespace Taste.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    //[Authorize(Roles = UserRoles.Admin)]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork<ICategoryRepository> _unitOfWork;
        public CategoryController(IUnitOfWork<ICategoryRepository> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Repository.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);
        }

        [HttpGet]
        [Route("GetCategoryListForDropDown")]
        public IEnumerable<SelectListItemDTO> GetCategoryListForDropDown()
        {
            return _unitOfWork.Repository.GetCategoryListFromDropDown();
        }

        [HttpGet]
        [Route("GetCategoryById/{id:int}")]
        public Category GetCategoryById(int id)
        {
            return _unitOfWork.Repository.GetFirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("AddCategory")]
        public bool AddCategory(Category newCategory)
        {
            _unitOfWork.Repository.Add(newCategory);

            return _unitOfWork.Save();
        }

        [HttpPut]
        [Route("UpdateCategory/{id:int}")]
        public bool UpdateCategory(Category newCategory)
        {
            _unitOfWork.Repository.Update(newCategory);

            return _unitOfWork.Save();

        }

        [HttpDelete]
        [Route("DeleteCategory/{id:int}")]
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
