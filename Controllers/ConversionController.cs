using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RctWebApp.Controllers
{
    /// <summary>
    /// A class that contains all Web API endpoints under /Conversion/ path.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly ILogger<ConversionController> _logger;

        public ConversionController(ILogger<ConversionController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// The endpoint that responds on /Conversion/?rsd=<value> request.
        /// </summary>
        [HttpGet]
        public ConversionModel Get(double rsd)
        {
            var result = new ConversionModel();
            result.euro = rsd / 120.0;
            result.usd = rsd / 100.5;
            result.chf = rsd / 112.0;
            return result;
        }

        /// <summary>
        /// The endpoint that responds on /Conversion/euro?rsd=<value> request.
        /// </summary>
        [HttpGet("euro")]
        public object ConvertToEuro(double rsd)
        {
            return new { value = rsd / 120.0 };
        }

        /// <summary>
        /// The endpoint that responds on /Conversion/usd?rsd=<value> request.
        /// </summary>
        [HttpGet("usd")]
        public object ConvertToDollar(double rsd)
        {
            return new { value = rsd / 100.5 };
        }

        /// <summary>
        /// The endpoint that responds on /Conversion/chf?rsd=<value> request.
        /// </summary>
        [HttpGet("chf")]
        public object ConvertToFranc(double rsd)
        {
            return new { value = rsd / 112 };
        }
    }
}
