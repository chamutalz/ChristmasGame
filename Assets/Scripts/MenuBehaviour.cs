using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
	public GameObject aboutCanvas;

   public void StartGame()
	{
		SceneManager.LoadScene("Level1");
	}

	public void About()
	{
		aboutCanvas.SetActive(true);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void CloseAbout()
	{
		aboutCanvas.SetActive(false);
	}
}
