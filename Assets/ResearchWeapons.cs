using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResearchWeapons : MonoBehaviour {

    public List<GameObject> researchables;

    public void openWeaponsList() {
        foreach (GameObject researchOption in researchables) {
            if (researchOption.transform.GetChild(1).GetComponent<Text>().text == "Completed") {
                Debug.Log("ayo");
            }
        }
    }

}
