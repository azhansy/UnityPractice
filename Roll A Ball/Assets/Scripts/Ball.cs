using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    // 对 自身的刚体组建对象
    public Rigidbody rd;
    public float mult;
    private int count;
    private int countBox;

    //游戏开始的时候调用
    void Start()
    {
        print("Start======");
        countBox = GameObject.FindGameObjectsWithTag("Box").Length;
        //rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("Update====");
        //rd.velocity 刚体的速度
        //w s 前后 一般是z轴
        //获取水平轴和垂直轴  的按键值
        float hValue = Input.GetAxis("Horizontal");
        float vValue = Input.GetAxis("Vertical");
        //xyz
        Vector3 speed = new Vector3(hValue, rd.velocity.y, vValue);
        //print(speed);
        rd.velocity = speed * mult;
    }


    //当碰撞器检测到碰撞时 就会触发
    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.collider.name);
        if (collision.collider.tag == "Box")
        {
            count++;
            //Destroy(collision.collider.gameObject);
            collision.collider.gameObject.SetActive(false);
            if(count >= countBox)
            {
                print("Game Over");

            }
        }
    }

}
