using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPivot : MonoBehaviour
{

    public GameObject player;
    private Vector2 robotPosition;
    static public int option;
    public int diffSetting = 0;

    public int easyMin, easymax, medMin, medMax, hardMin, hardMax;
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
        //easy mode -10, 10
        if (diffSetting == 1)
        {
            Pivot(easyMin, easymax);
        }
        //medium -5, 5
        else if (diffSetting == 2)
        {
            Pivot(medMin, medMax);
        }
        //hard 3, 3
        else
        {
            Pivot(hardMin, hardMax);
        }

    }

    private void Pivot(int min, int max)
    {
        int offset = Random.Range(min, max);
        robotPosition = player.transform.position;
        
        //target position vector, add offset of +5 for hard mode
        Vector2 targetPosition = new Vector2(robotPosition.x, robotPosition.y + offset);

        //needs to transform the rotation only only on z-axis
        transform.right = targetPosition - (Vector2)this.transform.position; 
        
        Debug.Log(diffSetting);

    }


       


}
