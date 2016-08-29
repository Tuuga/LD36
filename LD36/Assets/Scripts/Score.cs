using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

// How to use:
// Put only 1 object in scene with Score component.
// Call Score.system.AddPoints() when player scores points.
// When player moves between stages, call Score.system.OnStageStart()
// and Score.system.OnStageEnd() as appropriate.
// Combined stage score is maintained in Score.system.totalScore (read only).
// Remember to also end last stage if you want it counted into the total score.

public class Score : MonoBehaviour {
    public static Score system { get; private set; }
    public Text pointsText;
    public Text timerText;
    public Text stageSummaryText;
    public float stageSummaryDuration;
    public float totalScore { get; private set; }
    int pointsOnStage;
    float timeOnStage;
    bool stageActive;
    const string timerFormat = "F2";

    public void AddPoints(int increment) {
        // TODO: responsiveness from animation, sound effect, ?
        pointsOnStage += increment;
    }

    public void OnStageStart() {
        stageActive = true;
        pointsOnStage = 0;
        timeOnStage = 0.0f;
    }

    public void OnStageEnd() {
        stageActive = false;
        totalScore += GetStageScore();

        pointsText.text = "";
        timerText.text = "";
        stageSummaryText.text =
            "Stage clear!" +
            "\nTime: " + timeOnStage.ToString(timerFormat) +
            "\nPoints: " + pointsOnStage +
            "\nTotal: " + GetStageScore();
        Invoke("StageSummaryExit", stageSummaryDuration);
    }

    float GetStageScore() {
        return pointsOnStage / timeOnStage;
    }

    void StageSummaryExit() {
        stageSummaryText.text = "";
    }

    void UpdatePointsAndTimer() {
        pointsText.text = "" + pointsOnStage;
        timerText.text = "" + timeOnStage.ToString(timerFormat);
    }
    void Awake() {
        if (system != null) {
            Debug.LogError("More than one score system in scene");
        } else {
            system = this;
        }
        pointsText = GameObject.Find("PointsText").GetComponent<Text>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        pointsText.text = "";
        timerText.text = "";
        stageSummaryText.text = "";
    }

    void Update() {
        if (stageActive) {
            timeOnStage += Time.deltaTime;
            UpdatePointsAndTimer();
        }
    }
}
