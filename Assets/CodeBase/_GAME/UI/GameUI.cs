using System.Collections;
using CodeBase._GAME.Util;
using CodeBase.Logic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase._GAME.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private GameObject levelCompletePanel;
        [SerializeField] private GameObject gameOverPanel;

        private const string GameBootstrapper = "GameBootstrapper";

        public void ShowLevelCompletePanel() => 
            levelCompletePanel.SetActive(true);

        public void ShowGameOverPanel() => 
            gameOverPanel.SetActive(true);

        public void ReturnToMenuFromLevelComplete()
        {
            GameProgressManager.UnlockNextLevel();

            StartCoroutine(CleanAndLoadMenu());
        }

        public void ReturnToMenuFromGameOver()
        {
            StartCoroutine(CleanAndLoadMenu());
        }
        
        private IEnumerator CleanAndLoadMenu()
        {
            LoadingCurtain.Instance.Show();
            yield return new WaitForSeconds(1f);

            DontDestroyCleaner.ClearAll();

            SceneManager.LoadScene(GameBootstrapper);
        }
    }
}