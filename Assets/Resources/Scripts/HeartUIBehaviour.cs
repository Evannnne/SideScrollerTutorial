using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUIBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite m_onSprite;
    [SerializeField] private Sprite m_offSprite;

    [SerializeField] private Image[] m_heartSprites;
    private PlayerBehaviour m_player;

    private void Awake()
    {
        m_player = FindObjectOfType<PlayerBehaviour>();
    }
    private void Update()
    {
        for(int i = 0; i < m_heartSprites.Length; i++)
        {
            m_heartSprites[i].sprite = m_player.health >= (i + 1) ? m_onSprite : m_offSprite;

        }
    }
}
