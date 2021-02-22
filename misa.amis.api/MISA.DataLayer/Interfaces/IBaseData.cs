using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    /// <summary>
    /// Interface DbContext
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    public interface IBaseData<MISAEntity>
    {
        public IEnumerable<MISAEntity> GetAll();
        public int InsertObject(MISAEntity entity);
        public int UpdateObject(MISAEntity entity);
        public int DeleteObject(MISAEntity entity);
    }
}
