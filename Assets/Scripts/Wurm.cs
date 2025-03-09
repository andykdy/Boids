using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Wurm : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigBody;
    public Rigidbody2D RigBody => m_rigBody;

    [SerializeField]
    private float m_speedConst;

    [SerializeField]
    private float m_rotConst;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool isWallChecked = CheckWallRotation();
        if (!isWallChecked)
        {
            m_rigBody.MovePositionAndRotation(m_rigBody.position + (Vector2)transform.up * m_speedConst, m_rigBody.rotation);
        }
    }

    bool CheckWallRotation()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1.0f);
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Quaternion.Euler(0, -30, 0) * Vector2.up, 1.0f);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Quaternion.Euler(0, 30, 0) * Vector2.up, 1.0f);
        if (hit || leftHit || rightHit)
        {
            if (leftHit && !rightHit)
            {
                m_rigBody.MovePositionAndRotation(m_rigBody.position + (Vector2)transform.up * m_speedConst, m_rigBody.rotation + m_rotConst);
            }else if (rightHit && !leftHit)
            {
                m_rigBody.MovePositionAndRotation(m_rigBody.position + (Vector2)transform.up * m_speedConst, m_rigBody.rotation - m_rotConst);
            }
            else
            {
                m_rigBody.MovePositionAndRotation(m_rigBody.position + (Vector2)transform.up * m_speedConst, m_rigBody.rotation + m_rotConst);
            }
            return true;

        }
        else
        {
            return false;
        }
    }
}
