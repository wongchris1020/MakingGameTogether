using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyGetHit : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("PlayerBullet"))
		{
			Debug.Log("hit");
			Destroy(collision.gameObject);
		}
	}
}
