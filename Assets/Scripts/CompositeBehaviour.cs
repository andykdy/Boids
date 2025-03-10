using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Boids/Behaviour/Composite")]
public class CompositeBehaviour : WurmBehaviour
{
    public WurmBehaviour[] behaviours;
    public float[] weights;
    public override Vector2 CalculateMove(Wurm agent, List<Transform> context, WurmManager manager, Transform p)
    {
        // Change ComposositeBehaviour instance to have 1:1 Weight and Behaviour ratio
        if (weights.Length != behaviours.Length)
        {
            Debug.Log("CompositeBehaviour::CalculateMove | 1:1 Weight to Behaviour ratio mismatch");
            return Vector2.zero;
        }
        Vector2 move = Vector2.zero;

        for (int i = 0; i < behaviours.Length; i++)
        {
            Vector2 partialMove = behaviours[i].CalculateMove(agent, context, manager, p) * weights[i];
            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }

        return move;
    }
}