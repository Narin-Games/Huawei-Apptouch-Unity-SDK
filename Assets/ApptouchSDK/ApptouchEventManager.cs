using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sana.Apptouch {
    public class ApptouchEventManager: AbstractManager {

        public static event Action<int> initEvent;

        public static event Action<List<SKUDetail>> getSKUDetailEvent;

        public static event Action<int> purchaseProductEvent;

        static ApptouchEventManager() {
            Initialize(typeof(ApptouchEventManager));
        }

        public void InitCallback(string resultCode) {
            initEvent(int.Parse(resultCode));
        }

        public void GetSKUCallback(string skuDetailsJson) {
            getSKUDetailEvent(JsonConvert.DeserializeObject<List<SKUDetail>>(skuDetailsJson));
        }

        public void PurchaseProductCallback(string resultCode) {
            purchaseProductEvent(int.Parse(resultCode));
        }
    }
}