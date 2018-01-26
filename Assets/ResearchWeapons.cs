using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResearchWeapons : MonoBehaviour {

    [SerializeField] List<GameObject> researchables;
    [SerializeField] GameObject weaponsPanel;
    [SerializeField] GameObject content;
    [SerializeField] Scrollbar scrollbar;
    int counter;

    public void openWeaponsList() {
        if (!weaponsPanel.activeSelf) {
            weaponsPanel.SetActive(true);
            foreach (GameObject researchOption in researchables) {
                if (researchOption.transform.GetChild(1).GetComponent<Text>().text == "Completed") {
                    //content.transform.GetChild(counter).gameObject.SetActive(true);
                }
                counter++;
            }
            counter = 0;
        }
        else {
            weaponsPanel.SetActive(false);
        }
    }

    void Update() {
        if (!weaponsPanel.transform.parent.gameObject.activeSelf) {
            weaponsPanel.SetActive(false);
        }
        //scrollbar.size = 0.03f;
    }

}
