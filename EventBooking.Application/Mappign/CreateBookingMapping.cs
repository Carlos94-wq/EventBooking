﻿using AutoMapper;
using EventBooking.Application.Commands;
using EventBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Application.Mappign
{
    public class CreateBookingMapping: Profile
    {
        public CreateBookingMapping()
        {
            CreateMap<CreateBooking.Command, Bookings>();
        }
    }
}
