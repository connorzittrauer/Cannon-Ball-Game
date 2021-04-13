using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPivot : MonoBehaviour
{

    public GameObject player;
    private Vector2 robotPosition;
    static public int option;
    public int diffSetting = 0;

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
        //easy mode
        if (diffSetting == 1)
        {
            Pivot(-10, 10);
        }
        //medium
        else if (diffSetting == 2)
        {
            Pivot(-5, 5);
        }
        //hard
        else
        {
            Pivot(3, 3);
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
