using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface IGameManager
    {
        IChipFactoryController ChipFactoryController { get; }
    }
}