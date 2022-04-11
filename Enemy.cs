using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public bool isBeingAttacked;
    public Rigidbody2D player;
    public Rigidbody2D enemy;
    public GameObject parent;
    Animator animator;
    float WaitTime = 2f;
    float counter;
    float Speed = 1.5f;
    public float Damage = 10f;
    public float PDamage;
    public bool Attack;
    private void Start()
    {
        isBeingAttacked = false;
        animator = GetComponentInChildren<Animator>();
       
        counter = WaitTime;
      
     
    }
    private void Update()
    {
        if (health > 0)
        {
            if (counter < WaitTime)
            {
                counter += Time.deltaTime;
            }
            if (counter >= WaitTime)
            {
                counter = 0;
                if (player.position.x > enemy.position.x && Mathf.Abs(player.position.x - enemy.position.x) > 0.7f)
                {
                    Debug.Log("Ahead");
                    Attack = false;
                    enemy.transform.localScale = new Vector3(-0.6f, enemy.transform.localScale.y, enemy.transform.localScale.z);
                    enemy.velocity = new Vector2(Speed, 0);
                    Debug.Log("Transformed");
                }
                if (player.position.x < enemy.position.x && Mathf.Abs(player.position.x - enemy.position.x) > 0.7f)
                {
                    Debug.Log("Behind");
                    Attack = false;
                    enemy.transform.localScale = new Vector3(0.6f, enemy.transform.localScale.y, enemy.transform.localScale.z);
                    enemy.velocity = new Vector2(-Speed, 0);
                    Debug.Log("Transformed");
                }
                if (player.position.x > enemy.position.x && Mathf.Abs(player.position.x - enemy.position.x) < 0.7f)
                {
                    Debug.Log("Ahead");
                    Attack = true;
                    enemy.transform.localScale = new Vector3(-0.6f, enemy.transform.localScale.y, enemy.transform.localScale.z);
                    enemy.velocity = Vector2.zero;
                    Debug.Log("Transformed");
                }
                if (player.position.x < enemy.position.x && Mathf.Abs(player.position.x - enemy.position.x) < 0.7f)
                {
                    Debug.Log("Behind");
                    Attack = true;
                    enemy.transform.localScale = new Vector3(-0.6f, enemy.transform.localScale.y, enemy.transform.localScale.z);
                    enemy.velocity = Vector2.zero;
                    Debug.Log("Transformed");
                }
               
                return;
            }
            if(enemy.position.x >= 8f)
            {
                enemy.position = new Vector2(-8f, 0);
            }
            animator.SetFloat("Velocity", enemy.velocity.x);
            animator.SetFloat("Health", health);
            animator.SetFloat("Dist2Player", Mathf.Abs(player.position.x - enemy.position.x));

        }
        else
        {
            if(counter < 5f)
            {
                counter += Time.deltaTime;
            }
            if(counter >=5f)
            {
                FindObjectOfType<EnemySpawner>().canSpawn = true;
                Destroy(parent);
            }
        }
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Weapon") && health >0)
        {
            health -= PDamage;
        }
    }


}
