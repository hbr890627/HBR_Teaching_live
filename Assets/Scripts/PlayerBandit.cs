using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBandit : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 500f;

    private bool isGrounded = true;
    [SerializeField]
    private int damage = 20;


    [SerializeField]
    float nextAttackTime;

    [SerializeField]
    float attackRate = 0.7f;

    public Transform attackpoint;
    public float attackradius;
    public LayerMask enemyLayer;

    public Animator animator;
    public Rigidbody2D rb2d;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move，動啦
        float movement = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movement * speed * Time.deltaTime, 0, 0);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // if (Mathf.Abs(rb2d.velocity.y) < 0.01)
            if (isGrounded == true)
                rb2d.AddForce(Vector2.up * jumpForce);
        }

        // 反轉圖片，讓人物面相對的方向
        if (movement != 0)
            transform.localScale = new Vector3(-movement, 1, 1);

        // Run Aimation，跑起來~
        animator.SetFloat("velocity", Mathf.Abs(movement * speed));

        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            if (nextAttackTime < Time.time)
            {
                Attack();
                nextAttackTime = Time.time + 1 / attackRate;
            }
        }
    }

    void Attack()
    {
        // 動畫
        animator.SetTrigger("attack");

        // 造成傷害
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackpoint.position, attackradius, enemyLayer);

        // for (int i = 0; i < enemies.Length; i++)
        // {
        //     var enemy = enemies[i];
        // }

        foreach (var enemy in enemies)
        {
            Debug.Log(enemy.name);
            // enemy.enabled = false;
            // enemy.gameObject.GetComponent<Enemy>().HP = 0;
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpoint.position, attackradius);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ground")
            isGrounded = true;
        // Debug.Log(other.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Ground")
            isGrounded = false;
    }
}
