using CodeBase.Infrastructure.Factory;
using CodeBase.Logic;
using CodeBase.Utils.SmartDebug;

namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IGameFactory _gameFactory;
        
        private readonly DSender _sender = new("GameLoopState");

        public GameLoopState(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        public void Enter()
        {
            OnLoad();
            DLogger.Message(_sender)
                .WithText("Entering GameLoopState. Game cycle started.")
                .Log();
        }

        public void Exit()
        {
            DLogger.Message(_sender)
                .WithText("Exiting GameLoopState.")
                .Log();
        }

        private void OnLoad()
        {
            LoadingCurtain.Instance.HideWithFadeOut(() =>
            {
                _gameFactory.CreateHud();
            });
        }
    }
}