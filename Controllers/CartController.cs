using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Models;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ECommerceAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public const string CARTKEY = "cart";

        private readonly ProductService _productService;
        public CartController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult<List<CartItem>> Get() => (GetCartItems(CARTKEY));

        [Route("addcart/{productid}", Name = "addcart")]
        [HttpPost]
        public ActionResult<List<CartItem>> AddToCart([FromRoute] string productid)
        {

            var product = _productService.Get(productid);
            if (product == null)
                return NotFound("Khong co san pham");

            var cart = GetCartItems(CARTKEY);

            var cartitem = cart.Find(p => p.product.product_id == productid);
            if (cartitem != null)
            {
                cartitem.quantity++;
            }
            else
            {
                cart.Add(new CartItem() { quantity = 1, product = product });
            }

            SaveCartSession(cart);
            return GetCartItems(CARTKEY);
        }

        [Route("updatecartquantity/{productid}/{quantity}", Name = "updatecartquantity")]
        [HttpPut]
        public ActionResult<List<CartItem>> UpdateCartQuantity([FromRoute] string productid, [FromRoute] int quantity)
        {
            var cart = GetCartItems(CARTKEY);
            var cartitem = cart.Find(p => p.product.product_id == productid);
            if (cartitem != null)
            {
                cartitem.quantity = quantity;
            }
            SaveCartSession(cart);
            return GetCartItems(CARTKEY);
        }

        [HttpDelete]
        [Route("removecart/{productid}", Name = "removecart")]
        public ActionResult<List<CartItem>> RemoveCart([FromRoute] string productid)
        {
            var cart = GetCartItems(CARTKEY);
            var cartitem = cart.Find(p => p.product.product_id == productid);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return GetCartItems(CARTKEY);
        }
        List<CartItem> GetCartItems(string cartkey)
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(cartkey);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
    }
}