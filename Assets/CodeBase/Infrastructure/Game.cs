using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using CodeBase.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;
        public static IInputService InputService;

        private const string MenuScene = "Menu";

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, IAssetProvider assetProvider, SceneLoader sceneLoader, IGameFactory gameFactory, DiContainer container)
        {
            StateMachine = new GameStateMachine(container);
            
            RegisterInputService();

            StateMachine.RegisterState(new BootstrapState(StateMachine, assetProvider));
            StateMachine.RegisterState(new LoadLevelState(StateMachine, sceneLoader, gameFactory,MenuScene));
            StateMachine.RegisterState(container.Instantiate<GameLoopState>());
        }

        private static void RegisterInputService()
        {
            if (Application.isEditor)
                InputService = new StandaloneInputService();
            else
                InputService = new MobileInputService();
        }
    }
}