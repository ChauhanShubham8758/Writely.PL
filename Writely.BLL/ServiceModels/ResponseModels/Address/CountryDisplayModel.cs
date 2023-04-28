using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writely.BLL.ServiceModels.ResponseModels.Address
{
    public class CountryDisplayModel
    {
        public int Id { get; set; }
        public string Name { get; protected set; }
        public int CountryCode { get; set; }
        public string Currency { get; set; }
    }
}
