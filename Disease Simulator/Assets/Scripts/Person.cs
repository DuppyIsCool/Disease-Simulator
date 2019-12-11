using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target,previousTarget;
    public bool isInfected = false;
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

    public Transform getScheduledBuilding(int hour){
        return (Transform) schedule[hour];
    }
    
}
