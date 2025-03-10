using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boids/Behaviour/Avoidance")]
public class AvoidanceBehaviour : FilterWurmBehaviour
{
    public override Vector2 CalculateMove(Wurm wurm, List<Transform> context, WurmManager manager, Transform p)
    {
        if (context.Count == 0)
            return Vector2.zero;
        Vector2 avoidanceMove = Vector2.zero;
        int n_avoid = 0;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(wurm, context);
        foreach (Transform t in filteredContext)
        {
            // if close enough to avoid, add the "repulsion" force vector to planned move
            if (Vector2.SqrMagnitude(t.position - wurm.transform.position) < manager.SquareAvoidRadius)
            {
                n_avoid++;
                avoidanceMove += (Vector2)(wurm.transform.position - t.position);
            }
        }

        if (n_avoid > 0)
            avoidanceMove /= n_avoid; // average out
        return avoidanceMove;
    }
}