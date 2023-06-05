using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CityTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Get()
        {
            //retrieve api
            string urls = "http://alltheclouds.com.au/api/Products";


            return Ok(urls);
        }
    }
}
