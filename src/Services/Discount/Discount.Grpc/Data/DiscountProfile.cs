﻿using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Data
{
    public class DiscountProfile:Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon,CouponModel>().ReverseMap();
        }
    }
}
