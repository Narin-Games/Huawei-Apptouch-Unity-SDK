using Newtonsoft.Json;
using UnityEngine;

namespace Sana.Apptouch {
    public class ApptouchSDK {
        private static AndroidJavaClass _apptouchSDK;

        static ApptouchSDK() {
            _apptouchSDK = new AndroidJavaClass("com.sana.apptouchsdk.unity.wrapper.ApptouchUnityReceiver");
        }

        public static void InitSDK(string appId, string appKey) {
            _apptouchSDK.CallStatic("initSDK", appId, appKey);
        }

        public static void GetSKUDetail() {
            _apptouchSDK.CallStatic("getSKUDetail");
        }

        public static void PurchaseProduct(SKUDetail sku) {
            Debug.Log("Serialize Json with Json.Net: " + JsonConvert.SerializeObject(sku));
            _apptouchSDK.CallStatic("purchaseProduct", JsonConvert.SerializeObject(sku));
        }
    }
}
