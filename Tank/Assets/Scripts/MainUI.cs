using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{

    private int moveSpeed = 180;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MainUII start====");
      
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("update=>" + transform.position.y);
        if (transform.position.y < 447)
        {
            transform.Translate(new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime, Space.World);
        }
      
    }
}
