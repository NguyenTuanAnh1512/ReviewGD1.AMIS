using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service
{
    /// <summary>
    /// BaseService
    /// </summary>
    /// <typeparam name="MISAEntity">kiểu truyền vào</typeparam>
    /// CreatedBy: NTANH (21/02/2021)
    public class BaseService<MISAEntity>:IBaseService<MISAEntity>
    {
        #region DECLARE
        IBaseData<MISAEntity> _dbContext;
        #endregion

        #region Constructor
        public BaseService(IBaseData<MISAEntity> dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>ServiceResult tương ứng</returns>
        /// CreatedBy: NTANH (21/02/2021)
        public virtual ServiceResult GetAll()
        {
            var serviceResult = new ServiceResult();
            var dbContext = new DbContext<MISAEntity>();
            serviceResult.Data = dbContext.GetAll();
            return serviceResult;
        }

        /// <summary>
        /// Lấy toàn bộ Code
        /// </summary>
        /// <returns>ServiceResult tương ứng</returns>
        /// CreatedBy: NTANH (21/02/2021)
        public virtual ServiceResult GetCode()
        {
            var serviceResult = new ServiceResult();
            var dbContext = new DbContext<MISAEntity>();
            serviceResult.Data = dbContext.GetCode();
            return serviceResult;
        }

        /// <summary>
        /// Tìm kiếm theo tên, mã
        /// </summary>
        /// <param name="str">xâu cần tìm</param>
        /// <returns>ServiceResult tương ứng</returns>
        /// CreatedBy: NTANH (21/02/2021)
        public virtual ServiceResult SearchByCodeAndName(string str)
        {
            var serviceResult = new ServiceResult();
            var dbContext = new DbContext<MISAEntity>();
            serviceResult.Data = dbContext.SearchByCodeAndName(str);
            return serviceResult;
        }

        /// <summary>
        /// Hàm kiểm tra nghiệp vụ thêm mới
        /// </summary>
        /// <param name="entity">Kiểu của Object cần thêm</param>
        /// <returns>ServiceResult tương ứng</returns>
        /// CreatedBy: NTANH (21/02/2021)
        public virtual ServiceResult Insert(MISAEntity entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            var dbContext = new DbContext<MISAEntity>();
            // Xử lý nghiệp vụ:
            var isValid = ValidateInsert(entity, errorMsg);

            // Gửi lên DataLayer thực hiện thêm mới vào Database:
            if (isValid == true)
            {
                var res = dbContext.InsertObject(entity);
                if (res > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    return serviceResult;
                }
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            return serviceResult;
        }

        /// <summary>
        /// Xử lý nghiệp vụ cập nhật (update)
        /// </summary>
        /// <param name="entity">đối tượng cần update</param>
        /// <returns>ServiceResult tương ứng</returns>
        /// CreatedBy: NTANH (21/02/2021)
        public virtual ServiceResult Update(MISAEntity entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            var dbContext = new DbContext<MISAEntity>();
            // Xử lý nghiệp vụ:
            var isValid = ValidateUpdate(entity, errorMsg);
            //var isValid = true;

            // Gửi lên DataLayer thực hiện thêm mới vào Database:
            if (isValid == true)
            {
                var res = dbContext.UpdateObject(entity);
                if (res > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    return serviceResult;
                }
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            return serviceResult;
        }

        /// <summary>
        /// Xử lý yêu cầu xóa object trong database
        /// </summary>
        /// <param name="entity">Đối tượng cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng trong database</returns>
        /// CreatedBy: NTANH (21/02/2021)
        public virtual ServiceResult Delete(MISAEntity entity)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            var dbContext = new DbContext<MISAEntity>();
            // Xử lý nghiệp vụ:
            //var isValid = ValidateUpdate(entity, errorMsg);
            var isValid = true;

            // Gửi lên DataLayer thực hiện thêm mới vào Database:
            if (isValid == true)
            {
                var res = dbContext.DeleteObject(entity);
                if (res > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    return serviceResult;
                }
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            return serviceResult;
        }

        /// <summary>
        /// Hàm Validate để các Service con ghi đè, trả về mặc định là true
        /// </summary>
        /// <param name="entity">đối tượng cần validate</param>
        /// <param name="errorMsg">errorMsg để lưu lại thông báo</param>
        /// <returns>true - hợp lệ; false - không hợp lệ</returns>
        /// CreatedBy: NTANH (21/02/2021)
        protected virtual bool ValidateInsert(MISAEntity entity, ErrorMsg errorMsg = null)
        {
            return true;
        }

        /// <summary>
        /// Hàm Validate để các Service con ghi đè, trả về mặc định là true
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true - hợp lệ; false - không hợp lệ</returns>
        /// CreatedBy: NTANH (21/02/2021)
        protected virtual bool ValidateUpdate(MISAEntity entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
        #endregion
    }
}
