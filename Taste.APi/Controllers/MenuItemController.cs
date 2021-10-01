using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using Taste.DataAccessLayer.Data.Repository.IRepository;
using Taste.Models;
using Taste.Utility;

namespace Taste.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    //[Authorize(Roles = UserRoles.Admin)]
    public class MenuItemController : ControllerBase
    {
        private readonly IUnitOfWork<IMenuItemRepository> _unitOfWork;

        private readonly IWebHostEnvironment _hostEnviornment;


        public MenuItemController(IUnitOfWork<IMenuItemRepository> unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnviornment = hostEnvironment;
        }

        [HttpGet]
        [Route("GetMenuItems")]
        public IEnumerable<MenuItem> GetMenuItems()
        {
            return _unitOfWork.Repository.GetAll(null, null, "Category,FoodType");
        }

        [HttpGet]
        [Route("GetMenuItemById/{id:int}")]
        public MenuItem GetMenuItemById(int id)
        {
            return _unitOfWork.Repository.GetFirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("AddMenuItem")]
        public bool AddMenuItem(MenuItem newMenuItem)
        {
            _unitOfWork.Repository.Add(newMenuItem);

            return _unitOfWork.Save();
        }

        [HttpPut]
        [Route("UpdateMenuItem/{id:int}")]
        public bool UpdateMenuItem(MenuItem MenuItem)
        {
            _unitOfWork.Repository.Update(MenuItem);

            return _unitOfWork.Save();

        }

        [HttpDelete]
        [Route("DeleteMenuItem/{id:int}")]
        public bool DeleteCategory(int id)
        {
            try
            {
                var objFromDb = _unitOfWork.Repository.GetFirstOrDefault(u => u.Id == id);
                if (objFromDb == null)
                    return false;

                var imgPath = Path.Combine(_hostEnviornment.WebRootPath, objFromDb.Image);
                if (System.IO.File.Exists(imgPath))
                {
                    System.IO.File.Delete(imgPath);
                }

                _unitOfWork.Repository.Remove(id);

                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                // Save error in log file
                // return error message to client 

                return false;
            }


        }
    }
}
