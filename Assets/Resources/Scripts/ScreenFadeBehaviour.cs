using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFadeBehaviour : MonoBehaviour
{
    public float fadeFromBlackOnStartDuration = 0.5f;

    private Image m_image;
    private void Awake()
    {
        m_image = GetComponent<Image>();
    }

    public void Start()
    {
        Fade(0.5f, Color.black, Color.clear);
    }

    public Coroutine Fade(float duration, Color startColor, Color endColor)
    {
        return StartCoroutine(_Fade(duration, startColor, endColor));
    }
    private IEnumerator _Fade(float duration, Color startColor, Color endColor)
    {
        if (duration > 0)
        {
            float t = 0;
            while (t <= 1)
            {
                m_image.color = Color.Lerp(startColor, endColor, t);
                t += Time.deltaTime / duration;
                yield return null;
            }
            m_image.color = endColor;
        }
    }
}
