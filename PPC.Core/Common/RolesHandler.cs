using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Common
{
    public static class RolesHandler
    {
        public const string Admin = nameof(Admin);
        public const string User = nameof(User);
        public const string Editor = nameof(Editor);
        public const string AdminOrUser = nameof(AdminOrUser);

    }
}
