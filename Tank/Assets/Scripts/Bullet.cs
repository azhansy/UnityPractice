using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }

    //触发检测到
    private void OnTriggerEnter2D(Collider2D collosion)
	{
		switch (collosion.tag)
		{
			case "Tank":
				collosion.SendMessage("Die");
				break;
			case "Heart":  
				break;
			case "Enemy":
				break;
			case "Wall":
				break;
			case "Barriar":
				break;
			default:
				break;
		}
	}
}
