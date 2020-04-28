using Newtonsoft.Json;

namespace Sana.Apptouch {
    public class SKUDetail {
        public string productId;
        public string price;
        public double priceAmount;
        public string priceCurrencyCode;
        public string title;
        public string description;

        public static SKUDetail FromJson(string json) {
            return JsonConvert.DeserializeObject<SKUDetail>(json);
        }
    }
}