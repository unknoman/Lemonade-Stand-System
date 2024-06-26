﻿using AutoMapper;
using Models;
using Models.ModelsDTO.DTOGet;
using Models.ModelsDTO.DTOPost;
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
            CreateMap<Product, ProductGetDTO>();
            CreateMap<ProductType, ProductTypeGetDTO>().ReverseMap();
            CreateMap<ProductType, ProductTypePostDTO>().ReverseMap();
            CreateMap<ProductGetDTO, ProductPostDTO>().ReverseMap();
            CreateMap<ProductPostDTO, Product>().ReverseMap();
            CreateMap<ClientOrderPostDTO, ClientOrder>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailPostDTO>().ReverseMap();
            CreateMap<SuppliesOrder, SuppliesOrderPostDTO>().ReverseMap();
        }
        
    }
}
