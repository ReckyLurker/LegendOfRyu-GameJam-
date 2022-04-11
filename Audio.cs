using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip menu;
    private AudioSource Audiosource;
    void Start()
    {
        Audiosource = GetComponent<AudioSource>();
        Audiosource.clip = menu;
        Audiosource.loop = true;
        Audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
