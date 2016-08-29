using UnityEngine;
using System.Collections;

public class StageStartTrigger : MonoBehaviour {
    void OnTriggerEnter(Collider c) {
        Score.system.OnStageStart();
        gameObject.SetActive(false);
    }
}
