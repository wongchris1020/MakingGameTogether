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
			transform.parent.GetComponent<CombatDummyController>().Damage(1f);
			Destroy(collision.gameObject);
		}
	}
}
