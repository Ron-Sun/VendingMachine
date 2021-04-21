using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{


    /// <summary>
    /// Non physical item.
    /// </summary>
    public interface IService
    {
        string ServiceInfo { get; set; }        // Special case.
    }
    /// <summary>
    /// Normal products
    /// </summary>
    public interface IProduct : IService
    {
        string ProductName { get; set; }
        string ProductDeskription { get; set; }
        string ProductUsage { get; set; }
        string ProductPrice { get; set; }
    }


    public class ProductInCart : IProduct
    {
        public string ProductName { get; set; }
        public string ProductDeskription { get; set; }
        public string ProductUsage { get; set; }
        public string ProductPrice { get; set; }
        public string ServiceInfo { get; set; }

        /// <summary>
        /// Assemble product
        /// </summary>
        /// <param name="items"></param>
        public ProductInCart(string items)
        {
            string[] item = items.Split(new char[] { ';', '\r' });
            ProductName = item[3].Trim();
            ProductDeskription = item[5].Trim();
            ProductUsage = item[6].Trim();
            ProductPrice = item[4].Trim();

            // Ej fysiska varor.
            switch (item[2].Trim())
            {
                case "Service":
                    {
                        switch (item[1].Trim())
                        {
                            case "0":
                                {
                                    ServiceInfo = "Service beställd. Städning utförs 09:00";
                                    break;
                                }
                            case "1":
                                {
                                    ServiceInfo = "Service beställd. Väckning enligt avtal.";
                                    break;
                                }
                            case "2":
                                {
                                    ServiceInfo = "Service beställd. Frukost på sängen.";
                                    break;
                                }
                        }
                        break;
                    }
                case "Music":
                    {
                        ServiceInfo = "Musik beställd. Finns att lyssna på i musikanläggningen.";
                        break;
                    }
                case "Film":
                    {
                        ServiceInfo = "Film beställd. Finns att se i tv'n.";
                        break;
                    }
            }
        }
    }
}
