using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DTO_s;
using WebApi.Models;

namespace WebApi.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarStock ,CarStockDTO>();
            CreateMap<CarStockDTO, CarStock>();
        }
    }
}