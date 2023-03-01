using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;

namespace Tool.Bundles.Examples
{
    internal class LoadWindowView : AssetBundleViewBase
    {
        [Header("Asset Bundles")]
        [SerializeField] private Button _loadAssetsButton;
        [SerializeField] private Button _changeBackgroundButton;

        [Header("Addressables")]
        [SerializeField] private AssetReference _spawningButtonPrefab;
        [SerializeField] private RectTransform _spawnedButtonsContainer;
        [SerializeField] private Button _spawnAssetButton;
        [SerializeField] private AssetReference _backgroundImage;
        [SerializeField] private Transform _placeForUi;
        [SerializeField] private Button _addBackgroundButton;
        [SerializeField] private Button _removeBackgroundButton;


        private readonly List<AsyncOperationHandle<GameObject>> _addressablePrefabs =
            new List<AsyncOperationHandle<GameObject>>();

        private readonly List<AsyncOperationHandle<GameObject>> _addressableBackground =
            new List<AsyncOperationHandle<GameObject>>();


        private void Start()
        {
            _changeBackgroundButton.onClick.AddListener(LoadBackground);
            _loadAssetsButton.onClick.AddListener(LoadAssets);
            _spawnAssetButton.onClick.AddListener(SpawnPrefab);
            _addBackgroundButton.onClick.AddListener(SpawnBackground);
            _removeBackgroundButton.onClick.AddListener(DespawnBackground);
        }

        private void OnDestroy()
        {
            _loadAssetsButton.onClick.RemoveAllListeners();
            _changeBackgroundButton.onClick.RemoveAllListeners();
            _spawnAssetButton.onClick.RemoveAllListeners();
            _addBackgroundButton.onClick.RemoveAllListeners();
            _removeBackgroundButton.onClick.RemoveAllListeners();

            DespawnPrefabs();
        }

        private void LoadBackground()
        {
            _changeBackgroundButton.interactable = false;
            StartCoroutine(DownloadAndSetAssetBundles(0));
        }
        private void LoadAssets()
        {
            _loadAssetsButton.interactable = false;
            StartCoroutine(DownloadAndSetAssetBundles(1));
        }

        private void SpawnBackground()
        {
            AsyncOperationHandle<GameObject> addressablePrefab =
                Addressables.InstantiateAsync(_backgroundImage, _placeForUi);

            _addressableBackground.Add(addressablePrefab);
        }

        private void DespawnBackground()
        {
            foreach (AsyncOperationHandle<GameObject> addressablePrefab in _addressableBackground)
                Addressables.ReleaseInstance(addressablePrefab);

            _addressableBackground.Clear();
        }

        private void SpawnPrefab()
        {
            AsyncOperationHandle<GameObject> addressablePrefab =
                Addressables.InstantiateAsync(_spawningButtonPrefab, _spawnedButtonsContainer);

            _addressablePrefabs.Add(addressablePrefab);
        }

        private void DespawnPrefabs()
        {
            foreach (AsyncOperationHandle<GameObject> addressablePrefab in _addressablePrefabs)
                Addressables.ReleaseInstance(addressablePrefab);

            _addressablePrefabs.Clear();
        }
    }
}
