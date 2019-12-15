using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target,previousTarget;
    public bool isInfected = false;
<<<<<<< Updated upstream
    private bool isInside = false;
    private Hashtable schedule = new Hashtable();
    
    public Transform house,work;
    // Start is called before the first frame update
    void Start()
    {
        constructSchedule();
    }

    public void setTarget(Transform o){
        //If it's not inside, walk to destination
        if(!isInside){
            agent.SetDestination(o.position);
            target = o;
        }
        //If it's inside, go outside then walk to destination.
        else{
            //If it's not already at it's target
            
                this.gameObject.active = true;
                isInside = false;
                agent.SetDestination(o.position);
                target = o;
           
=======

    public const double INFECTIVITY_SCALE = 1;
    public const double LETHALITY_SCALE = 1;

    void Start(){
        GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().infectedCount = 1;
        render = GetComponent<Renderer>();
        buildSchedule();
    }
    void Update(){
        if(isInfected)
            render.material.color = Color.Lerp(infectedColor, CureColor, 0.1F);
        else
             render.material.color = Color.Lerp(CureColor, CureColor, 1F);
        //Checking if person reached their destination
        if(Vector3.Distance(agent.destination, agent.transform.position) <= 0.5F){
            render.enabled = false;
            if(target.parent.tag == "Hospital" && isInfected){
                if( Random.Range(0.0f,1.0f) <= getCureChance()){
                    isInfected = false;
                    GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().infectedCount -= 1;
                }
            }
            if((double)Random.Range(0.0f,1.0f) <= INFECTIVITY_SCALE * GameObject.Find("CityGenerator").GetComponent<CityGenerator>().diseaseHandler.GetComponent<DiseaseHandler>().disease.GetComponent<Disease>().totalLethality){
                Destroy(this);
                GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().personCount -= 1;
            }
>>>>>>> Stashed changes
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 1){
            previousTarget = target;
            print("Reached Destination");
            agent.isStopped = true;
            this.gameObject.active = false; 
            isInside = true;
        }
    }

<<<<<<< Updated upstream
    void constructSchedule(){
        List<Transform> places = new List<Transform>();
        places.Add(house.transform);
        places.Add(work.transform);
        for(int i = 0; i < 24; i++){
            int r;
            if(i < 20 && i > 10)
                r = Random.Range(0,2);
            else if(i > 0 && i < 10)
                r = 1;
            else
                r =0;
            schedule.Add(i,places[r]);
        }
=======
    public void nextBuilding(){
        //print("Recieved Instructions to move to next building");
        //Reset Building
        if(currentBuilding >= 23)
            currentBuilding = 0;
        else
            currentBuilding += 1;
        //Move the person to their next building in schedule
        render.enabled = true;
        Transform building = (Transform) schedule[currentBuilding];
        target = building;
        //print("Moving to "+building.position);
        agent.SetDestination(building.position);
        //print(currentBuilding);
>>>>>>> Stashed changes
    }

<<<<<<< Updated upstream
    public Transform getScheduledBuilding(int hour){
        return (Transform) schedule[hour];
=======
    void goToHospital(){
        //Go to a hospital
        List<GameObject> hospitals = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getHospitals();
        GameObject hospital = hospitals[Random.Range(0,hospitals.Count-1)];
        render.enabled = true;
        agent.SetDestination(hospital.transform.GetChild(1).transform.position);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Person"){
            if(other.gameObject.GetComponent<Person>().isInfected && isInfected == false){
                if((double)Random.Range(0,1.0f) <= INFECTIVITY_SCALE * GameObject.Find("CityGenerator").GetComponent<CityGenerator>().diseaseHandler.GetComponent<DiseaseHandler>().disease.GetComponent<Disease>().totalInfectivity){
                    this.isInfected = true;
                    GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().infectedCount += 1; 
                }
            }
        }
    }

    float getCureChance(){
        return Random.Range(0.0f, .5f * 1 / (GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().personCount - GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().infectedCount));
>>>>>>> Stashed changes
    }
    
}
