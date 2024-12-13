using CodeBase._GAME.Util;
using CodeBase.Logic;
using CodeBase.Utils.SmartDebug;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase._GAME.Handlers
{
    public class MenuProgressHandler : MonoBehaviour
    {
        [SerializeField] private LevelProgress levelProgress;
        [SerializeField] private Button[] levelButtons;
        [SerializeField] private LevelSettings[] levelSettingsArray;

        private const string GameScene = "Game";

        private readonly DSender _sender = new("MenuProgressHandler");

        private void Start()
        {
            GameProgressManager.Initialize(levelProgress);
            GameProgressManager.LoadProgress();

            UpdateMenu();
        }

        private void UpdateMenu()
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                int index = i;
                levelButtons[i].interactable = i < GameProgressManager.GetUnlockedLevels();
                levelButtons[i].onClick.AddListener(() => OnLevelSelected(index));
            }
        }

        public void OnLevelSelected(int levelIndex)
        {
            if (levelIndex >= GameProgressManager.GetUnlockedLevels()) return;

            LoadingCurtain.Instance.ShowWithFadeIn(() =>
            {
                LevelSettingsManager.SetLevelSettings(levelSettingsArray[levelIndex]);
                SceneManager.LoadScene(GameScene);
            });

            DLogger.Message(_sender)
                .WithText($"Level {levelIndex + 1} selected.")
                .Log();
        }
    }
}