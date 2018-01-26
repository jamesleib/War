using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    public int year;
    public int day;
    [SerializeField] Text timeText;
    [SerializeField] Text autoTimeText;
    [SerializeField] Slider autoTimeSlider;
    float timeSinceIncrement;

    public void advanceButtonDay() {
        if (autoTimeSlider.value == 0) {
            day++;
            monthCheckAndUpdate();
        }
    }

    public void advanceButtonWeek() {
        if (autoTimeSlider.value == 0) {
            day+=7;
            monthCheckAndUpdate();
        }
    }

    void Update() {
        if (autoTimeSlider.value == 0) {
            autoTimeText.text = "Manual Time";
        }
        else {
            autoTimeText.text = autoTimeSlider.value + " Days Per Second";
            timeSinceIncrement += Time.deltaTime;
            if (timeSinceIncrement > 1/autoTimeSlider.value) {
                timeSinceIncrement = 0;
                day++;
                monthCheckAndUpdate();
            }
        }
    }

    void monthCheckAndUpdate() {
        if (year%4 != 0){
            if (day>365) {
                day -= 365;
                year++;
            }
            if (day <= 31) {
                timeText.text = year + "\nJanuary " + day;
            }
            else if (day <= 59) {
                timeText.text = year + "\nFebruary " + (day - 31);
            }
            else if (day <= 90) {
                timeText.text = year + "\nMarch " + (day - 59);
            }
            else if (day <= 120) {
                timeText.text = year + "\nApril " + (day - 90);
            }
            else if (day <= 151) {
                timeText.text = year + "\nMay " + (day - 120);
            }
            else if (day <= 181) {
                timeText.text = year + "\nJune " + (day - 151);
            }
            else if (day <= 212) {
                timeText.text = year + "\nJuly " + (day - 181);
            }
            else if (day <= 243) {
                timeText.text = year + "\nAugust " + (day - 212);
            }
            else if (day <= 273) {
                timeText.text = year + "\nSeptember " + (day - 243);
            }
            else if (day <= 304) {
                timeText.text = year + "\nOctober " + (day - 273);
            }
            else if (day <= 334) {
                timeText.text = year + "\nNovember " + (day - 304);
            }
            else if (day <= 365) {
                timeText.text = year + "\nDecember " + (day - 334);
            }
        }
        else {
            if (day>366) {
                day -= 365;
                year++;
            }
            if (day <= 31) {
                timeText.text = year + "\nJanuary " + day;
            }
            else if (day <= 60) {
                timeText.text = year + "\nFebruary " + (day - 31);
            }
            else if (day <= 91) {
                timeText.text = year + "\nMarch " + (day - 60);
            }
            else if (day <= 121) {
                timeText.text = year + "\nApril " + (day - 91);
            }
            else if (day <= 152) {
                timeText.text = year + "\nMay " + (day - 121);
            }
            else if (day <= 182) {
                timeText.text = year + "\nJune " + (day - 152);
            }
            else if (day <= 213) {
                timeText.text = year + "\nJuly " + (day - 182);
            }
            else if (day <= 244) {
                timeText.text = year + "\nAugust " + (day - 213);
            }
            else if (day <= 274) {
                timeText.text = year + "\nSeptember " + (day - 244);
            }
            else if (day <= 305) {
                timeText.text = year + "\nOctober " + (day - 274);
            }
            else if (day <= 335) {
                timeText.text = year + "\nNovember " + (day - 305);
            }
            else if (day <= 365) {
                timeText.text = year + "\nDecember " + (day - 335);
            }
        }
    }

}