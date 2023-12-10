using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezeeta.Core.Dtos;

namespace Vezeeta.Service.Interfaces
{
    public interface IUserService
    {
        public string Login(LoginDTO model);
        public bool Register(RegisterDTO model);
    }
}
