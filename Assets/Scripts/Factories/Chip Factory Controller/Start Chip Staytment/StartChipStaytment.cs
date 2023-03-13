using UnityEngine;

namespace GameLogic
{
    public class StartChipStaytment : MonoBehaviour, IStartChipStaytment
    {
        [SerializeField]
        StartingPositionField[] startingPositionField;

        [SerializeField]
        float minScale;
        [SerializeField]
        float maxScale;

        int fieldCount;

        void Start()
        {
            fieldCount = startingPositionField.Length;
        }

        public void SetChipStaytment(GameObject chip)
        {
            SetChipScale(chip);
            SetStartingPosition(chip);
        }

        public void SetStartingPositionFields(int numOfChips)
        {
            int numOfChipsPerField = numOfChips / fieldCount;

            if (fieldCount == 1)
            {
                startingPositionField[0].SetMaxYPosition(numOfChipsPerField, minScale, maxScale);
            }
            else if (fieldCount > 1)
            {
                foreach (var field in startingPositionField)
                {
                    field.SetMaxYPosition(numOfChipsPerField, minScale, maxScale);
                }
            }
        }

        void SetStartingPosition(GameObject chip)
        {
            if (fieldCount == 1)
            {
                SetRandomPosition(chip, 0);
            }
            else if (fieldCount > 1)
            {
                int fieldNumber = Random.Range(0, startingPositionField.Length);
                SetRandomPosition(chip, fieldNumber);
            }
        }

        void SetRandomPosition(GameObject chip, int fieldNumber)
        {
            float minX = startingPositionField[fieldNumber].minXPosition;
            float maxX = startingPositionField[fieldNumber].maxXPosition;
            float minY = startingPositionField[fieldNumber].minYPosition;
            float maxY = startingPositionField[fieldNumber].maxYPosition;
            float xPosition = Random.Range(minX, maxX);
            float yPosition = Random.Range(minY, maxY);
            Vector2 position = new Vector2(xPosition, yPosition);
            chip.transform.position = position;
        }

        void SetChipScale(GameObject chip) 
        {
            float scale = Random.Range(minScale, maxScale);
            Vector2 scaler = new Vector2(scale, scale);
            chip.transform.localScale = scaler;
        }

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

                    fromPos = new Vector3(field.minXPosition, field.minYPosition, 0);
                    toPos = new Vector3(field.minXPosition, field.maxYPosition, 0);
                    Gizmos.DrawLine(fromPos, toPos);

                    fromPos = new Vector3(field.maxXPosition, field.minYPosition, 0);
                    toPos = new Vector3(field.maxXPosition, field.maxYPosition, 0);
                    Gizmos.DrawLine(fromPos, toPos);

                    fromPos = new Vector3(field.minXPosition, field.maxYPosition, 0);
                    toPos = new Vector3(field.maxXPosition, field.maxYPosition, 0);
                    Gizmos.DrawLine(fromPos, toPos);
                }
            }
        }
    }
}