using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject quitText;
	public GameObject fadeObject;
	public float fadeInAt;
	Animator fadeAnim;
	Image fadeImage;

	GameObject player;
	PlayerController pc;

	bool startFade;
	bool gameOver;

	void Start () {
		fadeAnim = fadeObject.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		pc = player.GetComponent<PlayerController>();

		// Start seq
		Fabric.EventManager.Instance.PostEvent("StartDialog");
	}

	void Update () {
		if (Time.time >= fadeInAt && !startFade) {
			fadeAnim.Play("FadeIn");
			startFade = true;
		}

		// Restart
		if (gameOver) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				SceneManager.LoadScene(0);
			}
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Application.Quit();
			}
		}		
	}

	public void GameOver () {
		fadeAnim.Play("FadeOut");
		quitText.SetActive(true);
		gameOver = true;
	}

	void OnTriggerEnter(Collider c) {
		if (c.tag == "Player" && !gameOver) {
			GameOver();
		}
	}
}
