using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    private int choice = 1;
    public GameObject pos1;
    public GameObject pos2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = pos1.transform.position;
            choice = 1;
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = pos2.transform.position;
            choice = 2;

            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
