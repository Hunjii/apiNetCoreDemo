using System;
using System.Collections.Generic;
using System.Linq;
using ApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiNotCore.Controllers
{
 [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        public static List<Product> listProd = new List<Product>()
            {
                new Product { ID = 1, Name = "Nguyễn Văn A"},
                new Product { ID = 2, Name = "Nguyễn Văn B"},  
                new Product { ID = 3, Name = "Nguyễn Văn C"},  
                new Product { ID = 4, Name = "Nguyễn Văn D"},  

            };
        

        // [HttpGet]
        // public IActionResult Get()
        // {
        //     var data = listProd.ToArray();

        //     return Json(new
        //     {
        //         status = "success",
        //         length = data.Length,
        //         data = data
        //     });
        // }

        [HttpGet]
        public IActionResult Get([FromQuery] string Name = null)
        {
            if(!String.IsNullOrEmpty(Name)) {
                var product = listProd.Find(x => x.Name == Name);
                if(product == null) return Json(new { status= "none"});
                return Json(new { status= "success", data = product});
            }
            var data = listProd.ToArray();
            return Json(new
            {
                status = "success",
                length = data.Length,
                data = data
            });
        }

        [HttpPost]
        public IActionResult Post(Product prod)
        {

            listProd.Add(prod);

            return Json(new
            {
                status = "success",
                data = prod
            });

            // return CreatedAtAction("Get", new { id = prod.ID }, prod);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)

        {
            var product = listProd.Find(x => x.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return Json(new
            {
                status = "success",
                data = product
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = listProd.SingleOrDefault(x => x.ID == id);
            listProd.Remove(product);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] JsonPatchDocument<Product> patchDoc){
            if (patchDoc == null)
                {
                    return BadRequest();
                }
            var product = listProd.Find(x => x.ID == id);
            
        }

    }
    
}