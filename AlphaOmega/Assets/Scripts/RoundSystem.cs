using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour {

    public int roundCounter;
    public string roundPhase;
    private bool isFinished = false;

    // Use this for initialization
    void Start() {
        roundCounter = 1;
        roundPhase = "Night";

    }

    // Update is called once per frame
    void Update() {
        if (isFinished) {
            ProceedToNextPhase();
        }
    }

    void ProceedToNextPhase() {
        if (isFinished && roundPhase == "Night")
        {
            roundPhase = "Dawn";
            isFinished = !isFinished;
        }

        else if (isFinished && roundPhase == "Dawn")
        {
            roundPhase = "Day";
            isFinished = !isFinished;
        }

        else if (isFinished && roundPhase == "Day")
        {
            roundCounter += 1;
            roundPhase = "Night";
            isFinished = !isFinished;

            if (GameObject.Find("Portal").GetComponent<MonsterSummoning>().portalPower == 20) {
                GameObject.Find("Portal").GetComponent<MonsterSummoning>().evilWin = true;
            }
        }
    }
}
