using GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class LevelData : MonoBehaviour
    {
        public StartingPositionField[] StartingPositionField { get => startingPositionField; }
        [SerializeField]
        StartingPositionField[] startingPositionField;

        public float MinChipScale { get => minChipScale; }
        [SerializeField]
        float minChipScale;

        public float MaxChipScale { get => maxChipScale; }
        [SerializeField]
        float maxChipScale;

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

        void OnDrawGizmos()
        {
            if (startingPositionField.Length > 0)
            {
                Gizmos.color = Color.magenta;
                Vector3 fromPos;
                Vector3 toPos;

                foreach (var field in startingPositionField)
                {
                    fromPos = new Vector3(field.minXPosition, field.minYPosition, 0);
                    toPos = new Vector3(field.maxXPosition, field.minYPosition, 0);
                    Gizmos.DrawLine(fromPos, toPos);

                    //fromPos = new Vector3(field.minXPosition, field.minYPosition, 0);
                    //toPos = new Vector3(field.minXPosition, field.maxYPosition, 0);
                    //Gizmos.DrawLine(fromPos, toPos);

                    //fromPos = new Vector3(field.maxXPosition, field.minYPosition, 0);
                    //toPos = new Vector3(field.maxXPosition, field.maxYPosition, 0);
                    //Gizmos.DrawLine(fromPos, toPos);

                    //fromPos = new Vector3(field.minXPosition, field.maxYPosition, 0);
                    //toPos = new Vector3(field.maxXPosition, field.maxYPosition, 0);
                    //Gizmos.DrawLine(fromPos, toPos);
                }
            }
        }
    }
}