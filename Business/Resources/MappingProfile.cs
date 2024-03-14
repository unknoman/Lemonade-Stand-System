using AutoMapper;
using Models;
using Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Resources
{
    public class MappingProfile : Profile
    {
            public MappingProfile()
            {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductType, ProductTypeDTO>();
        }
        
    }
}
