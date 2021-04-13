using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public Slider slider;
    public Text level;

    // Update is called once per frame
    void Update()
    {
        
        if (slider.value == 1)
        {
            level.text = "Easy";
            PlayerPrefs.SetInt("difficultyKey", 1);
        }
        else if (slider.value == 2)
        {
            level.text = "Medium";
            PlayerPrefs.SetInt("difficultyKey", 2);
        }
        else
        {
            PlayerPrefs.SetInt("difficultyKey", 3);
            level.text = "Hard";
        }



    }
}
