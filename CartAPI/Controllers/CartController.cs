using CartAPI.Data;
using CartAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace CartAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _reporsitory;
        public CartController(ICartRepository repository)
        {
            _reporsitory = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Get(string id)
        {
            var basket = await _reporsitory.GetCartAsync(id);
            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Cart basket)
        {
            var updatedBasket = await _reporsitory.UpdateCartAsync(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _reporsitory.DeleteCartAsync(id);
        }

    }
}
