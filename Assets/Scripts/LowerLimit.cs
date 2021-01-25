using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerLimit : MonoBehaviour
{	
	private void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if(otherCollider.tag == "Player")
		{
			PlayerData.lives--;
			otherCollider.GetComponent<Player>().pleaseSpawn = true;
		}
		otherCollider.gameObject.SetActive(false);
	}
}
