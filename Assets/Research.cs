using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Research : MonoBehaviour {

    GameObject temp;
    bool researchInProgress;
    int daysRemaining;
    int startDate;
    int daysSinceStart;

    public void newResearch() {
        if (!researchInProgress) {
            researchInProgress = true;
            daysRemaining = 50;
            startDate = (gameObject.GetComponent<TimeScript>().year - 1) * 365 + gameObject.GetComponent<TimeScript>().day;
            temp = EventSystem.current.currentSelectedGameObject;
            temp.GetComponent<Button>().interactable = false;
            temp.transform.GetChild(1).GetComponent<Text>().text = "Days Remaining: " + daysRemaining;
        }
    }

    void Update() {
        if (researchInProgress) {
            daysSinceStart = (gameObject.GetComponent<TimeScript>().year - 1) * 365 + gameObject.GetComponent<TimeScript>().day - startDate;
            daysRemaining = 50 - daysSinceStart;
            temp.transform.GetChild(1).GetComponent<Text>().text = "Days Remaining: " + daysRemaining;
            if (daysRemaining <= 0) {
                researchInProgress = false;
                temp.transform.GetChild(1).GetComponent<Text>().text = "Completed";
            }
        }
    }

}