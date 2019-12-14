using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHandler : MonoBehaviour
{
    public List<GameObject> people;
    public GameObject person;
    public int personCount,hours,days,infectedCount = 0;
    public float time;


    void Start(){
        people = new List<GameObject>();
        List<GameObject> houses = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getHouses();

        for(int i = 0; i < personCount; i++){
            GameObject tempPerson;
            GameObject house = houses[Random.Range(0,(houses.Count)-1)];
            tempPerson = Instantiate(person, new Vector3(house.transform.GetChild(1).transform.position.x+2F,house.transform.GetChild(1).transform.position.y - house.transform.GetChild(1).transform.localScale.y/2,house.transform.GetChild(1).transform.position.z), Quaternion.identity);
            tempPerson.GetComponent<Person>().target = house.transform.GetChild(1).transform;
            tempPerson.transform.parent = GameObject.Find("People").transform;
            tempPerson.GetComponent<Person>().agent.SetDestination(house.transform.GetChild(1).transform.position);
            if(i+1 == personCount)
                tempPerson.GetComponent<Person>().isInfected = true;
            tempPerson.tag = "Person";
            people.Add(tempPerson);
        }
    }

    void Update(){
        time += Time.deltaTime;

        if(time >= 60){
            hours++;
            time = 0;
            updateSchedules();
        }

        if(hours % 24 == 0 && hours != 0)
            days++;
    }

    void updateSchedules(){
        foreach(GameObject person in people){
            person.GetComponent<Person>().nextBuilding();
        }
    }

    public float getTime(){
        return time;
    }
}
