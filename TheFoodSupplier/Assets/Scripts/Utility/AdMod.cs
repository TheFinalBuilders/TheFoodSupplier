﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;


public class AdMod : SingletonMonoBehaviour<AdMod>
{

    [RuntimeInitializeOnLoadMethod()]
    static void Init()
    {
        instance = (AdMod)FindObjectOfType(typeof(AdMod));
        if (instance == null)
        {
            instance = Instantiate(ResourceLoader.LoadAdModPrefab()).GetComponent<AdMod>();
            DontDestroyOnLoad(instance);
        }
    }

    void Awake()
    {

        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {

#if DEVELOPMENT_BUILD
        // アプリID、 これはテスト用
        string appId = "ca-app-pub-3940256099942544/6300978111";
#else
        string appId = "ca-app-pub-3031515327169796~5970239458";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        RequestBanner();
    }

    private void RequestBanner()
    {

        // 広告ユニットID これはテスト用
        string adUnitId = "ca-app-pub-3031515327169796/2577789351";

        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

        // Create a 320x50 banner at the top of the screen.
        //bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
    }

    // Update is called once per frame
    void Update()
    {

    }
}