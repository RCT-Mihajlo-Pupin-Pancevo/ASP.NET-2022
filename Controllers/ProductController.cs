using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RctWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        readonly ILogger<ProductController> _logger;
        IDbConnection connection = null;

        public ProductController(ILogger<ProductController> logger, IDbConnection connection)
        {
            this.connection = connection;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var sql = "SELECT * FROM Product";
            var products = connection.Query<Product>(sql);
            return products.AsList();
        }

        [HttpGet("ByColor")]
        public IEnumerable<Product> GetProductsByColor(string color)
        {
            var sql = "SELECT * FROM Product WHERE Color = @Color";
            var products = connection.Query<Product>(sql, new { Color = color} );
            return products.AsList();
        }

    }
}
