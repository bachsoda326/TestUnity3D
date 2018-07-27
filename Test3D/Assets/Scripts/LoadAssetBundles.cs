using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadAssetBundles : MonoBehaviour
{
    public string url = "";
    public string objName = "";

    void Start()
    {
        StartCoroutine(DownloadObject());
    }

    IEnumerator DownloadObject()
    {
        WWW www = new WWW(url);
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }

        AssetBundle bundle = www.assetBundle;

        //var obj = bundle.mainAsset;
        var obj = bundle.LoadAsset(objName);
        Instantiate(obj);
    }
}


//-------------------------------------------------------------------------------------------------
//public string url = "ahttp://visual.ariadne-infrastructure.eu/3d/monbracelet";

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