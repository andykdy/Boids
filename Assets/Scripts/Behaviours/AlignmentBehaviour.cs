using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Behaviour/Alignment")]
public class AlignmentBehaviour : FilterWurmBehaviour
{
    public override Vector2 CalculateMove(Wurm wurm, List<Transform> context, WurmManager manager, Transform p)
    {
        if (context.Count == 0)
            return wurm.transform.up;
        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(wurm, context);

        // Average out the "rotate" data of transforms in context
        foreach (Transform t in filteredContext)
        {
            alignmentMove += (Vector2)t.up;
        }
        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
