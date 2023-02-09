using Tool;
using System;
using UnityEngine;
using JetBrains.Annotations;
using Features.Inventory.Items;

using Object = UnityEngine.Object;
using Features.Shed;
using Features.Shed.Upgrade;
using Profile;

namespace Features.Inventory
{

    internal class ShedContext : BaseContext
    {
        private static readonly ResourcePath _viewPath = new("Prefabs/Shed/ShedView");
        private static readonly ResourcePath _dataSourcePath = new("Configs/Shed/UpgradeItemConfigDataSource");


        public ShedContext([NotNull] Transform placeForUi, [NotNull] IInventoryModel model, ProfilePlayer profilePlayer)
        {
            if (placeForUi == null)
                throw new ArgumentNullException(nameof(placeForUi));

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if(profilePlayer == null)
                throw new ArgumentNullException(nameof(profilePlayer));

            CreateController(placeForUi, model, profilePlayer);
        }

        private ShedController CreateController(Transform placeForUi, IInventoryModel model, ProfilePlayer profilePlayer)
        {
            ShedView view = LoadView(placeForUi);
            UpgradeHandlersRepository repository = CreateRepository();
            InventoryContext inventoryContext = CreateInventoryContext(placeForUi, model);

            var shedController = new ShedController(view, profilePlayer, inventoryContext, repository);
            AddController(shedController);

            return shedController;
        }


        private InventoryContext CreateInventoryContext(Transform placeForUi, IInventoryModel model)
        {
            var context = new InventoryContext(placeForUi, model);
            AddContext(context);

            return context;
        }

        private UpgradeHandlersRepository CreateRepository()
        {
            UpgradeItemConfig[] upgradeConfigs = ContentDataSourceLoader.LoadUpgradeItemConfigs(_dataSourcePath);
            var repository = new UpgradeHandlersRepository(upgradeConfigs);
            AddRepository(repository);

            return repository;
        }

        private ShedView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<ShedView>();
        }
    }
}