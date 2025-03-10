using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

public class WurmManager : MonoBehaviour
{
    public Wurm WurmPrefab;
    public WurmBehaviour behaviour;

    [SerializeField]
    private int m_startNum = 10;

    private const float agent_density = 0.08f;

    [Range(1f, 100f)] public float speed = 10f;
    [Range(1f, 100f)] public float max_speed = 5f;

    [Range(1f, 10f)] public float neighbour_radius = 1.5f;
    [Range(0f, 1f)] public float avoidance_radius_mult = 0.5f;
    [Range(0f, 1f)] public float avoidance_player_radius_mult = 0.5f;

    public PlayerBehaviour PlayerPrefab => m_player;
    [SerializeField]
    private PlayerBehaviour m_player;


    private List<Wurm> agents = new List<Wurm>();

    private float squareMaxSpeed;
    private float squareNeighbourRadius;
    private float squareAvoidRadius;
    public float SquareAvoidRadius => squareAvoidRadius;

    private float squarePlayerAvoidRadius;
    public float SquarePlayerAvoidRadius => squarePlayerAvoidRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        squareMaxSpeed = max_speed * max_speed;
        squareNeighbourRadius = neighbour_radius * neighbour_radius;
        squareAvoidRadius = squareNeighbourRadius * avoidance_radius_mult * avoidance_radius_mult;
        squarePlayerAvoidRadius = squareNeighbourRadius * avoidance_player_radius_mult * avoidance_player_radius_mult;
        for (int i = 0; i < m_startNum; i++)
        {
            Wurm newAgent = Instantiate(WurmPrefab, Random.insideUnitCircle * m_startNum * agent_density,
                Quaternion.Euler(0, 0, Random.Range(0f, 360f)), transform);
            newAgent.name = "Agent " + i;
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Wurm ws in agents)
        {
            List<Transform> context = GetNearbyObject(ws);
            Vector2 move = behaviour.CalculateMove(ws, context, this, m_player.transform);
            move *= speed;
            if (move.sqrMagnitude > squareMaxSpeed)
                move = move.normalized * max_speed;
            ws.Move(move);
        }
    }

    List<Transform> GetNearbyObject(Wurm agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighbour_radius);
        foreach (Collider2D c in contextColliders)
        {
            if (c != agent.RigBody)
                context.Add(c.transform);
        }
        return context;
    }

}
