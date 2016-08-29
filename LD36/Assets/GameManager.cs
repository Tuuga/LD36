using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject fadeObject;
	public float fadeInAt;
	Animator fadeAnim;
	Image fadeImage;

	GameObject player;
	PlayerController pc;

	bool startFade;

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
	}

	public void GameOver () {
		fadeAnim.Play("FadeOut");
	}
}
