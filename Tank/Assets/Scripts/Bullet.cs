using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float moveSpeed = 10;

    public bool isPlayerBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }

    //触发检测到碰撞
    private void OnTriggerEnter2D(Collider2D collosion)
	{
      
        switch (collosion.tag)
		{

			case "Tank":
                if (!isPlayerBullet)
                {
                    collosion.SendMessage("Die");
                    Destroy(gameObject);
                }
				
				break;
			case "Heart":
                collosion.SendMessage("Die");
                Destroy(gameObject);
                break;
			case "Enemy":
                if (isPlayerBullet)
                {
                 
                    collosion.SendMessage("Die");
                    Destroy(gameObject);
                }
                else
                {
                    //敌人的子弹

                }
				break;
               //
			case "Wall":
                Destroy(collosion.gameObject);
                Destroy(gameObject);
				break;
                //刚墙
			case "Barrier":
                collosion.SendMessage("PlayAudio");
                Destroy(gameObject);
				break;
            case "PlayerBullet":
               
                if (!isPlayerBullet)
                {
                    Destroy(gameObject);
                }
                break;
            case "EnemyBullet":
                if (isPlayerBullet)
                {
                    Destroy(gameObject);
                }
                break;
            default:
				break;
		}
	}
}
