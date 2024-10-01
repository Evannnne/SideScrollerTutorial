using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 16;
    public float jumpVelocity = 10;
    public bool canMove = true;

    private SpriteRenderer m_spriteRenderer;
    private Rigidbody2D m_rigidbody;
    private Animator m_animator;
    
    private CameraShaker m_shaker;
    private ScreenFadeBehaviour m_fader;

    private bool m_canBeDamaged = true;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        m_shaker = FindObjectOfType<CameraShaker>(); // Only do this once (if at all!)
        m_fader = FindObjectOfType<ScreenFadeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        bool ground = false;
        float hMove = 0;

        // Check if touching the ground
        var colliders = Physics2D.OverlapBoxAll((Vector2)transform.position + Vector2.down * 0.1f, new Vector3(0.45f, 1, 1), 0);
        foreach (var c in colliders)
            if (c.gameObject != gameObject)
                ground = true;

        // Handle movement
        if (canMove)
        {
            // Create a horizontal movement vector
            hMove = Input.GetAxisRaw("Horizontal") * movementSpeed;

            // Handle jumps
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) && ground)
                if (ground) m_rigidbody.AddForce(new Vector2(0, jumpVelocity * m_rigidbody.mass), ForceMode2D.Impulse);

        }

        // Set velocity
        var ve = m_rigidbody.velocity;
        ve.x = hMove;
        m_rigidbody.velocity = ve;

        // Set animator values
        m_animator.SetBool("Grounded", ground);
        m_animator.SetBool("Moving", hMove != 0);

        // Flip
        if (hMove != 0) m_spriteRenderer.flipX = hMove < 0 ? true : false;
    }

    public void Damage(float dmg)
    {
        if (m_canBeDamaged)
        {
            health -= dmg;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                m_shaker.Shake(0.25f, 0.25f);
                StartCoroutine(_FlashRed());
            }
        }
    }

    private void Die()
    {
        StartCoroutine(_Die());
    }

    IEnumerator _Die()
    {
        canMove = false;
        yield return m_fader.Fade(0.125f, Color.clear, Color.red);
        yield return m_fader.Fade(0.375f, Color.red, Color.black);
        Application.LoadLevel(Application.loadedLevel);
    }

    IEnumerator _FlashRed()
    {
        m_canBeDamaged = false;
        for (int i = 0; i < 3; i++)
        {
            m_spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.5f / 6f);
            m_spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.5f / 6f);
        }
        m_canBeDamaged = true;
    }
}
