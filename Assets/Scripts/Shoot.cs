using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    public GameObject missile;
    public float launchForce = 0;
    public float timer = 0.0f;
    public Transform shotPoint;

    public UnityEvent monsterTrigger;    
    public bool canShoot;
    public bool hasFired;    

    public Text shellCount;
    private int count;
    private int diffSetting;

    // Start is called before the first frame update
    void Start()
    {
        diffSetting = PlayerPrefs.GetInt("difficultyKey");

                //initialize onscreen text
        if (diffSetting == 1)
        {
            shellCount.text = "3";
            count = 3;
            
        }
        else if (diffSetting == 2)
        {
            shellCount.text = "2";
            count = 2;
        }
        else
        {
            shellCount.text = "1";
            count = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasFired == false)
        {
            Shooting();    
        }
            


    }
    void Shooting()
    {
        
        if (Input.GetMouseButton(0))
        {
            //Calculate the amount of time the button is held
            

            timer += Time.deltaTime * 10.0f;
            launchForce = timer;

            //20 is the launchforce limit
            if (launchForce > 20.0f)
            {
                launchForce = 20.0f;
            }
        }
        if (Input.GetButtonUp("Fire1"))
            {

            GameObject newMissile = Instantiate(missile, shotPoint.position, shotPoint.rotation);
            newMissile.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

            //reset to 0 for next fire
            timer = 0.0f;
            launchForce = 0;


        //initialize onscreen text
        if (diffSetting == 1)
        {   
            
            shellCount.text = "3";
            Debug.Log("Count: " + count);
            count -= 1;
            shellCount.text = (count.ToString());
            if (count == 0)
            {
                StartCoroutine(DelayChangeScene());
            }
        }

        else if (diffSetting == 2)
        {   
            
            shellCount.text = "2";
            Debug.Log("Count: " + count);
            count -= 1;
            shellCount.text = (count.ToString());
            if (count == 0)
            {
                StartCoroutine(DelayChangeScene());
            }
        }

        else
        {
            shellCount.text = "1";
            Debug.Log("Count: " + count);
            count -= 1;
            shellCount.text = (count.ToString());
            monsterTrigger.Invoke();

        }
            
            
        if (count != 0)
        {
            monsterTrigger.Invoke();
        }
            
            
                hasFired =  true;
        }
        
        
        

    }

    public void Unlock()
    {
        hasFired = false;
      
    }


    public IEnumerator DelayChangeScene()
    {
        yield return new WaitForSeconds(4);
        LoadNextScene();
    }


    private void LoadNextScene()
    {
        SceneManager.LoadScene(4);
    }
    

}