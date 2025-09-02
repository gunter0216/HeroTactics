using System;
using App.Common.AssemblyManager.External;
using App.Common.Autumn.Runtime.Attributes;
using App.Common.Autumn.Runtime.Collection;
using App.Common.Data.Runtime.Attributes;
using App.Common.Logger.External;
using App.Common.Logger.Runtime;
using UnityEngine;
using Zenject;

namespace App.Core.Startups.External
{
    public class GlobalStartup : MonoInstaller<StartSceneStartup>
    {
        public override void InstallBindings()
        {
            HLogger.SetInstance(new UnityLogger());    
            
            var assemblyProvider = new AssemblyManager()
                .CreateAssemblyProviderBuilder()
                .AddAttribute<DataAttribute>()
                .AddAttribute<ConfiguratorAttribute>()
                .Build();
            //
            // var singletons = assemblyProvider.GetTypes<SingletonAttribute>();
            // var scopeds = assemblyProvider.GetTypes<ScopedAttribute>();
            var datas = assemblyProvider.GetTypes<DataAttribute>();
            var configurators = assemblyProvider.GetTypes<ConfiguratorAttribute>();

            ConfiguratorsManager.Instance.SetConfigurators(configurators);
            ConfiguratorsManager.Instance.RunConfigurator(ContextConstants.GlobalContext, Container);
            
            // var transients = assemblyProvider.GetTypes<TransientAttribute>();
            //
            // var diManager = DiManager.Instance;
            // diManager.Init(singletons, scopeds, transients, configurators);
            // m_ServiceProvider = diManager.BuildServiceProvider(typeof(StartSceneContext));
            //
            // m_ServiceProvider.GetService<DataManagerProxy>().SetDatas(datas);
            //
            // var stateMachine = new StateMachine(
            //     m_ServiceProvider.GetInterfaces<IInitSystem>().Cast<IInitSystem>().ToList(),
            //     m_ServiceProvider.GetInterfaces<IPostInitSystem>().Cast<IPostInitSystem>().ToList());
            // stateMachine.AddState(new DefaultStage(typeof(StartInitPhase)));
            // stateMachine.SyncRun();
            //
            // var sceneController = m_ServiceProvider.GetService<SceneManager>();
            // sceneController.LoadScene(SceneConstants.MenuScene);
        }
    }
}