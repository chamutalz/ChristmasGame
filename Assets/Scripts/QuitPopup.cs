using UnityEngine;

public class QuitPopup : MonoBehaviour
{
	public void Continue()
	{
		gameObject.SetActive(false);
	}

	public void Quit()
	{
		Application.Quit();
	}	
	
}
