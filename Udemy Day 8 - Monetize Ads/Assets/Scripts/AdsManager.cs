using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdsManager instance;
    string gameId = "5785176";
    string interstitialAdId = "Interstitial_Android";
    string bannerAdId = "Banner_Android";

    void Awake()
    {
        instance = this;
        InitializeAds();
    }

    void InitializeAds()
    {
        Advertisement.Initialize(gameId, false, this);
    }

    public void ShowAds ()
    {
        Advertisement.Load(interstitialAdId, this);
        Advertisement.Show(interstitialAdId, this);
    
    }
    public void ShowBannerAd ()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Load(bannerAdId);
        Advertisement.Banner.Show(bannerAdId);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Initialized Ads Manager");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("On Ads init failure");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Ads show failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ads start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Ads clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ads complete");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ads loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Ads load failure");
    }
}
