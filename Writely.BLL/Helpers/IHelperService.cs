using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.Helpers
{
    public interface IHelperService
    {
        EncryptResponseModel Encrypt(string password);
    }
}
