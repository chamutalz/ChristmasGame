using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPopUp : MonoBehaviour
{
	public void Quit()
	{
		Application.Quit();
	}

	public void Restart()
	{
		SceneManager.LoadScene("Level1");
		gameObject.SetActive(false);
		PlayerData.lives = 3;
		PlayerData.levelCount = 1;
		PlayerData.score = 0;
	}
}
