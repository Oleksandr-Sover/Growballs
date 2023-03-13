using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    public class GameObjectPool : IGameObjectPool
    {
        public int DeactiveGOPoolCount { get => deactiveGO.Count; }
        public List<GameObject> ActiveGO { get => activeGO; }

        List<GameObject> activeGO = new List<GameObject>();

        List<GameObject> deactiveGO = new List<GameObject>();

        public void EnableGO(GameObject go)
        {
            go.SetActive(true);
            activeGO.Add(go);
        }

        public void DisableGO(GameObject go)
        {
            go.SetActive(false);
            deactiveGO.Add(go);
            activeGO.Remove(go);
        }

        public GameObject PullOutDisableGO()
        {
            GameObject go = deactiveGO.Last();
            deactiveGO.Remove(go);
            return go;
        }
    }
}