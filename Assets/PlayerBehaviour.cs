using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 16;
    public float jumpVelocity = 10;
    public float health = 100;

    private SpriteRenderer m_spriteRenderer;
    private Rigidbody2D m_rigidbody;
    private Animator m_animator;

    private bool m_canBeDamaged = true;

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }
}
