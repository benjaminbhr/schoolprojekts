using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace apitest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : Controller
    {
        /// <summary>
        /// Adds the specified product to the Cart list in the existing session if there is one, if not, we create a new list,
        /// and assign it to the session
        /// </summary>
        /// <param name="productName">Name of product</param>
        /// <param name="productPrice">Price of product</param>
        /// <returns>IEnumerable collection of Product</returns>
        [HttpGet]
        public IEnumerable<Product> Get(string productName,int productPrice)
        {
            List<Product> sessionCart = HttpContext.Session.GetObjectFromJson<List<Product>>("Cart");
            Product product = new Product() { Name = productName, Price = productPrice };

            if (sessionCart != null)
            {
                sessionCart.Add(product);
                HttpContext.Session.SetObjectAsJson("Cart",sessionCart);
            }
            else
            {
                sessionCart = new List<Product>();
                sessionCart.Add(product);
                HttpContext.Session.SetObjectAsJson("Cart", sessionCart);
            }

            return sessionCart;
        }

        /// <summary>
        /// Removes the specified product from the Session collection "Cart"
        /// </summary>
        /// <param name="productName">Name of product to remove</param>
        /// <param name="productPrice">Price of product to remove</param>
        /// <returns>IEnumerable collection of session list after deletion</returns>
        [HttpDelete("DeleteItemInShoppingCart")]
        public IEnumerable<Product> GetShoppingCart(string productName,int productPrice)
        {
            var sessionList = HttpContext.Session.GetObjectFromJson<List<Product>>("Cart").Where(e => e.Name != productName && e.Price != productPrice);

            HttpContext.Session.SetObjectAsJson("Cart",sessionList);

            return HttpContext.Session.GetObjectFromJson<List<Product>>("Cart");
        }
    }
}
