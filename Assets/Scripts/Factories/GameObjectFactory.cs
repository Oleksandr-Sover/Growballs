using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public class GameObjectFactory : IFactory<GameObject>
    {
        public List<GameObject> objects { get => GOPool.ActiveGO; }

        readonly IGameObjectPool GOPool = new GameObjectPool();

        [SerializeField]
        GameObject prefab;

        public GameObject Create()
        {
            if (GOPool.DeactiveGOPoolCount > 0)
            {
                GameObject go = GOPool.PullOutDisableGO();
                GOPool.EnableGO(go);
                return go;
            }
            else
            {
                GameObject go = UnityEngine.Object.Instantiate(prefab);
                GOPool.EnableGO(go);
                return go;
            }
        }
        public void Destroy(GameObject objectToDestroy) => GOPool.DisableGO(objectToDestroy);
    }
}