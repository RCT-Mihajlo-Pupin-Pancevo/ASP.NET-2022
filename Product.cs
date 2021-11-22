using System;

namespace RctWebApp
{
    /// <summary>
    /// This object represents a model that will be used to load row form a database.
    /// C# properties will be mapped to the database columns and JSON properties in the response output.
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
