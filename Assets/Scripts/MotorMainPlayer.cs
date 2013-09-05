using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotorMainPlayer : MonoBehaviour
{
    private GameObject m_player;
    private Animation m_playerAnim;
    private TweenMove m_playerController;
    private List<Transform> m_poses = new List<Transform>();
    private int m_curPos = 1;

    // Use this for initialization
    void Start()
    {
        m_poses.Add(transform.FindChild("Left"));
        m_poses.Add(transform.FindChild("Middle"));
        m_poses.Add(transform.FindChild("Right"));

        m_player = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
        m_playerController = m_player.AddComponent<TweenMove>();
        m_playerAnim = m_player.animation;
        m_playerAnim.Play("runforward");
        m_playerController.SetTarget(m_poses[m_curPos]);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.2f);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "left"))
        {
            if (m_curPos <= 0)
                return;
            m_playerController.SetTarget(m_poses[--m_curPos]);
        }
        if (GUI.Button(new Rect(100, 0, 100, 100), "right"))
        {
            if (m_curPos > m_poses.Count - 1)
                return;
            m_playerController.SetTarget(m_poses[++m_curPos]);
        }
    }

    public float acceleration = 2;
    public float speed = 4.0f;

    protected float AccelerateSpeed(float originalSpeed, float _targetSpeed)
    {
        if (Mathf.Abs(originalSpeed - _targetSpeed) < acceleration * Time.deltaTime)
        {
            originalSpeed = _targetSpeed;
        }
        else if (speed - _targetSpeed > 0)
        {
            originalSpeed -= acceleration * Time.deltaTime;
        }
        else
        {
            originalSpeed += acceleration * Time.deltaTime;
        }
        return originalSpeed;
    }

}
