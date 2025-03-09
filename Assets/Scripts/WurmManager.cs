using System.Collections.Generic;
using UnityEngine;

public class WurmManager : MonoBehaviour
{
    public Wurm WurmPrefab;

    [SerializeField]
    private int m_startNum = 10;

    private const float agent_density = 0.08f;

    [Range(1f, 10f)] public float neighbour_radius = 1.5f;
    [Range(0f, 1f)] public float avoidance_radius_mult = 0.5f;


    private List<Wurm> agents = new List<Wurm>();

    private float squareNeighbourRadius;
    private float squareAvoidRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
