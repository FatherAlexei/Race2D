using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace Tool.Bundles.Examples
{
    internal class AssetBundleViewBase : MonoBehaviour
    {
        private const string UrlAssetBundleSprites = "https://drive.google.com/uc?export=download&id=1rQzWdcChHhJJBTe4rf1D0Kwi1a43jxWR";
        private const string UrlAssetBundleAudio = "https://drive.google.com/uc?export=download&id=1I7euU6Hv5yrn1ektprUumbGHEikklk3Y";
        private const string UrlAssetBundleBackground = "https://drive.google.com/u/0/uc?id=1buVoE5OVSdOQPQG9-UEsAWpTt8BOpHnd&export=download";

        [SerializeField] private DataSpriteBundle[] _dataSpriteBundles;
        [SerializeField] private DataAudioBundle[] _dataAudioBundles;
        [SerializeField] private DataSpriteBundle _dataBacgroundBundle;

        private AssetBundle _spritesAssetBundle;
        private AssetBundle _audioAssetBundle;
        private AssetBundle _spritesAssetBackground;


        protected IEnumerator DownloadAndSetAssetBundles(int a)
        {
            if (a == 1)
            {
                yield return GetSpritesAssetBundle();
                yield return GetAudioAssetBundle();

                if (_spritesAssetBundle != null)
                    SetSpriteAssets(_spritesAssetBundle);
                else
                    Debug.LogError($"AssetBundle {nameof(_spritesAssetBundle)} failed to load");

                if (_audioAssetBundle != null)
                    SetAudioAssets(_audioAssetBundle);
                else
                    Debug.LogError($"AssetBundle {nameof(_audioAssetBundle)} failed to load");
            }
            else
            {
                yield return GetBackgoundAssetBundle();

                if (_spritesAssetBackground != null)
                    SetBacgroundAssets(_spritesAssetBackground);
                else
                    Debug.LogError($"AssetBundle {nameof(_spritesAssetBackground)} failed to load");
            }
        }

        private IEnumerator GetSpritesAssetBundle()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleSprites);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _spritesAssetBundle);
        }

        private IEnumerator GetBackgoundAssetBundle()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleBackground);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _spritesAssetBackground);
        }

        private IEnumerator GetAudioAssetBundle()
        {
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(UrlAssetBundleAudio);

            yield return request.SendWebRequest();

            while (!request.isDone)
                yield return null;

            StateRequest(request, out _audioAssetBundle);
        }

        private void StateRequest(UnityWebRequest request, out AssetBundle assetBundle)
        {
            if (request.error == null)
            {
                assetBundle = DownloadHandlerAssetBundle.GetContent(request);
                Debug.Log("Complete");
            }
            else
            {
                assetBundle = null;
                Debug.LogError(request.error);
            }
        }

        private void SetSpriteAssets(AssetBundle assetBundle)
        {
            foreach (DataSpriteBundle data in _dataSpriteBundles)
                data.Image.sprite = assetBundle.LoadAsset<Sprite>(data.NameAssetBundle);
        }

        private void SetBacgroundAssets(AssetBundle assetBundle)
        {
            _dataBacgroundBundle.Image.sprite = assetBundle.LoadAsset<Sprite>(_dataBacgroundBundle.NameAssetBundle);
        }

        private void SetAudioAssets(AssetBundle assetBundle)
        {
            foreach (DataAudioBundle data in _dataAudioBundles)
            {
                data.AudioSource.clip = assetBundle.LoadAsset<AudioClip>(data.NameAssetBundle);
                data.AudioSource.Play();
            }
        }
    }
}
