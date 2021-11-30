using System;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace.Scripts
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(Instance);
        }


        private void Start()
        {
            FillPool(Pool1GameObject[0],Pool1Parent[0],Pool1,Pool1Count);
            FillPool(Pool1GameObject[1],Pool1Parent[1],Pool1,Pool1Count);
            FillPool(Pool1GameObject[2],Pool1Parent[2],Pool1,Pool1Count);
        }

        #region Pools
        [Space(10)]
        public GameObject[] Pool1GameObject;
        public Transform[]  Pool1Parent;
        public int Pool1Count;
        [HideInInspector] public Queue<GameObject> Pool1 = new Queue<GameObject>();
        #endregion

        private void FillPool(GameObject prefab, Transform poolParent, Queue<GameObject> pool, int poolCount)
        {
            pool = new Queue<GameObject>();
            GameObject poolObject;

            for (int i = 0; i < poolCount; i++)
            {
                poolObject = Instantiate(prefab, poolParent);
                poolObject.SetActive(false);
                pool.Enqueue(poolObject);
            }
        }

        public GameObject DequeuePoolObject(Queue<GameObject> pool)
        {
            GameObject instantiatedGameObject = pool.Dequeue();
            instantiatedGameObject.SetActive(true);
            return instantiatedGameObject;
        }

        public void EnqueuePoolObject(GameObject poolObject, Queue<GameObject> pool)
        {
            poolObject.SetActive(false);
            poolObject.transform.SetPositionAndRotation(gameObject.transform.position, gameObject.transform.rotation);
            pool.Enqueue(poolObject);
        }
    }
}