using UnityEngine;
using System.Collections;

public class StageEndTrigger : MonoBehaviour {
    void OnTriggerEnter(Collider c) {
        Score.system.OnStageEnd();
        gameObject.SetActive(false);
    }
}
