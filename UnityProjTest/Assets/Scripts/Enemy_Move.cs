using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;
	public float height;

	void Start ()
	{
		height = GetComponent<SpriteRenderer>().bounds.size.y / 2;
	}

	
	// Update is called once per frame
	void Update () 
	{
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			if (col.gameObject.transform.position.y > height + gameObject.transform.position.y)
			{
				Destroy (gameObject);
			} 
			else
			{
				Flip();
			}
		}
		else
		{
			Flip();
		}
	}

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }


}
