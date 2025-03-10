using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float steer_mag = 100f;

    private float speed;
    private float momentum_rate;
    private float momentum_max;
    private Vector2 momentum = Vector2.zero;
    private static float base_rate = 0.01f;

    private bool m_gameManagerOverride;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = gameObject.GetComponent<Rigidbody2D>();
        speed = 0.12f;
        momentum_max = speed / 2.0f;
        momentum_rate = base_rate;
        m_gameManagerOverride = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gameManagerOverride)
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 targetVec = new Vector2(moveHorizontal, moveVertical);
        if (targetVec.magnitude != 0.0f)
        {
            rgbd.transform.rotation =
                Quaternion.RotateTowards(rgbd.transform.rotation, Quaternion.LookRotation(Vector3.forward, targetVec), steer_mag);
            Vector2 move = Vector2.up * speed;
            rgbd.transform.Translate(move + momentum);
            momentum += move.magnitude + momentum.magnitude + momentum_rate > momentum_max ? Vector2.zero : new Vector2(0.0f, momentum_rate);
        }
        else
        {
            if (momentum.y > 0)
            {
                momentum.y -= momentum_rate;
                momentum_rate += momentum_rate * 0.5f;
            }
        }
    }

    public void OverridePlayerMovement(bool managerOverride)
    {
        m_gameManagerOverride = managerOverride;
    }
}