using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A pre-included class that causes a game win animation
public class YouWinUIBehaviour : MonoBehaviour
{
    private Image m_image;
    private ScreenFadeBehaviour m_fader;
    private void Awake()
    {
        m_fader = FindObjectOfType<ScreenFadeBehaviour>();
        m_image = GetComponentInChildren<Image>();
    }

    public void RunWinRoutine()
    {
        StartCoroutine(_WinRoutine());
    }
    private IEnumerator _WinRoutine()
    {
        for(int i = 0; i < 3; i++)
        {
            m_image.enabled = false;
            yield return new WaitForSeconds(0.25f);
            m_image.enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
        m_fader.Fade(0.5f, Color.clear, Color.black);
    }
}
