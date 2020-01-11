using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuHandler : MonoBehaviour{
    public Button yourButton;
    public Slider tileSlider,popSlider;
    public Text tileText,popText;
    public Toggle brain,heart,coma,sneeze,cough;
    public Symptoms b,h,c,s,co;
    public Cities a;
    void Start () {
		//Set button and add a listener
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void Update(){
		//Update slider value text
        tileText.text = tileSlider.value + "";
        popText.text = popSlider.value + "";
    }

    //Launch Simulation with inputted variables
    void TaskOnClick(){
        b.isEnabled = brain.isOn;
        h.isEnabled = heart.isOn;
        c.isEnabled = coma.isOn;
        s.isEnabled = sneeze.isOn;
        co.isEnabled = cough.isOn;
        a.tileCount = (int) tileSlider.value;
        a.popCount = (int) popSlider.value;
        SceneManager.LoadScene(1);
    }
}
