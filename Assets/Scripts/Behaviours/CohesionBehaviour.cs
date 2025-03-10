using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boids/Behaviour/Cohesion")]
public class CohesionBehaviour : FilterWurmBehaviour
{
    public override Vector2 CalculateMove(Wurm wurm, List<Transform> context, WurmManager manager, Transform p)
    {
        if (context.Count == 0)
            return Vector2.zero;
        Vector2 cohesionMove = Vector2.zero;

        // Average out the position data of transforms in context
        foreach (Transform t in context)
        {
            cohesionMove += (Vector2)t.position;
        }
        cohesionMove /= context.Count;

        // Obtain delta pos
        cohesionMove -= (Vector2)wurm.transform.position;
        return cohesionMove;
    }
}