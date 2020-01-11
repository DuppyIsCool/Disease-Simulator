using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Slider slider;
    public Text multiplierText,infected,cured,killed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//Update text in the simulation
        infected.text = (int) GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().infectedCount+ "";
        killed.text = (int) GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().killedCount+ "";
        cured.text = (int) GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().totalPopulation - (int) GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().infectedCount + "";
        int multiplier = (int) slider.value;
        multiplierText.text = multiplier+"x";
        Time.timeScale = multiplier;


    }
}
