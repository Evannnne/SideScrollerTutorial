using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Vector3 targetOffset;
    public float speed = 1;

    private Vector3 m_startPosition;
    void Awake() => m_startPosition = transform.position;

    public void Update()
    {
        Vector3 p0 = m_startPosition;
        Vector3 p1 = m_startPosition + targetOffset;

        transform.position = Vector3.Lerp(p0, p1, Mathf.PingPong(Time.time * speed, 1));
    }
}
