using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour,IUnityAdsInitializationListener
{
    [SerializeField] private string _androidId;
    [SerializeField] private string _appleId;
    private string _gameId;
    private const string _bannerAdId = "Banner_Android";
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android) _gameId = _androidId;
        else _gameId = _appleId;
        InitAds();
    }
    private void InitAds()
    {
        Advertisement.Initialize(_gameId, true);
        ShowBannerAd();
    }
    public void OnInitializationComplete()
    {
        print("OnInitializationComplete");
        
    }
    public void OnInitializationFailed(UnityAdsInitializationError error,string message)
    {
        print("Failed: " + message);
    }
    private void ShowBannerAd()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        BannerLoadOptions options = new BannerLoadOptions();
        options.loadCallback = OnLoad;
        options.errorCallback = OnError;
        Advertisement.Banner.Load(_bannerAdId);
        Advertisement.Banner.Show();
    }

    private void OnLoad()
    {
      
    }

    private void OnError(string message)
    {
      
    }
}
