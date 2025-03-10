using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boids/Filter/Same Group")]
public class SameGroup : ContextFilter
{
    public override List<Transform> Filter(Wurm agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform t in original)
        {
            Wurm itemAgent = t.GetComponent<Wurm>();
            if (itemAgent != null && itemAgent.Manager == agent.Manager)
                filtered.Add(t);
        }

        return filtered;
    }
}