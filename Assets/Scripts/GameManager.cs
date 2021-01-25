using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject quitCanvas;
	Player player;
	public GameObject gameOverCanvas;
	public Text scoreT;
	public Text livesT;
	public Text levelT;
	Vector3 spawnPoint = new Vector3(-5.96f, -2.53f, 0f);
	AudioSource sceneAudio;
	[SerializeField]
	AudioClip[] sounds = new AudioClip[5];

	void Start()
    {
		player = FindObjectOfType<Player>();
		sceneAudio = FindObjectOfType<AudioSource>();
	}

    
    void Update()
	{
		scoreT.text = PlayerData.score.ToString();
		livesT.text = PlayerData.lives.ToString();
		levelT.text = PlayerData.levelCount.ToString();

		if(PlayerData.iglooSpawn != 0)
		{
			FromIgloo();
		}
		if (player.levelUp == true)
		{
			LevelUp();
		}
		if(player.enterIgloo == true)
		{
			EnterIgloo();
		}
		if(player.exitIgloo == true)
		{
			ExitIgloo();
		}
		if(player.crystal == true)
		{
			Crystal();
		}
		if(player.coin == true)
		{
			Coin();
		}if(player.extraLife == true)
		{
			ExtraLife();
		}

		if(player.snowed == true)
		{
			Snowed();
		}
		if(player.pleaseSpawn == true)
		{
			SpawnPlayer();
		}
		//quit game popup
		if (Input.GetKeyDown("escape"))
		{
			quitCanvas.SetActive(true);
		}
		if (PlayerData.lives <= 0)
		{
			GameOver();
		}
		if(player.wellDone == true)
		{
			WellDone();
		}
    }

	public void LevelUp()
	{
		PlaySFX(0);
		player.levelUp = false;
		PlayerData.score += 100;
		int nextLevelNum = PlayerData.levelCount + 1;
		string nextLevel = "Level" + nextLevelNum.ToString();
		player.transform.position = spawnPoint;
		SceneManager.LoadScene(nextLevel);
		PlayerData.levelCount++;
	}

	public void EnterIgloo()
	{
		string thisIgloo = "IglooL" + PlayerData.levelCount.ToString();
		Debug.Log(thisIgloo);
		SceneManager.LoadScene(thisIgloo);
		player.enterIgloo = false;
	}

	public void ExitIgloo()
	{
		string thisLevel = "Level" + PlayerData.levelCount.ToString();
		SceneManager.LoadScene(thisLevel);
		PlayerData.iglooSpawn = PlayerData.levelCount;
		player.exitIgloo = false;
	}

	public void Snowed()
	{
		PlayerData.lives--;
		PlaySFX(3);
		player.snowed = false;
	}

	public void GameOver()
	{
		player.gameObject.SetActive(false);
		gameOverCanvas.SetActive(true);
	}

	public void SpawnPlayer()
	{
		player.transform.position = spawnPoint;
		player.gameObject.SetActive(true);
		player.pleaseSpawn = false;
	}

	public void WellDone()
	{	
		SceneManager.LoadScene("WellDone");
	}

	public void Coin()
	{
		player.coin = false;
		PlayerData.score += 1;
		PlaySFX(1);
	}

	public void ExtraLife()
	{
		player.extraLife = false;
		PlayerData.lives++;
		PlaySFX(4);
	}

	public void Crystal()
	{
		player.crystal = false;
		PlayerData.score += 5;
		PlaySFX(2);
	}

	public void PlaySFX(int sfx)
	{
		sceneAudio.PlayOneShot(sounds[sfx]);

	}

	public void FromIgloo()
	{	if(PlayerData.iglooSpawn == 1)
		{
			player.transform.position = new Vector3(20.6f, -2.5812f, 0f);
		}
		else if(PlayerData.iglooSpawn == 2)
		{
			player.transform.position = new Vector3(49.44f, -2.5812f, 0f);

		}
		PlayerData.iglooSpawn = 0;
	}
}
