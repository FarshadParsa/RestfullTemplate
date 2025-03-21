using System;
using System.Collections.Generic;
using System.Text;

namespace PPC.Base.Interface
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
