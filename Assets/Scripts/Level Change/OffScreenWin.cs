using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OffScreenWin : MonoBehaviour
{

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

    private void LoadNextScene()
    {
        SceneManager.LoadScene(5);
    }
}