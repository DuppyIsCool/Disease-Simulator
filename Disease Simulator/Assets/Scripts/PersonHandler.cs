using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHandler : MonoBehaviour
{
    public List<GameObject> people;
    public GameObject person;
    public int personCount,hours,days;
    public float time;
    void Start(){
        people = new List<GameObject>();
        List<GameObject> houses = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getHouses();

        for(int i = 0; i < personCount; i++){
            GameObject tempPerson;
            GameObject house = houses[Random.Range(0,(houses.Count)-1)];
            tempPerson = Instantiate(person, new Vector3(house.transform.GetChild(1).transform.position.x+2F,house.transform.GetChild(1).transform.position.y - house.transform.GetChild(1).transform.localScale.y/2,house.transform.GetChild(1).transform.position.z), Quaternion.identity);
            tempPerson.transform.parent = GameObject.Find("People").transform;
            if(Random.Range(0,100)<= 50)
                tempPerson.GetComponent<Person>().isInfected = true;
            tempPerson.GetComponent<Person>().agent.SetDestination(house.transform.position);
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
