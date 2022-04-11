using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    float counter;
    private void Start()
    {
        counter = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            
        }
    }
    private void Update()
    {
        if(counter < 15f)
        {
            counter += Time.deltaTime;
        }
        else if(counter>=15f)
        {
            counter = 0;
            Destroy(gameObject);
        }
    }
}
