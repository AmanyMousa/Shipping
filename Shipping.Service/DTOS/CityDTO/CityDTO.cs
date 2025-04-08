using Shipping.Serivec.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.CityDTO
{
    // Shipping.Service/DTOS/CityDto.cs
    public class CityDto
    {
        public int Cid { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int GovId { get; set; }
    }

    public class CityDetailsDto : CityDto
    {
        //public GovernmentDto Gov { get; set; }
        public IEnumerable<UsersDTO> Users { get; set; }
    }
}
