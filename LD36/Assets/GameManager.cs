using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject fadeObject;
	Animator fadeAnim;
	Image fadeImage;

	GameObject player;
	PlayerController pc;

	void Start () {
		fadeAnim = fadeObject.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		pc = player.GetComponent<PlayerController>();

		// Start seq
		fadeAnim.Play("FadeIn");
		// Play sound
	}

	public void GameOver () {
		fadeAnim.Play("FadeOut");
	}
}
