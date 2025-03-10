using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
[CreateAssetMenu(menuName = "Boids/Behaviour/SteeredCohesion")]
public class SteeredCohesionBehaviour : FilterWurmBehaviour
{
    private Vector2 currentVelocity;
    public float agentSmoothTime = 0.5f;
    public override Vector2 CalculateMove(Wurm wurm, List<Transform> context, WurmManager manager, Transform p)
    {
        if (context.Count == 0)
            return Vector2.zero;
        Vector2 cohesionMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(wurm, context);

        // Average out the position data of transforms in context
        foreach (Transform t in filteredContext)
        {
            cohesionMove += (Vector2)t.position;
        }
        cohesionMove /= context.Count;

        // Obtain delta pos
        cohesionMove -= (Vector2)wurm.transform.position;

        // Smooth out cohesion based vector changes to avoid "flickering" 
        cohesionMove = Vector2.SmoothDamp(wurm.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime);
        return cohesionMove;
    }
}