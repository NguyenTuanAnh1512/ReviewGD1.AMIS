using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class DepartmentService:BaseService<Department>
    {
        public DepartmentService(IBaseData<Department> DbContext) : base(DbContext)
        {

        }
    }
}
