using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crud.Model;

namespace Crud.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepo productRepo;
        public ProductController()
        {
            productRepo=new ProductRepo();
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepo.GetAll();
        }
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepo.GetById(id);
        }
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            if(ModelState.IsValid)
                productRepo.Add(product);
        }
        [HttpPut("{id}")]
        public void Put(int id,[FromBody]Product product)
        {
            product.ProductId=id;
            if(ModelState.IsValid)
                productRepo.Update(product);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            productRepo.Delete(id);
        }

    }
}
