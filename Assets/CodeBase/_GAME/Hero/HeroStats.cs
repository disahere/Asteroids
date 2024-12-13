using CodeBase._GAME.UI;
using UnityEngine;

namespace CodeBase._GAME.Hero
{
    public class HeroStats : MonoBehaviour
    {
        public static HeroStats Instance { get; private set; }
        
        [SerializeField] private int initialHp = 3;
        private int Score { get; set; }
        private int Hp { get; set; }


        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            Score = 0;
            Hp = initialHp;
        }

        public void AddScore(int amount)
        {
            Score += amount;
            UpdateUI();
        }

        public void TakeDamage(int damage)
        {
            Hp -= damage;
            UpdateUI();
        }

        private void UpdateUI()
        {
            PlayerUI.Instance.UpdateStats(Score, Hp);
        }
    }
}