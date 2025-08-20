﻿using System.Collections.Generic;
using App.Common.DataContainer.Runtime;
using App.Common.Logger.Runtime;
using App.Common.ModuleItem.Runtime.Config.Interfaces;
using App.Common.ModuleItem.Runtime.Data;
using App.Common.ModuleItem.Runtime.Fabric.Interfaces;
using App.Common.ModuleItem.Runtime.Services;
using App.Common.Utilities.Utility.Runtime;

namespace App.Common.ModuleItem.Runtime.Fabric
{
    public class ModuleItemCreator : IModuleItemCreator
    {
        private readonly IModuleItemConfigController m_ConfigController;
        private readonly IContainersDataManager m_ContainerController;
        private readonly IReadOnlyList<ICreateModuleItemHandler> m_Handlers;

        public ModuleItemCreator(
            IModuleItemConfigController configController, 
            IContainersDataManager containerController, 
            IReadOnlyList<ICreateModuleItemHandler> handlers)
        {
            m_ConfigController = configController;
            m_ContainerController = containerController;
            m_Handlers = handlers;
        }

        public Optional<IModuleItem> Create(string id)
        {
            var dataReferences = new List<DataReference>();
            var data = new ModuleItemData(id, dataReferences);
            
            var dataReference = m_ContainerController.AddData(ModuleItemData.ContainerKey, data);
            if (!dataReference.HasValue)
            {
                return Optional<IModuleItem>.Fail();
            }
            
            HLogger.LogError($"Module item CREATED {dataReference.Value}");
            
            var moduleItemResult = Create(data, dataReference.Value);
            if (!moduleItemResult.HasValue)
            {
                m_ContainerController.RemoveData(ModuleItemData.ContainerKey, data);
                HLogger.LogError("Failed to create module item for id: " + id);
                return Optional<IModuleItem>.Fail();
            }
            
            return Optional<IModuleItem>.Success(moduleItemResult.Value);
        }

        public Optional<IModuleItem> Create(DataReference dataReference)
        {
            var data = m_ContainerController.GetData<ModuleItemData>(dataReference);
            if (!data.HasValue)
            {
                HLogger.LogError("Data not found for reference: " + dataReference);
                return Optional<IModuleItem>.Fail();
            }
            
            var moduleItemResult = Create(data.Value, dataReference);
            if (!moduleItemResult.HasValue)
            {
                HLogger.LogError("Failed to create module item for data: " + data.Value);
                return Optional<IModuleItem>.Fail();
            }
            
            return Optional<IModuleItem>.Success(moduleItemResult.Value);
        }

        private Optional<IModuleItem> Create(IModuleItemData data, DataReference referenceSelf)
        {
            var config = m_ConfigController.GetConfig(data.Id);
            if (!config.HasValue)
            {
                HLogger.LogError("Config not found for id: " + data.Id);
                return Optional<IModuleItem>.Fail();
            }

            var modulesHolder = new ModulesHolder(m_ContainerController, data.ModuleRefs);
            modulesHolder.Initialize();
            IModuleItem moduleItem = new ModuleItem(modulesHolder, config.Value, data, referenceSelf);
            foreach (var handler in m_Handlers)
            {
                var handledGameItem = handler.Handle(moduleItem);
                if (!handledGameItem.HasValue)
                {
                    HLogger.LogError($"Handler {handler.GetType().Name} failed to handle item with id: {data.Id}");
                    return Optional<IModuleItem>.Fail();
                }

                moduleItem = handledGameItem.Value;
            }
            
            return Optional<IModuleItem>.Success(moduleItem);
        }
    }
}