using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelsDTO.DTOGet
{
    public class ProductTypeGetDTO
    {
        public int id { get; set; }

        public string? name { get; set; }

        public string? description { get; set; }

    }
}
