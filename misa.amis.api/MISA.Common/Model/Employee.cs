using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    /// <summary>
    /// Nhân viên
    /// CreatedBy: NTANH (07/02/2021)
    /// </summary>
    public class Employee
    {
        #region Contructor
        #endregion

        #region Method
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        
        /// <summary>
        /// Giới tính (1 - Nam; 0 - Nữ; 2 - Khác)
        /// </summary>
        public int? Gender { get; set; }
        
        /// <summary>
        /// Số CMT, căn cước
        /// </summary>
        public string IdentifyNumber { get; set; }
        
        /// <summary>
        /// Ngày cấp CMT, căn cước
        /// </summary>
        public DateTime? DateOfIdentifyNumber { get; set; }
        
        /// <summary>
        /// Nơi cấp CMT, căn cước
        /// </summary>
        public string PlaceOfIdentifyNumber { get; set; }

        /// <summary>
        /// Khóa ngoại bảng đơn vị (Department)
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Chức danh
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        public string MobilePhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string LandlinePhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string BankAcountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string BankBranch { get; set; }

        /// <summary>
        /// Tỉnh/Thành phố của ngân hàng
        /// </summary>
        public string BankProvince { get; set; }

        /// <summary>
        /// Trạng thái tài khoản
        /// </summary>
        public string PropertyBankAcount { get; set; }
        #endregion

        #region Other
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        
        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }
        
        /// <summary>
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        
        /// <summary>
        /// Người thực hiện chỉnh sửa gần nhất
        /// </summary>
        public string ModifiedBy { get; set; }
        
        #endregion
    }
}
