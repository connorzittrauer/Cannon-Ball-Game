using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLose : MonoBehaviour
{
    public int diffSetting;
    public int count;
    public Text shellCounter;

    
    void Start()
    {
        diffSetting = PlayerPrefs.GetInt("difficultyKey");

        if (diffSetting == 1)
        {
            shellCounter.text = "5";
        }
        else if (diffSetting == 2)
        {
            shellCounter.text = "3";
        }

        else 
        {
            shellCounter.text = "1";
        }
    }
    //once the character is knocked off the map, change scenes
    void OnBecameInvisible()
    {
        StartCoroutine(DelayChangeScene());
        
    }

    public IEnumerator DelayChangeScene()
    {
        yield return new WaitForSeconds(2);
        LoadNextScene();
    }

    public void SetShell()
    {
        bool Shooting = true;
        while (Shooting)
        {
        //easy mode 5 shells
        if (diffSetting == 1)
        {
            count=5;
            count-=1;
            shellCounter.text = ("" + count);
            if (count==0) {SceneManager.LoadScene(4);}
        }

        //medium mode 3 shells        
        else if (diffSetting == 2)
        {
            count=3;
            count-=1;
            shellCounter.text = ("" + count);

            if (count==0){SceneManager.LoadScene(4);}
        }
        //hard mode 1 shell, symbolic really since in hard mode the monster kills you on first try
        else
        {
            shellCounter.text = "1";
        }    

        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(4);
    }
}
