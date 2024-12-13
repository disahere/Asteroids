using System.Collections.Generic;
using UnityEngine;

namespace CodeBase._GAME.Util
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int initialSize = 10;

        private readonly Queue<GameObject> _pool = new();

        private void Awake()
        {
            for (int i = 0; i < initialSize; i++) 
                CreateNewObject();
        }

        private GameObject CreateNewObject()
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            _pool.Enqueue(obj);
            return obj;
        }

        public GameObject Get()
        {
            if (_pool.Count == 0)
            {
                CreateNewObject();
            }

            GameObject obj = _pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}