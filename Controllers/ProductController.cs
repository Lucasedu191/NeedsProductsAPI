using Microsoft.AspNetCore.Mvc;
using Needs.API.Entities;
using Needs.API.ORM;
using Needs.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Needs.API.Controllers {
    //exemplo de como fica a url:
    //urlbase/product/3/byid/4455/?cordoproduto=verde
    [Route("[controller]")]
    public class ProductController : ControllerBase {
        [HttpGet("")]
        public IEnumerable<ProductBase> GetAll(){
            return new List<ProductBase>();
        }

        [HttpGet("{id}")]
        public ProductBase GetById([FromRoute] string id) {
            return new ProductBase();
        }

        [HttpPost("")]
        public object Upsert(
            [FromServices] NeedsDbContext dbContext,
            [FromBody] Product product) {
            dbContext.Add(product);
            dbContext.SaveChanges();
            return product;
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] string id) {
        }
    }
}
