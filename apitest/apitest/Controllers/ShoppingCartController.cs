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
        private List<Product> Cart = new List<Product>();

        [HttpGet]
        public IEnumerable<Product> Get(string productName,int productPrice)
        {
            var sessionCart = HttpContext.Session.GetObjectFromJson<List<Product>>("Cart");
            var product = new Product() { Name = productName, Price = productPrice };

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

        [HttpGet("GetShoppingCart")]
        public IEnumerable<Product> GetShoppingCart()
        {
            return HttpContext.Session.GetObjectFromJson<List<Product>>("Cart");
        }

        [HttpDelete("DeleteItemInShoppingCart")]
        public IEnumerable<Product> GetShoppingCart(string productName,int productPrice)
        {
            var sessionList = HttpContext.Session.GetObjectFromJson<List<Product>>("Cart").Where(e => e.Name != productName && e.Price != productPrice);

            HttpContext.Session.SetObjectAsJson("Cart",sessionList);

            return HttpContext.Session.GetObjectFromJson<List<Product>>("Cart");
        }
    }
}
