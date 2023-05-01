using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class BallMergeManager : MonoBehaviour
    {
        IGameManager GameManager;
        IBallMergeHandler BallMergeHandler;

        ChipFactory[] ballFactories;

        void Awake()
        {
            GameManager = GetComponentInParent<IGameManager>();
            BallMergeHandler = GetComponent<IBallMergeHandler>();
        }

        void Start()
        {
            ballFactories = GameManager.ChipFactoryController.ballFactories;
        }

        void DormancyCheck()
        {
            foreach (var factory in ballFactories)
            {
                var length = factory.objects.Count;
                Vector2[] prePosition = new Vector2[length];

                for (int i = 0; i < length; i++)
                {
                    
                }
            }
        }
    }
}