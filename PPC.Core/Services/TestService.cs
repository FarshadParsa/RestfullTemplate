using WebApi.Core.Interface;
using WebApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Services
{
    public class TestService : BaseService, ITestService
    {
        public Test getAll()
        {
            throw new NotImplementedException();
        }
    }
}
