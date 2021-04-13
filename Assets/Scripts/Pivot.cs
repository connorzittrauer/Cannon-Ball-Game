using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public Vector2 direction;
    // public Camera cam;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        // cam = Camera.main;

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPosition = transform.position;

        direction = mousePosition - bowPosition;
        
        transform.right = direction;

    }


}
