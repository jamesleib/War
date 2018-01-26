using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UserCountryUnits : MonoBehaviour {

    [SerializeField] Text currentStations;
    [SerializeField] Text populationText;
    [SerializeField] Text manpowerText;
    [HideInInspector] public int armyMen;
    [HideInInspector] public int trainingMen;
    [HideInInspector] public int totalCasualties;
    public bool conscription = false;
    public float manpowerModifier;
    public float modifierForVolunteerStations;
    public int population;
    int recruitmentCenters;
    int daysRemaining;
    int startDate;
    bool buildProgress;
    GameObject temp;
    float percentOfPopInManpower() {
        return recruitmentCenters*manpowerModifier/1000;
    }
    int manpower() {
        if (!conscription) {
            return Convert.ToInt32(population*percentOfPopInManpower()-armyMen-trainingMen-totalCasualties);
        }
        else {
            Debug.Log("Conscription Yet To Be Coded");
            return 0;
        }
    }
    int maxStations() {
        return Convert.ToInt32(10 * modifierForVolunteerStations);
    }

    void Update() {
        popAndManpowerDisplay();
        recuritmentCenterBuildUpdate();
    }

    public void recruitmentCenterBuild() {
        if (recruitmentCenters < maxStations()) {
            if (!buildProgress) {
                currentStations.text = (recruitmentCenters) + "(+1)/" + maxStations() + " Stations";
                buildProgress = true;
                daysRemaining = 50;
                startDate = (gameObject.GetComponent<TimeScript>().year - 1) * 365 + gameObject.GetComponent<TimeScript>().day;
                temp = EventSystem.current.currentSelectedGameObject;
                temp.GetComponent<Button>().interactable = false;
                temp.transform.GetChild(1).GetComponent<Text>().text = "Days Remaining: " + daysRemaining;
            }
        }
    }

    void recuritmentCenterBuildUpdate() {
        if (buildProgress) {
            daysRemaining = 50 - ((gameObject.GetComponent<TimeScript>().year - 1) * 365 + gameObject.GetComponent<TimeScript>().day - startDate);
            temp.transform.GetChild(1).GetComponent<Text>().text = "Days Remaining: " + daysRemaining;
            if (daysRemaining <= 0) {
                recruitmentCenters++;
                buildProgress = false;
                temp.GetComponent<Button>().interactable = true;
                temp.transform.GetChild(1).GetComponent<Text>().text = "";
                currentStations.text = (recruitmentCenters) + "/" + maxStations() + " Stations";
            }
        }
    }

    void popAndManpowerDisplay() {
        if (population > 1000000) {
            populationText.text = "Population: " + Math.Round(population / 1000000d, 2) + "M";
        }
        else if (population > 1000) {
            populationText.text = "Population: " + Math.Round(population / 1000d, 1) + "k";
        }
        else {
            populationText.text = "Population: " + population;
        }
        if (manpower() > 1000000) {
            manpowerText.text = "Manpower: " + Math.Round(manpower() / 1000000d, 2) + "M";
        }
        else if (manpower() > 1000) {
            manpowerText.text = "Manpower: " + Math.Round(manpower() / 1000d, 1) + "k";
        }
        else {
            manpowerText.text = "Manpower: " + manpower();
        }
    }

}