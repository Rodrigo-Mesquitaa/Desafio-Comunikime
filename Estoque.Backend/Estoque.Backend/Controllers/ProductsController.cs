using Estoque.Backend.Data;
using Estoque.Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                product.SalesCount = 0;
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return product;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }


}