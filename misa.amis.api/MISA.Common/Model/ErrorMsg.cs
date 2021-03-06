﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    /// <summary>
    /// Thông báo lỗi trả về cho Client khi có lỗi
    /// </summary>
    /// CreatedBy: NTANH (21/02/2021)
    public class ErrorMsg
    {
        /// <summary>
        /// Thông báo cho Dev
        /// </summary>
        public string DevMsg { get; set; }
        
        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public string ErrorCode { get; set; }
        
        /// <summary>
        /// Thông tin chi tiết
        /// </summary>
        public string MoreInfo { get; set; }
        
        /// <summary>
        /// TraceId
        /// </summary>
        public string TraceId { get; set; }
    }
}
