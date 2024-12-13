using System.Collections;
using UnityEngine;

namespace CodeBase.Logic
{
    public class LoadingCurtain : MonoBehaviour
    {
        public static LoadingCurtain Instance { get; private set; }

        [SerializeField] private CanvasGroup curtain;
        private const float _fadeDuration = 0.5f;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            StartCoroutine(FadeOut(null));
        }

        public void Show()
        {
            curtain.alpha = 1;
            curtain.blocksRaycasts = true;
        }

        public void HideInstant()
        {
            curtain.alpha = 0;
            curtain.blocksRaycasts = false;
        }

        public void ShowWithFadeIn(System.Action onFadeComplete)
        {
            StartCoroutine(FadeIn(onFadeComplete));
        }

        public void HideWithFadeOut(System.Action onFadeComplete)
        {
            StartCoroutine(FadeOut(onFadeComplete));
        }

        private IEnumerator FadeIn(System.Action onFadeComplete)
        {
            var elapsedTime = 0f;
            curtain.blocksRaycasts = true;

            while (elapsedTime < _fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                curtain.alpha = Mathf.Lerp(0f, 1f, elapsedTime / _fadeDuration);
                yield return null;
            }

            curtain.alpha = 1f;
            onFadeComplete?.Invoke();
        }

        private IEnumerator FadeOut(System.Action onFadeComplete)
        {
            var elapsedTime = 0f;
            var startAlpha = curtain.alpha;

            while (elapsedTime < _fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                curtain.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / _fadeDuration);
                yield return null;
            }

            curtain.alpha = 0f;
            curtain.blocksRaycasts = false;
            onFadeComplete?.Invoke();
        }
    }
}
