using System.Collections.Generic;
using UnityEngine;

public abstract class WurmBehaviour : ScriptableObject
{
    public abstract Vector2 CalculateMove(Wurm wurm, List<Transform> context, WurmManager manager, Transform playerTransform);
}
