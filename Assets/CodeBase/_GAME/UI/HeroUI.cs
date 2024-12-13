using UnityEngine;
using UnityEngine.UI;

namespace CodeBase._GAME.UI
{
    public class PlayerUI : MonoBehaviour
    {
        public static PlayerUI Instance { get; private set; }

        [SerializeField] private Text scoreText;
        [SerializeField] private Text hpText;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void UpdateStats(int score, int currentHp)
        {
            scoreText.text = $"{score} pts";
            hpText.text = $"x{currentHp}";
        }
    }
}