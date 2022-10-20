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

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create a horizontal movement vector
        float hMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        var ve = m_rigidbody.velocity;
        ve.x = hMove;
        m_rigidbody.velocity = ve;

        // Check if touching the ground
        bool ground = false;
        var colliders = Physics2D.OverlapBoxAll((Vector2)transform.position + Vector2.down * 0.1f, new Vector3(0.45f, 1, 1), 0);
        foreach (var c in colliders)
            if (c.gameObject != gameObject)
                ground = true;

        // Handle jumps
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) && ground) 
            if(ground) m_rigidbody.AddForce(new Vector2(0, jumpVelocity * m_rigidbody.mass), ForceMode2D.Impulse);

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
            if(health <= 0)
                Application.LoadLevel(Application.loadedLevel);
            else StartCoroutine(_Damage());
        }
    }
    IEnumerator _Damage()
    {
        m_canBeDamaged = false;
        m_spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        m_spriteRenderer.color = Color.white;
        m_canBeDamaged = true;
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(5, 0, 200, 200), $"Health: {health}", new GUIStyle { fontSize = 24, fontStyle = FontStyle.Bold });
    }
}
