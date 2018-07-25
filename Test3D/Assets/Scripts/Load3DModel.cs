using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//using System;
//using Vuforia;

//TABLEhttps://p3d.in/GqZQJ
//BEARhttps://sketchfab.com/models/27ce91e2f2754ca8bb0b00fe2644ae39
//FUNNELhttp://b2b.partcommunity.com/community/partcloud/?route=part&name=Funnel&model_id=72185
//DRIVECHICKENhttps://drive.google.com/file/d/154xObSvwHaqpXOgRNzR9w7rU9OmQk6nm/view

public class Load3DModel : MonoBehaviour
{
    public string BundleURL = "https://sketchfab.com/models/5b2d32574a574074a3a4612388fce020#download";
    public string AssetName;
    public int version;

    void Start()
    {
        StartCoroutine(DownloadAndCache());
    }

    IEnumerator DownloadAndCache()
    {
        // Wait for the Caching system to be ready
        while (!Caching.ready)
            yield return null;

        // Load the AssetBundle file from Cache if it exists with the same version or download and store it in the cache
        using (WWW www = WWW.LoadFromCacheOrDownload(BundleURL, version))
        {
            yield return www;
            if (www.error != null)
                throw new Exception("WWW download had an error:" + www.error);
            AssetBundle bundle = www.assetBundle;
            if (AssetName == "")
                Instantiate(bundle.mainAsset);
            else
                Instantiate(bundle.LoadAsset(AssetName));
            // Unload the AssetBundles compressed contents to conserve memory
            bundle.Unload(false);

        } // memory is freed from the web stream (www.Dispose() gets called implicitly)
    }
}


//-------------------------------------------------------------------------------------------------
//public string url = "http://visual.ariadne-infrastructure.eu/3d/monbracelet";

//void Start()
//{
//    StartCoroutine(LoadModel());
//}

//IEnumerator LoadModel()
//{
//    WWW www = new WWW(url);
//    yield return www;
//    AssetBundle bundle = www.assetBundle;

//    if (www.error == null)
//    {
//        //var obj = bundle.LoadAsset<GameObject>("Funnel");
//        //Instantiate(obj);
//        GameObject obj = Instantiate(bundle.LoadAsset("monbracelet")) as GameObject;
//    }
//    else
//    {
//        Debug.Log(www.error);
//    }
//}

//-------------------------------------------------------------------------------------------


//---------------------------------------------------------------------------
//IEnumerator Start()
//{
//    while (!Caching.ready)
//        yield return null;

//    using (var www = WWW.LoadFromCacheOrDownload("Ahttps://drive.google.com/open?id=154xObSvwHaqpXOgRNzR9w7rU9OmQk6nm", 5))
//    {
//        yield return www;
//        if (!string.IsNullOrEmpty(www.error))
//        {
//            Debug.Log(www.error);
//            yield return null;
//        }
//        var myLoadedAssetBundle = www.assetBundle;

//        var asset = myLoadedAssetBundle.mainAsset;
//    }
//}