using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OffScreen : MonoBehaviour
{
    private int index;

    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex + 1;    
    }
    //once the character is knocked off the map, change scenes
    void OnBecameInvisible()
    {
        StartCoroutine(DelayChangeScene());
        
    }

    public IEnumerator DelayChangeScene()
    {
        yield return new WaitForSeconds(1);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(index);
    }
}
