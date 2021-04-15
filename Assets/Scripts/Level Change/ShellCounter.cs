using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShellCounter : MonoBehaviour
{

    public int diffSetting;
    public Text shellCount;
    public int easyCount;
    // Start is called before the first frame update
    void Start()
    {
        
        diffSetting = PlayerPrefs.GetInt("difficultyKey");

        //initialize onscreen text
        if (diffSetting == 1)
        {
            shellCount.text = "5";
            
        }
        else if (diffSetting == 2)
        {
            shellCount.text = "3";
        }
        else
        {
            shellCount.text = "2";
        }

    }

    void update()
    {
        
        if (Input.GetButtonUp("Fire1") && diffSetting == 1)
        {
            easyCount = 5;
            Debug.Log(easyCount);
            easyCount= easyCount - 1;
            shellCount.text = (easyCount.ToString());
        }




    }


}
