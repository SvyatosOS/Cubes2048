using UnityEngine;
using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    private InterstitialAd interstitial;
    private BannerView bannerView;

#if UNITY_ANDROID
    string adUnitIdBanner = "ca-app-pub-3940256099942544/6300978111";
    string adUnitIdInterstitialAd = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
   
    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
        this.RequestInterstitial();
    }

    private void RequestBanner()
    {
        this.bannerView = new BannerView(adUnitIdBanner, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }
    private void RequestInterstitial()
    {
        this.interstitial = new InterstitialAd(adUnitIdInterstitialAd);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }
  
    public void StartShowAd()
    {
        this.RequestInterstitial();
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }
}
