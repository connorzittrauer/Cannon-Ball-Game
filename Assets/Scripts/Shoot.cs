using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    public GameObject missile;
    public float launchForce = 0;
    public float timer = 0.0f;
    public Transform shotPoint;

    public UnityEvent monsterTrigger;    
    public bool canShoot;
    public bool hasFired;    
    public UnityEvent shellCounter;

    // Start is called before the first frame update
    void Start()
    {
        
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

            monsterTrigger.Invoke();
            
            shellCounter.Invoke();

            hasFired =  true;
            }
        
        
        

    }

    public void Unlock()
    {
        hasFired = false;
      
    }



    

}