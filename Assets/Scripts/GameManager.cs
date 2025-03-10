using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerBehaviour PlayerPrefab => m_player;
    [SerializeField]
    private PlayerBehaviour m_player;

    public CameraMove MainCamera => m_camera;
    [SerializeField]
    private CameraMove m_camera;

    // Toggles WASD control between player and camera
    private bool m_isPlayerControl = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_camera.PlayerPosition = m_player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            m_isPlayerControl = !m_isPlayerControl;
            m_player.OverridePlayerMovement(!m_isPlayerControl);
            m_camera.OverrideCameraMovement(m_isPlayerControl);
        }
        m_camera.PlayerPosition = m_player.transform.position;

    }
}
