using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdFunding.BLL.Tools.Mappers
{
    public static class CountryMappers
    {
        public static BLL.Country ToBLL(this DAL.Country e)
        {
            return new BLL.Country
            {
                Id = e.Id,
                Name = e.Name,
            };
        }
    }
}
