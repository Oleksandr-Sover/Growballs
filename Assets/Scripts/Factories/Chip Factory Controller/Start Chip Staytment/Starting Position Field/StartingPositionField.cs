using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public class StartingPositionField
    {
        [HideInInspector]
        public float maxYPosition;
        public float minYPosition;
        public float minXPosition;
        public float maxXPosition;
        
        public void SetMaxYPosition(int numOfChips, float minScale, float maxScale)
        {
            float lineLength = Math.Abs(maxXPosition - minXPosition);
            float mediumScale = (minScale + maxScale) * 0.6f;
            float chipsPerLine = lineLength / mediumScale;
            float numberOfLine = numOfChips / chipsPerLine;
            maxYPosition = numberOfLine * mediumScale + minYPosition;
        }
    }
}