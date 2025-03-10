using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Wurm : MonoBehaviour
{
    [SerializeField]
    private Collider2D m_rigBody;
    public Collider2D RigBody => m_rigBody;

    [SerializeField]
    private WurmManager m_manager;
    public WurmManager Manager => m_manager;

    [SerializeField]
    private float m_speedConst;

    [SerializeField]
    private float m_rotConst;

    void Start()
    {
        m_rigBody = GetComponent<Collider2D>();
    }

    public void Initialize(WurmManager wManager)
    {
        m_manager = wManager;
    }

    public void Move(Vector2 vel)
    {
        transform.up = vel;
        transform.position += (Vector3)vel * Time.deltaTime;
    }
}
