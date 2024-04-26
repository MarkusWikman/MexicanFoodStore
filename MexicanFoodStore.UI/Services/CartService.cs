using Blazored.LocalStorage;
using MexicanFoodStore.API.DTO;
using MexicanFoodStore.API.DTO.DTOs;

namespace MexicanFoodStore.UI.Services
{
    public class CartService
    {
        private readonly LocalStorage _storage;

        public List<CartItemDTO> CartItems { get; private set; } = [];
        CartItemDTO CurrentCartItem { get; set; } = new();

        public CartService(LocalStorage storage) => _storage = storage;
        public async Task AddToCart()
        {
            // Clear any error message
            if (CurrentCartItem.Id == 0)
                throw new ArgumentException("Cart item not valid");

            CartItems.Add(CurrentCartItem);
            CurrentCartItem = new();

            await SaveCart();
        }

        public async Task SaveCart() => await _storage.SetAsync("Cart", CartItems);
        public async Task GetCartItems() => CartItems = await _storage.GetAsync<List<CartItemDTO>>("Cart") ?? [];
        public async Task RemoveFromCart(CartItemDTO item)
        {
            CartItems.Remove(item);
            await SaveCart();
        }
    }
}
