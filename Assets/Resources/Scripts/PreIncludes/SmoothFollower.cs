using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A pre-included script that allows smooth following of an object by a camera
public class SmoothFollower : MonoBehaviour
{
    public Transform target;
    public float minHeight = 0;
    public float maxHeight = 9999;
    public float lerpFactor = 10;

    public void Update()
    {
        if (target != null)
        {
            Vector3 targetPos = target.position;
            targetPos.y = Mathf.Clamp(targetPos.y, minHeight, maxHeight);
            targetPos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * lerpFactor);
        }
    }
}
