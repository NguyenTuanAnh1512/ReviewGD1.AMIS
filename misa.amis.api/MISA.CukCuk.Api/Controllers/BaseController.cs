using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        #region DECLARE
        IBaseService<MISAEntity> _baseService;
        #endregion

        #region Constructor
        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns>Collection Object</returns>
        /// CreatedBy: NTANH (08/02/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.GetAll();
            var entities = serviceResult.Data as List<MISAEntity>;
            if (entities.Count == 0)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }

        [HttpGet("GetCode")]
        public IActionResult GetCode()
        {
            var serviceResult = _baseService.GetCode();
            var entities = serviceResult.Data;
            if (entities == null)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }


        [HttpGet("SearchByCodeAndName")]
        public IActionResult SearchByCodeAndName(string str)
        {
            var serviceResult = _baseService.SearchByCodeAndName(str);
            var entities = serviceResult.Data;
            if (entities == null)
            {
                return StatusCode(204, serviceResult.Data);
            }
            else
            {
                return StatusCode(200, serviceResult.Data);
            }
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Kiểu của Object cần thêm</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// CreatedBy: NTANH (08/02/2021)
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {   
            var res = _baseService.Insert(entity);

            if (res.Success == false)
                return StatusCode(400, res.Data);
            else if (res.Success == true && (int)res.Data > 0)
                return StatusCode(201, res.Data);
            else
                return StatusCode(200, res.Data);
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity">đối tượng cần cập nhật</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: NTANH (20/02/2021)
        [HttpPut]
        public IActionResult Put(MISAEntity entity)
        {
            var res = _baseService.Update(entity);

            if (res.Success == false)
                return StatusCode(400, res.Data);
            else if (res.Success == true && (int)res.Data > 0)
                return StatusCode(201, res.Data);
            else
                return StatusCode(200, res.Data);
        }

        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: NTANH (20/02/2021)
        [HttpDelete]
        public IActionResult Delete(MISAEntity entity)
        {
            var res = _baseService.Delete(entity);

            if (res.Success == false)
                return StatusCode(400, res.Data);
            else if (res.Success == true && (int)res.Data > 0)
                return StatusCode(201, res.Data);
            else
                return StatusCode(200, res.Data);
        }
        #endregion
    }
}
