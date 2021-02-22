using Dapper;
using MISA.Common.Model;
using MISA.DataLayer.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    public class DbContext<MISAEntity>:IBaseData<MISAEntity>
    {
        #region DECLARE
        protected string _connectionString = "User Id=dev;Host=47.241.69.179;Port=3306;Database=MF711_NTANH_AMIS;Password=12345678;Character Set=utf8";
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DbContext()
        {
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Hàm lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Collection Object</returns>
        /// CreatedBy: NTANH (08/02/2021)
        public IEnumerable<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;
            // Thực thi truy vấn lấy dữ liệu
            var entities = _dbConnection.Query<MISAEntity>($"Proc_Get{className}s", commandType: CommandType.StoredProcedure);
            // trả về kết quả cho Client:
            return entities;
        }

        /// <summary>
        /// Hàm Lấy dữ liệu theo sqlCommand
        /// </summary>
        /// <param name="sqlCommand">Câu sql hoặc tên Store</param>
        /// <param name="commandType">kiểu của sqlCommand (Text hoặc Store)</param>
        /// <returns>Collection Object</returns>
        /// CreatedBy: NTANH (08/02/2021)
        public IEnumerable<MISAEntity> GetAll(string sqlCommand, CommandType commandType = CommandType.Text)
        {
            // Thực thi truy vấn lấy dữ liệu
            var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: commandType);
            // trả về kết quả cho Client:
            return entities;
        }

        /// <summary>
        /// Lấy dữ liệu theo nhiều tiêu chí khác nhau
        /// </summary>
        /// <typeparam name="MISAEntity">Type của Object</typeparam>
        /// <param name="sqlCommand">Tên store hoặc mã SQL (Nếu lấy tất cả thì không cần truyền đối số này)</param>
        /// <param name="parameter">Đối tượng chưa thông tin tham số của store</param>
        /// <param name="commandType">kiểu của sqlCommand: Text hoặc StoreProcedure (nếu không truyền mặc định là Text)</param>
        /// <returns>Collection Object</returns>
        /// CreatedBy: NTANH (07/02/2021)
        public IEnumerable<MISAEntity> GetData(string sqlCommand = null, object parameter = null, CommandType commandType = CommandType.Text)
        {
            var className = typeof(MISAEntity).Name;
            if (sqlCommand == null)
            {
                sqlCommand = $"SELECT * FROM View_{className}";
            }
            // Lấy dữ liệu:
            var data = _dbConnection.Query<MISAEntity>(sqlCommand, param: parameter, commandType: commandType);
            return data;
        }

        /// <summary>
        /// Hàm lấy toàn bộ Mã trong Database (VD: EmployeeCode, CustomerCodeCode)
        /// </summary>
        /// <returns></returns>
        public List<string> GetCode()
        {
            var className = typeof(MISAEntity).Name;
            // Thực thi truy vấn lấy dữ liệu
            var entities = _dbConnection.Query<string>($"Proc_Get{className}Codes", commandType: CommandType.StoredProcedure).ToList();
            // trả về kết quả cho Client:
            return entities;
        }

        /// <summary>
        /// Hàm tìm kiếm theo Code và Name
        /// </summary>
        /// <param name="str">Chuỗi kí tự muốn tìm</param>
        /// <returns>các bản ghi có Code hoặc Name chứa chuỗi kí tự muốn tìm</returns>
        /// CreatedBy: NTANH (22/02/2021)
        public IEnumerable<MISAEntity> SearchByCodeAndName(string str)
        {
            var className = typeof(MISAEntity).Name;
            // Thực thi truy vấn lấy dữ liệu
            var entities = _dbConnection.Query<MISAEntity>($"Proc_Search{className}sByCodeAndName", new { str = str }, commandType: CommandType.StoredProcedure);
            // trả về kết quả cho Client:
            return entities;
        }

        /// <summary>
        /// Thực hiện thêm mới object vào database
        /// </summary>
        /// <param name="entity">object cần thêm mới</param>
        /// <returns>số lượng bản ghi thêm được vào database</returns>
        /// CreatedBy: NTANH (07/01/2021)
        public int InsertObject(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            var storeName = $"Proc_Insert{className}";

            // Lấy ra các property của object:
            var properties = typeof(MISAEntity).GetProperties();

            // duyệt từng property - lấy tên và giá trị của property.

            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                if ((property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?)) && propName.ToLower() == $"{className}Id".ToLower())
                    propValue = Guid.NewGuid();

                dynamicParameters.Add($"@{propName}", propValue);
            }


            var res = _dbConnection.Execute(storeName,param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Thực hiện Cập nhật Object vào Database
        /// </summary>
        /// <param name="entity">obj cần cập nhật</param>
        /// <returns>số lượng bản ghi bị thay đổi trong database</returns>
        /// CreatedBy: NTANH (20/01/2021)
        public int UpdateObject(MISAEntity entity)
        {

            var className = typeof(MISAEntity).Name;
            var storeName = $"Proc_Update{className}";

            // Lấy ra các property của object:
            var properties = typeof(MISAEntity).GetProperties();

            // duyệt từng property - lấy tên và giá trị của property.

            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                dynamicParameters.Add($"@{propName}", propValue);
            }

            var res = _dbConnection.Execute(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Thực hiện xóa đối tượng trong Database
        /// </summary>
        /// <param name="entity">Đối tượng cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng trong Database</returns>
        /// CreatedBy: NTANH (20/02/2021)
        public int DeleteObject(MISAEntity entity)
        {

            var className = typeof(MISAEntity).Name;
            var storeName = $"Proc_Delete{className}";

            // Lấy ra các property của object:
            var properties = typeof(MISAEntity).GetProperties();

            // duyệt từng property - lấy tên và giá trị của property.

            DynamicParameters dynamicParameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propName = property.Name;
                var propValue = property.GetValue(entity);

                dynamicParameters.Add($"@{propName}", propValue);
            }

            var res = _dbConnection.Execute(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return res;
        }
        #endregion
    }
}
