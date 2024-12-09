using Microsoft.AspNetCore.Mvc;
using OrderManagement.Data;
using OrderManagement.Models;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderManagementController : ControllerBase
    {
        private ApiContext _context;
        private readonly IConfiguration _configuration;

        public OrderManagementController(ApiContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //Post (Create)
        [HttpPost("/api/[controller]/order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Order> Post(Order order)
        {
            if (order.Id == 0)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            else
            {
                var orderInDb = _context.Orders.Find(order.Id);
                if (orderInDb == null)
                {
                    return NotFound();
                }
                order = orderInDb;
            }

            try
            {
                return Ok(order);
            }
            catch (Exception)
            {
                return Problem(_configuration["ErrorMessages:ErrorPost"]);
            }
        }

        //Get
        [HttpGet("/api/[controller]/order/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Order> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var result = _context.Orders.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(result);
            }
            catch (Exception)
            {
                return Problem(_configuration["ErrorMessages:ErrorGet"]);
            }
        }

        //Get All
        [HttpGet("/api/[controller]/order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Order>> GetAll()
        {
            var result = _context.Orders.ToList();
            if (result == null)
            {
                return NotFound();
            }

            try
            {
                return Ok(result);
            }
            catch (Exception)
            {
                return Problem(_configuration["ErrorMessages:ErrorGetAll"]);
            }

        }

        //Delete
        [HttpDelete("/api/[controller]/order/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var result = _context.Orders.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            try
            {
                _context.Orders.Remove(result);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return Problem(_configuration["ErrorMessages:ErrorDelete"]);
            }
        }

        //Put
        [HttpPut("/api/[controller]/order/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Order> Update(int id, Order order)
        {
            if (order == null || id != order.Id)
            {
                return BadRequest();
            }

            var result = _context.Orders.FirstOrDefault(u => u.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            result.Name = order.Name;
            result.Description = order.Description;
            result.OrderStatus = order.OrderStatus;
            result.Price = order.Price;

            try
            {
                _context.Orders.Update(result);
                _context.SaveChanges();
                return Ok(result);
            }
            catch (Exception)
            {
                return Problem(_configuration["ErrorMessages:ErrorPut"]);
            }
        }
    }
}
