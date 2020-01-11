using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
	//Variables
    public NavMeshAgent agent;
    public Transform target,ptarget;
    private Renderer render;
    private int currentBuilding = 0;
    private List<Transform> schedule = new List<Transform>();
    Color infectedColor = Color.red;
    Color CureColor = Color.white;
	
    public bool isInfected = false;
    void Start(){
		//Variable declaration
         GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().infectedCount = 1;
        render = GetComponent<Renderer>();
        buildSchedule();
    }
    void Update(){
		//If the person is infected, change the color to red, else, turn to white
        if(isInfected)
            render.material.color = Color.Lerp(infectedColor, CureColor, 0.1F);
        else
             render.material.color = Color.Lerp(CureColor, CureColor, 1F);
        //Checking if person reached their destination
        if(Vector3.Distance( agent.destination, agent.transform.position) <= 0.5F){
            render.enabled = false;
			//If they are at a hospital, cure them depending on the random chance
            if(target.parent.tag == "Hospital" && isInfected){
                if((float) Random.Range(0,1) <= getCureChance()){
                    isInfected = false;
                    GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().infectedCount -= 1;
                }
            }

        }
    }

    void buildSchedule(){
        //Creates a schedule
        List<GameObject> allBuildings = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getAllBuildings();

        for(int i = 0; i < 24; i++){
            schedule.Add(allBuildings[Random.Range(0,(allBuildings.Count)-1)].transform.GetChild(1).transform);
        }
        
    }

    public void nextBuilding(){

        //Reset Building
        if(currentBuilding >= 23)
            currentBuilding = 0;
        else
            currentBuilding += 1;
        //Move the person to their next building in schedule
        render.enabled = true;
        Transform building = (Transform) schedule[currentBuilding];
        target = building;
        agent.SetDestination(building.position);
    }

    void goToHospital(){
        //Go to a hospital
        List<GameObject> hospitals = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getHospitals();
        GameObject hospital = hospitals[Random.Range(0,hospitals.Count-1)];
        render.enabled = true;
        agent.SetDestination(hospital.transform.GetChild(1).transform.position);
        
    }
	//Calls when they enter trigger colliders.
    void OnTriggerEnter(Collider other)
    {
		//If it's a person who's infected, run infection chance
        if(other.gameObject.tag == "Person"){
            if(other.gameObject.GetComponent<Person>().isInfected && isInfected == false){
                if((float) Random.Range(0,1) <= getCureChance()){
                    this.isInfected = true;
                    GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().infectedCount += 1; 
                }
            }
        }
    }

    float getCureChance(){
        return GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().cureChance;
    }

}
