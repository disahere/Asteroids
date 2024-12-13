using UnityEngine;

namespace CodeBase._GAME
{
    public class ScreenWrapper : MonoBehaviour
    {
        private Vector2 _screenBounds;

        private void Start() => 
            _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        private void LateUpdate()
        {
            Vector3 position = transform.position;

            if (position.x > _screenBounds.x)
                position.x = -_screenBounds.x;
            else if (position.x < -_screenBounds.x)
                position.x = _screenBounds.x;

            if (position.y > _screenBounds.y)
                position.y = -_screenBounds.y;
            else if (position.y < -_screenBounds.y)
                position.y = _screenBounds.y;

            transform.position = position;
        }
    }
}