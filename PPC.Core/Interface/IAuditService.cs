using WebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Interface
{
    public interface IAuditService
    {
        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool InsertData(SysAuditData model);
    }
}
