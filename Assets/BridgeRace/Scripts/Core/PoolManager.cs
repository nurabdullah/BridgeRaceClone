using System;
using System.Collections.Generic;
using BridgeRace.Scripts.Core;
using UnityEngine;
using Random = UnityEngine.Random;

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
            Pool1 = new Queue<GameObject>();
            Pool2 = new Queue<GameObject>();
            Pool3 = new Queue<GameObject>();
            
            FillPool(Pool1GameObject[0],Pool1Parent[0],Pool1,Pool1Count);
            FillPool(Pool1GameObject[1],Pool1Parent[1],Pool2,Pool1Count);
            FillPool(Pool1GameObject[2],Pool1Parent[2],Pool3,Pool1Count);

            queues = new List<Queue<GameObject>>();
            queues.Add(Pool1);
            queues.Add(Pool2);
            queues.Add(Pool3);
            
            // Virtual Pointlere ulas ve positionlarına collectableları ata
            for (int i = 0; i < CollectManager.Instance.virtualPoints.Count; i++)
            {
                var arrayElement = Random.Range(0, queues.Count);
                var collect = this.DequeuePoolObject(queues[arrayElement]);
                collect.transform.position = CollectManager.Instance.virtualPoints[i];
            }
        }

        public List<Queue<GameObject>> queues;

        #region Pools
        [Space(10)]
        public GameObject[] Pool1GameObject;
        public Transform[]  Pool1Parent;
        public int Pool1Count;
        [HideInInspector] public Queue<GameObject> Pool1;
        [HideInInspector] public Queue<GameObject> Pool2;
        [HideInInspector] public Queue<GameObject> Pool3;
        #endregion

        private void FillPool(GameObject prefab, Transform poolParent, Queue<GameObject> pool, int poolCount)
        {
            for (int i = 0; i < poolCount; i++)
            {
                var poolObject = Instantiate(prefab, poolParent);
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