using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Life_CycleRentals.Dtos;
using Life_CycleRentals.Models;

namespace Life_CycleRentals.App_Start
{
    public class MappingProfile : Profile
    {
        // Domain to Dto

        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Bike, BikeDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Style, StyleDto>();

       


            //// Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<BikeDto, Bike>()
                    .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}