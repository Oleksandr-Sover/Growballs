using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        public IChipFactoryController ChipFactoryController { get => chipFactoryController; }
        IChipFactoryController chipFactoryController;

        [SerializeField]
        int numberOfChips;

        void Awake()
        {
            chipFactoryController = GetComponentInChildren<IChipFactoryController>();
        }

        void Start()
        {
            //chipFactoryController.AddChipsToGame(numberOfChips);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                chipFactoryController.AddChipsToGame(numberOfChips);
            }
        }
    }
}