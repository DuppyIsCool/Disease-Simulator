using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHandler : MonoBehaviour
{
    public List<GameObject> people;
    public GameObject person;
    public int personCount,hours,days,infectedCount = 0;
    public float time,rand;


    void Start(){
		//Get Variables
        people = new List<GameObject>();
        List<GameObject> houses = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getHouses();
        personCount = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().peopleCount;
		
		//Create number of people based on popCount entered by user
        for(int i = 0; i < personCount; i++){
            GameObject tempPerson;
            GameObject house = houses[Random.Range(0,(houses.Count)-1)];
			//Builds at the front of a house door, and sets the door as their target
            tempPerson = Instantiate(person, new Vector3(house.transform.GetChild(1).transform.position.x+2F,house.transform.GetChild(1).transform.position.y - house.transform.GetChild(1).transform.localScale.y/2,house.transform.GetChild(1).transform.position.z), Quaternion.identity);
            tempPerson.GetComponent<Person>().target = house.transform.GetChild(1).transform;
            tempPerson.transform.parent = GameObject.Find("People").transform;
            tempPerson.GetComponent<Person>().agent.SetDestination(house.transform.GetChild(1).transform.position);
			//If it's the last person, make them infected, aka patient 0
            if(i+1 == personCount)
                tempPerson.GetComponent<Person>().isInfected = true;
            tempPerson.tag = "Person";
            people.Add(tempPerson);
        }
    }

    void Update(){
		//Update schedule
        time += Time.deltaTime;
		
		//Updates hours and schedules
        if(time >= 60){
            hours++;
            time = 0;
            updateSchedules();
        }
		//Update days (to be used in future updates)
        if(hours % 24 == 0 && hours != 0){
            days++;
        }
    }

    void updateSchedules(){
        List<GameObject> killList = new List<GameObject>();
        foreach(GameObject person in people){
            rand = Random.Range(0,100);
             //Tests if person should die
            if( rand<= (GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().totalLethalityRate*100) && person.GetComponent<Person>().isInfected){
                killList.Add(person);
                GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().killedCount += 1;
                GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().totalPopulation -=1;
                GameObject.Find("DiseaseHandler").GetComponent<DiseaseSimulator>().infectedCount -=1;
            }
            //Else, they continue their day
            else
                person.GetComponent<Person>().nextBuilding();
        }
		
		//Remove from list and destroy the objects marked for death
        foreach(GameObject p in killList){
            people.Remove(p);
            Destroy(p);
        }
    }

    public float getTime(){
        return time;
    }
}
