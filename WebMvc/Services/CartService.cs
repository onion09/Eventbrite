
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

using WebMvc.Infrastructure;
using WebMvc.Models;
using WebMvc.Models.CartModels;
using WebMvc.Models.OrderModels;

namespace WebMvc.Services
{
    public class CartService : ICartService
    {
        private readonly string _baseUrl;
        private readonly IConfiguration _config;
        private readonly IHttpClient _apiClient;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IConfiguration config, IHttpClient apiClient, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _apiClient = apiClient;
            _httpContextAccessor = httpContextAccessor;

            _baseUrl = $"{config["CartUrl"]}/api/cart";

        }
        private async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccessor.HttpContext;
            return await context.GetTokenAsync("access_token");
        }

       public async Task AddItemToCart(ApplicationUser user, CartItem product)
        {
            var cart = await GetCart(user);

            //if the item already exists in teh cart, then increase the quntity else add item to the cart.

            var basketitem =
                cart.Items.Where(p => p.EventId == product.EventId).FirstOrDefault();

            if (basketitem == null)
            {
                cart.Items.Add(product);
            }
            else
            {

                basketitem.Quantity++;
            }


            await UpdateCart(cart);
        }

        public async Task ClearCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();
            var cleanBasketUri = APIPaths.Basket.CleanBasket(_baseUrl, user.Email);

            await _apiClient.DeleteAsync(cleanBasketUri, token);        
        }

        public async Task<Cart> GetCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();
            //user.Email = "me@myemail.com";
            var getBasketUri = APIPaths.Basket.GetBasket(_baseUrl, user.Email);
            var dataString = await _apiClient.GetStringAsync(getBasketUri, token);

            var response = JsonConvert.DeserializeObject<Cart>(dataString) ??
                new Cart
                {
                    BuyerId = user.Email
                };
            return response;


        }

        public async Task<Cart> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities)
        {

            var basket = await GetCart(user);
            basket.Items.ForEach(x =>
            {
                if (quantities.TryGetValue(x.Id, out var quantity))
                {
                    x.Quantity = quantity;
                }
            });
            return basket;
        }

        public Order MapCartToOrder(Cart cart)
        {
            var order = new Order();
            order.OrderTotal = 0;

            cart.Items.ForEach(x =>
            {
                order.OrderItems.Add(new OrderItem()
                {
                    ProductId = int.Parse(x.EventId),

                    PictureUrl = x.PictureUrl,
                    ProductName = x.EventName,
                    Units = x.Quantity,
                    UnitPrice = x.UnitPrice
                });
                order.OrderTotal += (x.Quantity * x.UnitPrice);
            });

            return order;
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var token = await GetUserTokenAsync();
            var updateBasketUri = APIPaths.Basket.UpdateBasket(_baseUrl);
            var response = await _apiClient.PostAsync(updateBasketUri, cart, token);

            response.EnsureSuccessStatusCode();

            return cart;
        }
    }

}

