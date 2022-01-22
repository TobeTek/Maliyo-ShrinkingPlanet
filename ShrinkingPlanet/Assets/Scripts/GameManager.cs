using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject gameOverUI;

	void Awake ()
	{
		instance = this;
	}

	public void EndGame ()
	{
		gameOverUI.SetActive(true);
		HighScoreManager.instance.UpdateHighScoreData(Planet.Score);
	}

	public void Restart ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
