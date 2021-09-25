using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
        public ProductBase GetById([FromRoute] string id) {
            return new ProductBase();
        }
    }
}
