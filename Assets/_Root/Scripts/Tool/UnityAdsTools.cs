using Services.Ads;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
{
    private string _gameId = "5144303";
    private string _rewardPlace = "RewardedAndroid";
    private string _interstitialPlace = "Interstitial_Android";

    private Action _callbackSuccessShowVideo;

    private void Start()
    {
        Advertisement.Initialize(_gameId, true);
        Advertisement.AddListener(this);
    }

    public void ShowInterstitial()
    {
        _callbackSuccessShowVideo = null;
        Advertisement.Show(_interstitialPlace);
    }

    public void ShowVideo(Action successShow)
    {
        _callbackSuccessShowVideo = successShow;
        Advertisement.Show(_rewardPlace);
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            _callbackSuccessShowVideo?.Invoke();
            _callbackSuccessShowVideo = null;
        }
    }
}
