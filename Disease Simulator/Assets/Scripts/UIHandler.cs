using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Slider slider;
    public Text multiplierText,infected,cured;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        infected.text = (int) GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().infectedCount + "";
        cured.text = (int) (GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().personCount - GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().infectedCount) + "";
        int multiplier = (int) slider.value;
        multiplierText.text = multiplier+"x";
        Time.timeScale = multiplier;


    }
}
