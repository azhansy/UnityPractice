using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform BallTransorm;

    //球和相机之间的偏移量
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 ballPosition = BallTransorm.position;

        //计算 偏移量
        offset = transform.position - ballPosition;
    }

    private void LateUpdate()
    {
        transform.position = BallTransorm.position + offset;
    }
}
