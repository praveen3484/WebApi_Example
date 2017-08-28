using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2Api.Dto;
using WebApplication2Api.Models;

namespace WebApplication2Api.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member1, MemberDto>();
            CreateMap<MemberDto, Member1>();
        }

    }
}