using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class ChipFactoryController : MonoBehaviour, IChipFactoryController
    {
        public ChipFactory[] ballFactories { get => _ballFactories; }
        [SerializeField]
        ChipFactory[] _ballFactories;
        public ChipFactory[] barrierFactories { get => _barrierFactories; }
        [SerializeField]
        ChipFactory[] _barrierFactories;
        public ChipFactory much4BallFactory { get => _much4BallFactory; }
        [SerializeField]
        ChipFactory _much4BallFactory;
        public ChipFactory much5BallFactory { get => _much5BallFactory; }
        [SerializeField]
        ChipFactory _much5BallFactory;
        public ChipFactory much6BallFactory { get => _much6BallFactory; }
        [SerializeField]
        ChipFactory _much6BallFactory;

        IStartChipStaytment StartChipStaytment;

        List<ChipFactory> activeFactories;
        List<ChipFactory> suitableFactories = new List<ChipFactory>();

        GameObject chip;

        void Awake()
        {
            CreateListOfActiveFactories();
            StartChipStaytment = GetComponent<IStartChipStaytment>();
        }

        void CreateListOfActiveFactories()
        {
            activeFactories = new List<ChipFactory>();

            CompliteList(ballFactories, activeFactories);
            CompliteList(barrierFactories, activeFactories);

            AddToList(much4BallFactory, activeFactories);
            AddToList(much5BallFactory, activeFactories);
            AddToList(much6BallFactory, activeFactories);
        }

        void CompliteList(ChipFactory[] addedFactories, List<ChipFactory> factories)
        {
            foreach (var factory in addedFactories)
            {
                if (factory.levelProbability > 0)
                    factories.Add(factory);
            }
        }

        void AddToList(ChipFactory addedFactory, List<ChipFactory> factories)
        {
            if (addedFactory.levelProbability > 0)
                factories.Add(addedFactory);
        }

        public void AddChipsToGame(int numOfChips)
        {
            int chipsAmount = 0;
            StartChipStaytment.SetStartingPositionFields(numOfChips);

            while (numOfChips > chipsAmount)
            {
                float probability = Random.value;

                suitableFactories.Clear();

                foreach (var factory in activeFactories)
                {
                    if (factory.levelProbability > probability)
                        suitableFactories.Add(factory);
                }

                int factoriesCount = suitableFactories.Count;

                if (factoriesCount > 0)
                {
                    if (factoriesCount > 1)
                    {
                        int factoryNum = Random.Range(0, factoriesCount);
                        InstallChip(factoryNum);
                        chipsAmount++;
                    }
                    else
                    {
                        InstallChip(0);
                        chipsAmount++;
                    }
                }
                else break;
            }
        }

        void InstallChip(int factoryNum)
        {
            chip = suitableFactories[factoryNum].Create();
            StartChipStaytment.SetChipStaytment(chip);
        }
    }
}