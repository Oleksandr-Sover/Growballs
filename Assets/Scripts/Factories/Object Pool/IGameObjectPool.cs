using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IGameObjectPool
    {
        int DeactiveGOPoolCount { get; }
        List<GameObject> ActiveGO { get; }
        void EnableGO(GameObject go);
        void DisableGO(GameObject go);
        GameObject PullOutDisableGO();
    }
}