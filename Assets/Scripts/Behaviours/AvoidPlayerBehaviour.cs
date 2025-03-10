using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boids/Behaviour/Player Avoidance")]
public class AvoidPlayerBehaviour : FilterWurmBehaviour
{
    public override Vector2 CalculateMove(Wurm wurm, List<Transform> context, WurmManager manager, Transform p)
    {
        Vector2 avoidanceMove = Vector2.zero;
        // if close enough to avoid, add the "repulsion" force vector to planned move
        if (Vector2.SqrMagnitude(p.position - wurm.transform.position) < manager.SquarePlayerAvoidRadius)
            avoidanceMove = (Vector2)(wurm.transform.position - p.position);
        return avoidanceMove;
    }
}