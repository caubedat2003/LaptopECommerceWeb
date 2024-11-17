using LaptopECommerce.Models;

namespace LaptopECommerceWASM.Services
{
    public class CartService
    {
        private List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public List<CartItem> GetCartItems() => CartItems;

        public void AddToCart(CartItem item)
        {
            var existingItem = CartItems.FirstOrDefault(x => x.LaptopId == item.LaptopId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                CartItems.Add(item);
            }
        }

        public void RemoveFromCart(Guid laptopId)
        {
            var item = CartItems.FirstOrDefault(x => x.LaptopId == laptopId);
            if (item != null)
            {
                CartItems.Remove(item);
            }
        }

        public int GetTotalAmount()
        {
            return CartItems.Sum(item => item.Price * item.Quantity);
        }

        public void ClearCart()
        {
            CartItems.Clear();
        }
    }
}
