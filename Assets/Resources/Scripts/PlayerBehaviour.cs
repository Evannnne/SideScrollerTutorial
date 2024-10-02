using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerBehaviour : MonoBehaviour
{
    // This is where our variables go, let's add more!
    public float health;
    public bool canMove;

    public float movementSpeed = 10;
    public float jumpVelocity = 10;

    private SpriteRenderer m_renderer;
    private Rigidbody2D m_rigidbody;
    private Animator m_animator;

    private CameraShaker m_shaker;
    private ScreenFadeBehaviour m_fader;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_renderer = GetComponent<SpriteRenderer>();

        m_shaker = FindObjectOfType<CameraShaker>();
        m_fader = FindObjectOfType<ScreenFadeBehaviour>();

        canMove = true;
    }

    private void Update()
    {
        bool ground = false;
        float hMove = 0;

        if (canMove)
        {
            hMove = Input.GetAxisRaw("Horizontal") * movementSpeed;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                m_rigidbody.AddForce(new Vector2(0, jumpVelocity * m_rigidbody.mass), ForceMode2D.Impulse);
            }
        }

        Vector3 ve = m_rigidbody.velocity;
        ve.x = hMove;
        m_rigidbody.velocity = ve;

        m_animator.SetBool("Moving", hMove != 0);
        if (hMove != 0) m_renderer.flipX = hMove < 0;
    }

    // This function is a Stub, let's add to it!
    public void Damage(float dmg)
    {

    }
}
