using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class WellDoneBehaviour : MonoBehaviour
{
	int showScore;
	public Text finalScore;
	
    void Update()
    {
		showScore = PlayerData.score;
		finalScore.text = "Final Score: " + showScore.ToString();
    }

	public void Restart()
	{
		SceneManager.LoadScene("Level1");
		PlayerData.score = 0;
		PlayerData.lives = 3;
		PlayerData.levelCount = 1;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
