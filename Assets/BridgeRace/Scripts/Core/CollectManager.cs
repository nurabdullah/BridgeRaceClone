using System;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace.Scripts.Core
{
    public class CollectManager : Singleton<CollectManager>
    {
        public List<Vector3> virtualPoints;

        private void Awake()
        {
            virtualPoints = new List<Vector3>();
            for (float i = 0f; i < 10.1f; i += 2.5f)
            {
                for (float j = -5.0f; j < 5.1; j += 2.5f)
                {
                    var v3 = new Vector3(j, 0.1f, i);
                    virtualPoints.Add(v3);
                }
            }
            
            for (float i = 40f; i < 50.1f; i += 2.5f)
            {
                for (float j = -5.0f; j < 5.1; j += 2.5f)
                {
                    var v3 = new Vector3(j, 9.1f, i);
                    virtualPoints.Add(v3);
                }
            }
        }
    }
}
