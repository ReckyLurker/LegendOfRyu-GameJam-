using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Pause_Resume : MonoBehaviour
{
    public Canvas canvas;
    bool isPause;
   
    void Start()
    {
        isPause = false;
        canvas.GetComponent<Canvas>().enabled = false;
    }

    
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.Escape) && !isPause)
     {
            isPause = true;
            canvas.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            return;
     }
     if(Input.GetKeyDown(KeyCode.Escape) && isPause)
     {
            
            isPause=false;
            Time.timeScale = 1f;
            canvas.GetComponent <Canvas>().enabled = false;
            return;
     }
    }
    public void Resume()
    {
        isPause = false;
        Time.timeScale = 1f;
        canvas.GetComponent<Canvas>().enabled = false;
        return;
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
