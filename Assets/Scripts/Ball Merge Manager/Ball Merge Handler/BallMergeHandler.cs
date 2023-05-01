using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class BallMergeHandler : MonoBehaviour, IBallMergeHandler
    {
        List<GameObject> mergeBalls = new List<GameObject>();
        List<GameObject> ballsToRemove = new List<GameObject>();

        public void DestroyMergedBalls(ChipFactory[] ballFactories)
        {
            foreach (var ballFactory in ballFactories)
            {
                ballsToRemove.Clear();

                foreach (var ball in ballFactory.objects)
                {
                    mergeBalls.Clear();

                    foreach (var comparedBall in ballFactory.objects)
                        AddToListOfMergeBalls(ballsToRemove, mergeBalls, ball, comparedBall);

                    AddToListOfBallsToRemove(ballsToRemove, mergeBalls, ball);
                }
                DestroyBalls(ballFactory, ballsToRemove);
            }
        }

        void AddToListOfMergeBalls(List<GameObject> ballsToRemove, List<GameObject> mergeBalls, GameObject ball, GameObject comparedBall)
        {
            if (ball != comparedBall && !ballsToRemove.Contains(comparedBall))
            {
                float mergeDistance = (ball.transform.localScale.x + comparedBall.transform.localScale.x) / 2;
                float sqrMergeDistance = mergeDistance * mergeDistance;
                Vector2 distance = ball.transform.position - comparedBall.transform.position;
                float sqrDistance = distance.sqrMagnitude;

                if (sqrDistance <= sqrMergeDistance)
                    mergeBalls.Add(comparedBall);
            }
        }

        void AddToListOfBallsToRemove(List<GameObject> ballsToRemove, List<GameObject>mergeBalls, GameObject ball)
        {
            if (mergeBalls.Count > 1)
                ballsToRemove.AddRange(mergeBalls);
            else if (mergeBalls.Count > 0 && ballsToRemove.Contains(ball))
                ballsToRemove.Add(mergeBalls[0]);
        }

        void DestroyBalls(ChipFactory ballFactory, List<GameObject> ballsToRemove)
        {
            foreach (var ball in ballsToRemove)
                ballFactory.Destroy(ball);
        }
    }
}