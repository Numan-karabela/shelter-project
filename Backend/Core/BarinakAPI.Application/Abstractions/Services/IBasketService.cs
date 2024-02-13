using BarinakAPI.Application.ViewModel.Baskets;
using BarinakAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarinakAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();
        
        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem);

        public Task UpdateQuentityAsync(VM_Update_BasketItem basketItem);

        public Task RemoveBasketItemAsync(string basketItemId);

        public Basket? GetUserActiveBasket {get;}


    }
}
