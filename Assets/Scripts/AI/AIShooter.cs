using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIShooter : MonoBehaviour
{
    public GameObject missile;
    public float launchForce = 0;
    public float timer = 0.0f;
    public Transform shotPoint;
    public UnityEvent playerTrigger;
    public bool hasFired;
    public int diffSetting = 0;

    public int easyMin, easymax, medMin, medMax, hardMin, hardMax;
    
    // Start is called before the first frame update
    void Start()
    {
        diffSetting = PlayerPrefs.GetInt("difficultyKey");
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void SetPivot()
    {


    }

    public void DelayShoot()
    {
        StartCoroutine(Delay ());
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);

        //easy mode
        if (diffSetting == 1)
        {
            //10, 20
            Shoot(easyMin, easymax);
            
        }
        //medium 15 20
        else if (diffSetting == 2)
        {
            Shoot(medMin, medMax);
        }
        //hard 20 20
        else
        {
            Shoot(hardMin, hardMax);
        }
        
     
    }

    public void Shoot(int min, int max)
    {
            //random launch force between 10-20
            launchForce = Random.Range(min, max);
         

            GameObject newMissile = Instantiate(missile, shotPoint.position, shotPoint.rotation);
            newMissile.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

            //reset to 0 for next fire
            timer = 0.0f;
            launchForce = 0;

            playerTrigger.Invoke();
            Debug.Log(diffSetting);
    }
}
