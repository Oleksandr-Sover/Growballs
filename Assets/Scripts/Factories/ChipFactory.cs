using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public class ChipFactory : GameObjectFactory
    {
        [Range(0f, 1f)]
        public float levelProbability;
    }
}