using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public GameManager gameManager;


    [SerializeField]
    private int HP = 100;

    [SerializeField]
    private HealthBar healthBar;


    [SerializeField]
    private GameObject bloodEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        GetComponent<Animator>().SetTrigger("hurt");
        healthBar.SetHealthBar(HP);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        Debug.Log(HP);
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // gameObject.SetActive(false);
        // Destroy(gameObject);
        Debug.Log("死惹");

        GameManager.instance.GameOver();
        // gameManager.GameOver();
        // Debug.Log("Game over");
    }
}
