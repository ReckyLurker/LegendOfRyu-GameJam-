using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //-9 or +8 
    //int n -> no of enemies 
    //Speed
    //Animator
    //Dist 1 -lt Start Attacking
    public GameObject player;
    float health = 100;
    public GameObject mover;
    public bool canSpawn;
    GameObject n,x;
    int number;
    //Wait BOOL
    private void Start()
    {
        canSpawn = false;
        number = 1;
        n = Instantiate(mover, new Vector3(-8f, -4.34f, 0f), Quaternion.identity);
        n.AddComponent<Enemy>();
        n.GetComponentInChildren<Enemy>().player = player.GetComponent<Rigidbody2D>();
        n.GetComponentInChildren<Enemy>().enemy = n.GetComponent<Rigidbody2D>();
        n.GetComponentInChildren<Enemy>().health = health;
        n.GetComponentInChildren<Enemy>().parent = n;
        n.GetComponentInChildren<Enemy>().PDamage = 10f;
        health += 10;
    }
    private void Update()
    {
        if(canSpawn)
        {
            number += 1;
            for (int i = 0; i < number; i++)
            {
                if (Random.value <= 0.5f)
                {
                    n = Instantiate(mover, new Vector3(-8f, -4.34f, 0f), Quaternion.identity);
                    n.AddComponent<Enemy>();
                    n.GetComponentInChildren<Enemy>().player = player.GetComponent<Rigidbody2D>();
                    n.GetComponentInChildren<Enemy>().enemy = n.GetComponent<Rigidbody2D>();
                    n.GetComponentInChildren<Enemy>().parent = n;
                    n.GetComponentInChildren<Enemy>().health = health;
                    n.GetComponentInChildren<Enemy>().PDamage = 10f;
                }
                else
                {
                    n = Instantiate(mover, new Vector3(8f, -4.34f, 0f), Quaternion.identity);
                    n.AddComponent<Enemy>();
                    n.GetComponentInChildren<Enemy>().player = player.GetComponent<Rigidbody2D>();
                    n.GetComponentInChildren<Enemy>().enemy = n.GetComponent<Rigidbody2D>();
                    n.GetComponentInChildren<Enemy>().parent = n;
                    n.GetComponentInChildren<Enemy>().health = health;
                    n.GetComponentInChildren<Enemy>().PDamage = 10f;

                }
            }
            health += 10;
            canSpawn = false;
        }
    }
}
