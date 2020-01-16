using SportsRetail.Data.Interfaces;
using SportsRetail.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        private int _orderId; //mark

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.ProductId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Product.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();

            //get the OrderId straight from database table after generated
            _orderId = order.OrderId; 
        }

        //count total price of products based on OrderId
        public decimal TotalPrice()
        {
            decimal total = 0;
            var orderDetails = _appDbContext.OrderDetails.Where(o => o.OrderId == _orderId).ToList();
            foreach (var item in orderDetails)
            {
                total += (item.Price * item.Amount);
            }
            return total;
        }
    }
}
