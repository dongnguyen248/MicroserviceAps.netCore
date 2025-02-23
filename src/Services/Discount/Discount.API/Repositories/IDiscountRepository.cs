﻿using Discount.API.Entities;
namespace Discount.API.Repositories
{
    public interface IDiscountRepository
    {
        public Coupon GetDiscount(string productName);
        public Task<bool> CreateDiscount(Coupon coupon);
        public Task<bool> UpdateDiscount(Coupon coupon);
        public Task<bool> DeleteDiscount(string productName);
    }
}
