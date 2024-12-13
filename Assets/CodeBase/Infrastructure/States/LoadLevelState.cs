using System.Threading.Tasks;
using CodeBase.Infrastructure.Factory;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private const string GameScene = "Game";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly string _sceneName;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory,
            string sceneName)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _sceneName = sceneName;
        }

        public void Enter()
        {
            _sceneLoader.Load(_sceneName, CheckSceneLoaded);
        }

        public void Exit()
        {
        }

        private async void CheckSceneLoaded()
        {
            while (SceneManager.GetActiveScene().name != GameScene)
            {
                await Task.Yield();
            }
            
            _stateMachine.Enter<GameLoopState>();
        }
    }
}