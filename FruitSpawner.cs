using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject apple;
    public float MaxDistance, MinDistance,SpawnX;
    public float WaitTime,MaxWaitTime,MinWaitTime;
    float counter;
    GameObject n;
    private void Start()
    {
        WaitTime = Random.value*(MaxWaitTime-MinWaitTime)+MinWaitTime;
        SpawnX  = Random.value*(MaxDistance-MinDistance)+MinDistance;
        counter = WaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter >= WaitTime)
        {
            counter = 0;
            n = Instantiate(apple, new Vector3(SpawnX,-4.28f,0f),Quaternion.Euler(0f,0f,21f));
            n.transform.localScale = new Vector3(0.2f,0.2f,1f);
            WaitTime = Random.value * (MaxWaitTime - MinWaitTime) + MinWaitTime;
            SpawnX = Random.value * (MaxDistance - MinDistance) + MinDistance;
            n.AddComponent<apple>();
            Debug.Log("Apple Spawned");
            return;
        }
        if(counter < WaitTime)
        {
            counter += Time.deltaTime;
        }
    }
   
}
