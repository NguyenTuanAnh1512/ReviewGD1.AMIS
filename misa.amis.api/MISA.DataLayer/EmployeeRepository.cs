using Dapper;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    public class EmployeeRepository: DbContext<Employee>
    {
        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên cần kiểm tra</param>
        /// <returns>true - đã tồn tại; false - chưa tồn tại</returns>
        /// CreatedBy: NTANH (21/02/2021)
        public bool CheckEmployeeCodeExist(string employeeCode)
        {
            var sql = $"SELECT EmployeeCode FROM Employee AS E WHERE E.EmployeeCode = '{employeeCode}'";
            var employeeCodeExist = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (employeeCodeExist != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Kiểm tra số CMT đã tồn tại hay chưa
        /// </summary>
        /// <param name="IdentifyNumber">Số CMT cần kiểm tra</param>
        /// <returns>true - đã tồn tại; false - chưa tồn tại</returns>
        /// CreatedBy: NTANH (21/02/2021)
        public bool CheckIdentifyNumberExist(string IdentifyNumber)
        {
            if(IdentifyNumber.Trim() == "" || IdentifyNumber.Trim() == string.Empty) 
            {
                return false;
            }
            var sql = $"SELECT IdentifyNumber FROM Employee AS E WHERE E.IdentifyNumber = '{IdentifyNumber}'";
            var peopleIDExist = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (peopleIDExist != null)
                return true;
            else
                return false;
        }
    }
}
