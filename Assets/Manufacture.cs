using UnityEngine;
using UnityEngine.UI;

public class Manufacture : MonoBehaviour {

    [SerializeField] Text factoryCount;
    int usedFactories;

    void Start() {
        factoryUpdate();
    }

    public void factoryUpdate() {
        factoryCount.text = "Factories: " +  usedFactories + gameObject.GetComponent<Construction>().factories;
    }

}
