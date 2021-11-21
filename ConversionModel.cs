using System;

namespace RctWebApp
{
    /// <summary>
    /// This object represents a model that will be used to format a JSON response.
    /// C# properties will be mapped to the JSON properties in the response output.
    /// </summary>
    public class ConversionModel
    {
        public double euro { get; set; }
        public double usd { get; set; }
        public double chf { get; set; }
    }
}
