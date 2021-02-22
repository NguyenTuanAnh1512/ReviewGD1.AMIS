using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class EmployeeService: BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IBaseData<Employee> DbContext) : base(DbContext)
        {

        }

        /// <summary>
        /// Hàm ghi đè Validate của hàm BaseService
        /// </summary>
        /// <param name="employee">Đối tượng cần validate</param>
        /// <param name="errorMsg">errorMsg muốn truyền về</param>
        /// <returns>true - hợp lệ; false - không hợp lệ</returns>
        /// CreatedBy: NTANH (08/02/2021)
        protected override bool ValidateInsert(Employee employee, ErrorMsg errorMsg)
        {
            var serviceResult = new ServiceResult();
            var dbContext = new EmployeeRepository();
            var isValid = true;

            // 1. validate bắt buộc nhập
            // - Kiểm tra bắt buộc nhập mã nhân viên
            if (employee.EmployeeCode == null || employee.EmployeeCode.Trim() == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeCode;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeCode;
                isValid = false;
            }
            // - Kiểm tra bắt buộc nhập tên
            if (employee.FullName == null || employee.FullName.Trim() == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_EmptyFullName;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_EmptyFullName;
                isValid = false;
            }
            // - Kiểm tra bắt buộc nhập số CMT
            //if (employee.IdentifyNumber == null || employee.IdentifyNumber.Trim() == string.Empty)
            //{
            //    errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_EmptyIdentifyNumber;
            //    errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_EmptyIdentifyNumber;
            //    isValid = false;
            //}


            // 2. validate dữ liệu không được phép trùng: (mã nhân viên, số CMT)
            // - kiểm tra trong DB đã tồn tại mã nhân viên hay chưa
            var isExist = dbContext.CheckEmployeeCodeExist(employee.EmployeeCode);

            if (isExist == true)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode;
                isValid = false;
            }

            // - kiểm tra trong DB đã tồn tại số CMT hay chưa
            isExist = dbContext.CheckIdentifyNumberExist(employee.IdentifyNumber);
            if (isExist == true)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateIdentifyNumber;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateIdentifyNumber;
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Hàm ghi đè ValidateUpdate của hàm BaseService
        /// </summary>
        /// <param name="employee">đối tượng cần validate</param>
        /// <param name="errorMsg">câu thông báo lỗi trả về</param>
        /// <returns>true - hợp lệ ; false - không hợp lệ</returns>
        /// CreatedBy: NTANH (20/02/2021)
        protected override bool ValidateUpdate(Employee employee, ErrorMsg errorMsg)
        {
            var serviceResult = new ServiceResult();
            var dbContext = new EmployeeRepository();
            var isValid = true;

            // validate bắt buộc nhập
            // - Kiểm tra bắt buộc nhập mã nhân viên
            if (employee.EmployeeCode == null || employee.EmployeeCode.Trim() == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeCode;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeCode;
                isValid = false;
            }
            // - Kiểm tra bắt buộc nhập tên
            if (employee.FullName == null || employee.FullName.Trim() == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_EmptyFullName;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_EmptyFullName;
                isValid = false;
            }
            // - Kiểm tra bắt buộc nhập số CMT
            //if (employee.IdentifyNumber == null || employee.IdentifyNumber.Trim() == string.Empty)
            //{
            //    errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_EmptyIdentifyNumber;
            //    errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_EmptyIdentifyNumber;
            //    isValid = false;
            //}

            // - kiểm tra trong DB đã tồn tại số CMT hay chưa
            //var isExist = dbContext.CheckIdentifyNumberExist(employee.IdentifyNumber);
            //isExist = dbContext.CheckIdentifyNumberExist(employee.IdentifyNumber);
            //if (isExist == true)
            //{
            //    errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateIdentifyNumber;
            //    errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateIdentifyNumber;
            //    isValid = false;
            //}


            //if (isExist == true)
            //{
            //    errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode;
            //    errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode;
            //    isValid = false;
            //}
            return isValid;
        }
    }
}
