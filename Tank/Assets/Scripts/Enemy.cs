using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //移动速度
    public float moveSpeed = 3;
    private Vector3 bulletEulerAngles;
    private float v;
    private float h;


    //引用
    private SpriteRenderer sr;
    public GameObject bulletPrefab;
    public GameObject explositionPrefab;

    public Sprite[] tankSprite; //上 右  下 左

    //计时器
    private float timeVal;
    private float timeYalChangeDirection = 4;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //攻击时间间隔
        if (timeVal >= 3)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }


    }

    private void FixedUpdate()
    {
        Move();
    }


    //坦克的攻击方法
    private void Attack()
    {
        //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
        timeVal = 0;
    }


    //坦克的移动方法
    private void Move()
    {

        if (timeYalChangeDirection>4)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if(num == 0)
            {
                v = 1;
                h = 0;
            }
            else if(num>0 && num <= 2)
            {
                v = 0;
                h = -1;
            }

            else if (num > 2 && num <= 4)
            {
                v = 0;
                h = 1;
            }
            timeYalChangeDirection = 0;
        }
        else
        {
            timeYalChangeDirection += Time.fixedDeltaTime;
        }


        //float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSprite[2];

            bulletEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }

        if (v != 0)
        {
            return;
        }

        //float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }
    }


    //坦克死亡方法
    private void Die()
    {

        PlayerManager.Instance.AddScore();

        //产生爆炸特效
        Instantiate(explositionPrefab, transform.position, transform.rotation);
        //死亡

        Destroy(gameObject);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            v *= -1;
            h *= -1;
            timeYalChangeDirection = 0;
           
        }

    }
}
