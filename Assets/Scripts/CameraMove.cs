using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private float m_cameraSpeed;
    [SerializeField]
    private Vector2 m_limitVec;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posx = Camera.main.transform.position.x;
        float posy = Camera.main.transform.position.y;
        float deltaSpeed = m_cameraSpeed * Time.deltaTime;

        bool isHorizontalClamped = posx + Input.GetAxisRaw("Horizontal") * deltaSpeed > m_limitVec.x || posx + Input.GetAxisRaw("Horizontal") * deltaSpeed < (m_limitVec.x * -1.0f);
        bool isVerticalClamped = posy + Input.GetAxisRaw("Vertical") * deltaSpeed > m_limitVec.y || posy + Input.GetAxisRaw("Vertical") * deltaSpeed < (m_limitVec.y * -1.0f);

        float modifiedx = isHorizontalClamped ? 0.0f : Input.GetAxisRaw("Horizontal") * deltaSpeed;
        float modifiedy = isVerticalClamped ? 0.0f : Input.GetAxisRaw("Vertical") * deltaSpeed;

        Camera.main.transform.Translate(modifiedx, modifiedy, 0);
    }
}
