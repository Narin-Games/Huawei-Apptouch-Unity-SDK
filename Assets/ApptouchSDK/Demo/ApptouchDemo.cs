using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sana.Apptouch;

public class ApptouchDemo : MonoBehaviour {

    private SKUDetail _sku;
    void OnEnable() {
        ApptouchEventManager.initEvent              += InitEventHandler;
        ApptouchEventManager.getSKUDetailEvent      += GetSKUDetailEventHandler;
        ApptouchEventManager.purchaseProductEvent   += PurchaseProductEventHandler;
    }

    void OnDisable() {
        ApptouchEventManager.initEvent              -= InitEventHandler;
        ApptouchEventManager.getSKUDetailEvent      -= GetSKUDetailEventHandler;
        ApptouchEventManager.purchaseProductEvent   -= PurchaseProductEventHandler;
    }

    void OnGUI() {
        GUILayout.BeginArea(new Rect(10f, 10f, Screen.width - 15f, Screen.height - 15f));
        GUI.skin.button.fixedHeight = 50;
        GUI.skin.button.fontSize = 20;


        if (Button("Init SDK")) {
            ApptouchSDK.InitSDK("101727771", "fe8c26b7a11c331882f5ba9bb231864a");
        }

        if(Button("Get SKU Detail")) {
            ApptouchSDK.GetSKUDetail();
        }

        if(Button("Purchase Product")) {
            Debug.Log("The SKU for Purchasing: " + _sku.productId);
            ApptouchSDK.PurchaseProduct(_sku);
        }

        GUILayout.EndArea();
    }

    private bool Button(string label) {
        GUILayout.Space(5);
        return GUILayout.Button(label);
    }

    private void InitEventHandler(int resultCode) {
        Debug.Log("Init Callback: " + resultCode);
    }

    private void GetSKUDetailEventHandler(List<SKUDetail> skuDetails) {
        _sku = skuDetails[0];
        Debug.Log("Get SKU Callback: " + _sku.productId);
    }

    private void PurchaseProductEventHandler(int resultCode) {
        Debug.Log("Purchase Callback: " + resultCode);
    }
}