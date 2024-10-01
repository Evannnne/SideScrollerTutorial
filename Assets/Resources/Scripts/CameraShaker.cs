using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Camera m_camera;

    private Vector3 m_currentOffset;
    private Coroutine m_coroutine;

    public void Shake(float intensity, float duration)
    {
        if (m_coroutine != null) StopCoroutine(m_coroutine);
        m_coroutine = StartCoroutine(_Shake(intensity, duration));
    }
    private IEnumerator _Shake(float intensity, float duration)
    {
        float t = 0;
        while (t <= 1)
        {
            m_currentOffset = Random.onUnitSphere;
            m_currentOffset *= Mathf.Lerp(intensity, 0, t);
            t += Time.deltaTime / duration;
            yield return null;
        }
        m_currentOffset = Vector3.zero;
    }

    private void Update()
    {
        transform.localPosition = m_currentOffset;
        if (Input.GetKeyDown(KeyCode.T)) Shake(0.25f, 0.5f);
    }
}
