using UnityEngine;
using System.Collections;

public class ScoreSystemDebug : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Score.system.AddPoints(100);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            Score.system.OnStageStart();
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            Score.system.OnStageEnd();
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            print("total score " + Score.system.totalScore);
        }
	}
}
