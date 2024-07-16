using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject [] Intro;
    int click = 0;
    public void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            Intro[i].SetActive(false);
        }
    }

    public void Update()
    {
        if(click == 1)
        {
            Intro[2].SetActive(true);
            Intro[0].SetActive(true);
        }
        else if(click == 2)
        {
            Intro[1].SetActive(true);
        }
        else if(click == 3)
        {
            SceneManager.LoadScene("Main");
            click = 0;
        }
    }
    
    public void Click()
    {   
        click++;
    }
}
