
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	private void Awake()
	{
		GameObject[] obj = GameObject.FindGameObjectsWithTag("Audio");
		if (obj.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
	}
}
