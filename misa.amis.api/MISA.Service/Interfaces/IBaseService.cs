﻿using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interfaces
{
    /// <summary>
    /// Interface của BaseService
    /// </summary>
    /// <typeparam name="MISAEntity">Kiểu truyền vào</typeparam>
    /// CreatedBy: NTANH (21/02/2021)
    public interface IBaseService<MISAEntity>
    {
        ServiceResult GetAll();
        ServiceResult GetCode();
        ServiceResult SearchByCodeAndName(string str);
        ServiceResult Insert(MISAEntity entity);
        ServiceResult Update(MISAEntity entity);
        ServiceResult Delete(MISAEntity entity);
    }
}
