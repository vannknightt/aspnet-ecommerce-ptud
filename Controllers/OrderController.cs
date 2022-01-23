using System;
using System.Linq;
using System.Security.Claims;

using ECommerceAPI.Models;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly OrderService _OrderService;
        public OrderController(OrderService OrderService)
        {
            _OrderService = OrderService;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get() => (_OrderService.Get());


        [HttpGet("{id:length(24)}", Name = "GetOrder")]
        public ActionResult<Order> Get(string id)
        {
            var Order = _OrderService.Get(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        [HttpPost]
        public ActionResult<Order> Create([FromBody] Order Order)
        {
            _OrderService.Create(Order);

            return CreatedAtRoute("GetOrder", new { id = Order.id.ToString() }, Order);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Order OrderIn)
        {
            var Order = _OrderService.Get(id);

            if (Order == null)
            {
                return NotFound();
            }

            _OrderService.Update(id, OrderIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Order = _OrderService.Get(id);

            if (Order == null)
            {
                return NotFound();
            }

            _OrderService.Remove(Order.id);

            return NoContent();
        }



    }
}