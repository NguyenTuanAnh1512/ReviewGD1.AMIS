using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;
using MISA.Common.Model;
using MISA.Service.Interfaces;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/job-positions")]
    [ApiController]
    public class DepartmentsController : BaseController<Department>
    {
        public DepartmentsController(IBaseService<Department> _departmentService) : base(_departmentService)
        {

        }
    }
}
