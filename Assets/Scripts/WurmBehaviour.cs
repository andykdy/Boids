using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WurmBehaviour", menuName = "Scriptable Objects/WurmBehaviour")]
public abstract class WurmBehaviour : ScriptableObject
{
    public abstract Vector2 CalculateMove(Wurm wurm, List<Transform> context, WurmManager manager);
}
