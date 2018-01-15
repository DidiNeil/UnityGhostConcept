using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTracker : DualBehaviour
{
    #region Public Members

    public GameObject m_prefab;
    public TrackingData m_tracker;

    public GameObject m_player;
    public float m_speed = .5f;

    public int i = -1;

    #endregion

    #region Public void

    #endregion

    #region System

    protected override void Awake()
    {
        m_player = Instantiate(m_prefab);

        count = m_tracker.positions.Count;

        if (count > 0)
            i = 0;
        else
            i = -1;
    }

    private void FixedUpdate()
    {
        if (i < 0)
        {
            Vector3 newPos = m_player.transform.position;

            if ( Input.GetKey("down"))
                newPos.y -= m_speed;
            else if (Input.GetKey("up"))
                newPos.y += m_speed;
            else if (Input.GetKey("right"))
                newPos.x += m_speed;
            else if (Input.GetKey("left"))
                newPos.x -= m_speed;

            m_player.transform.position = newPos;

            m_tracker.positions.Add(newPos);
        }
        else if (i < count)
        {
            m_player.transform.position = m_tracker.positions[i];

            i++;
        }
        else
            m_tracker.positions.Clear();
    }

    #endregion

    #region Class Methods

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members


    private int count;

    #endregion
}
