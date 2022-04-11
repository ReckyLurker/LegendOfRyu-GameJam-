using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;
   
    [SerializeField] private float speed;
    [SerializeField] private float JumpSpeed;
    public Animator animator;
    int count;
   
    bool isJump;
 public bool isAttack;
    public float Health;
    float counter = 0;
    Vector2 velocity;
    private void Start()
    {
        counter = 0;
        count = 0;
      isJump = false;
     isAttack = false;
     
      
        Health = 100;
        
    }

    private void FixedUpdate()
    {

        if (Health > 0)
        {

            if (Input.GetKey(KeyCode.A))
            {
                velocity = new Vector2(-speed, player.velocity.y);
                player.velocity = velocity;
                // player.transform.Translate(new Vector3(-speed*Time.deltaTime, 0));
                animator.SetFloat("SpeedX", Mathf.Abs(velocity.x));
                player.transform.localScale = new Vector3(0.600000024f, 0.600000024f, 1);

            }
            if (Input.GetKey(KeyCode.D))
            {
                velocity = new Vector2(speed, player.velocity.y);
                player.velocity = velocity;
                //player.transform.Translate(new Vector3(speed*Time.deltaTime, 0));
                animator.SetFloat("SpeedX", Mathf.Abs(velocity.x));
                player.transform.localScale = new Vector3(-0.600000024f, 0.600000024f, 1);

            }
            if (Input.GetKeyDown(KeyCode.Space) && count < 1 && !isJump)
            {
                player.velocity = new Vector3(player.velocity.x, JumpSpeed, 0);
                count++;
                isJump = true;
            }
            if (Input.GetMouseButton(0))
            {
                isAttack = true;
               
            }
            if(FindObjectOfType<EnemySpawner>().canSpawn)
            {
                Health += 50;
            }
            if (FindObjectOfType<Enemy>().isBeingAttacked && isAttack)
            {
                Health -= FindObjectOfType<Enemy>().Damage;
            }
            animator.SetFloat("Health", Health);
            animator.SetFloat("SpeedX", Mathf.Abs(player.velocity.x));
            animator.SetFloat("SpeedY", Mathf.Abs(player.velocity.y));
            animator.SetBool("Jumping", isJump);
            animator.SetBool("Attack?", isAttack);
            isAttack = false;
        }
        else
        {
           
            if(counter <5f)
            {
                counter += Time.deltaTime;
            }
            else
            {
                counter = 0;
                SceneManager.LoadScene(2);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            count = 0;
            isJump=false;
        }
        if(collision.collider.CompareTag("Enemy") && isAttack)
        {
            FindObjectOfType<Enemy>().isBeingAttacked = true;
          
        }
        else
        {
            FindObjectOfType<Enemy>().isBeingAttacked = false;
        }
       
    }


}
