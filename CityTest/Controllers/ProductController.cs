using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;

namespace CityTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        static HttpClient client = new HttpClient();
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult GetProduct()
        {
            var t = getproductlist();

            return Ok(t);
        }


        [HttpGet]
        [Route("Price")]
        public ActionResult GetPrice(string fromprice)
        {
            var t = getpricelist();

            var tt = t.Where(x => x.sourceCurrency == fromprice).ToList();

            return Ok(tt);
        }

        private static List<Product> getproductlist()
        {
            string urls = "http://alltheclouds.com.au/api/Products";
            var prodresult = callAPI(urls, HttpMethod.Get);
            List<Product> product = JsonConvert.DeserializeObject<List<Product>>(prodresult);
            //Product product = new Product();
            return product;

        }
        private static List<Price> getpricelist()
        {
            string urls = "http://alltheclouds.com.au/api/fx-rates";
            var prodresult = callAPI(urls, HttpMethod.Get);
            List<Price> price = JsonConvert.DeserializeObject<List<Price>>(prodresult);
            //Product product = new Product();
            return price;
        }

        private static string callAPI(string url, HttpMethod met)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(url);
            request.Method = met;
            request.Headers.Add("api-key", "API-ZC3DCRSC0D7IN3D");
            HttpResponseMessage response = httpClient.Send(request);
            var responseString = response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;
            //response.EnsureSuccessStatusCode();

            return responseString.Result;
        }


        private class Product
        {
            public string productId { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public decimal unitPrice { get; set; }
            public int? maximumQuantity { get; set; }
        }
        private class Price
        {
            public string sourceCurrency { get; set; }
            public string targetCurrency { get; set; }
            public decimal rate { get; set; }

        }
    }
}
