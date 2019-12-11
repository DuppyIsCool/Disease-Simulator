using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    private Renderer render;
    private int currentBuilding = 0;
    private List<Transform> schedule = new List<Transform>();
    Color infectedColor = Color.red;
    Color CureColor = Color.white;
    public bool isInfected = false;
    void Start(){
        render = GetComponent<Renderer>();
        buildSchedule();
    }
    void Update(){
        if(isInfected)
            render.material.color = Color.Lerp(infectedColor, CureColor, 0.1F);
        else
             render.material.color = Color.Lerp(CureColor, CureColor, 1F);
        //Checking if person reached their destination
        if(Vector3.Distance( agent.destination, agent.transform.position) <= 2.5F){
            render.enabled = false;
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
        print("Recieved Instructions to move to next building");
        //Reset Building
        if(currentBuilding >= 23)
            currentBuilding = 0;
        else
            currentBuilding += 1;
        //Move the person to their next building in schedule
        render.enabled = true;
        Transform building = (Transform) schedule[currentBuilding];
        target = building;
        print("Moving to "+building.position);
        agent.SetDestination(building.position);
        print(currentBuilding);
    }

    void goToHospital(){
        //Go to a hospital
        List<GameObject> hospitals = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getHospitals();
        GameObject hospital = hospitals[Random.Range(0,hospitals.Count-1)];
        render.enabled = true;
        agent.SetDestination(hospital.transform.position);
    }

}
