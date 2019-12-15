using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHandler : MonoBehaviour
{
    public GameObject person;
<<<<<<< Updated upstream
    public List<GameObject> people;
    public Camera cam;
    private float camColor = 0.0F;
    public int personcount = 10;
    private float time = 0,hours = 0,days = 0;
    // Start is called before the first frame update
    void Start()
    {
=======
    public int personCount,hours,days,infectedCount = 0;
    public float time;

    void Start(){
>>>>>>> Stashed changes
        people = new List<GameObject>();
<<<<<<< Updated upstream
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        for(int i = 0; i < personcount;i++)
            createPerson();
=======
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

        //GameObject.Find("CityGenerator").GetComponent<CityGenerator>().GetComponent<DiseaseHandler>().myInitialize();
>>>>>>> Stashed changes
    }

<<<<<<< Updated upstream
    // Update is called once per frame
    void Update()
    {
=======
    void Update(){
        Debug.Log("h: " + hours);
>>>>>>> Stashed changes
        time += Time.deltaTime;
        if((int) time % 60 == 0){
            hours++;
            updateSchedules();
        }
        if((int) hours % 24 == 0)
            days++;

        if(hours >= 3 && hours % 3 == 0 && time == 0){
            Debug.Log("3rd Day");
            GameObject.Find("CityGenerator").GetComponent<CityGenerator>().diseaseHandler.GetComponent<DiseaseHandler>().mutateSymptoms();
        }
    }

    void createPerson(){
        //Get list of houses and work places
        List<GameObject> houses = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getHouses();
        List<GameObject> works = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getWorks();
        if(houses.Count != 0){
            //Set housing and spawn person in
            GameObject house = houses[(int) Random.Range(0,houses.Count-1)];
            person = Instantiate(person, new Vector3(house.transform.GetChild(1).position.x+3,house.transform.position.y+10F,house.transform.position.z),Quaternion.identity);
            person.transform.parent = GameObject.Find("People").transform;
            person.GetComponent<Person>().setTarget(house.transform.GetChild(1));
            person.GetComponent<Person>().house = house.transform.GetChild(1);

            //Setting work building
            if(works.Count != 0){
                GameObject work = works[(int) Random.Range(0,works.Count-1)];
                person.GetComponent<Person>().work = work.transform.GetChild(1);
            }
            people.Add(person);
        }
        
    }

    void updateSchedules(){
        int hourOfDay = (int) hours % 24;
        if(!(hourOfDay == 0))
            hourOfDay -=1;
        foreach(GameObject g in people){
            g.GetComponent<Person>().setTarget(g.GetComponent<Person>().getScheduledBuilding(hourOfDay));
            print(hourOfDay);
        }
        
    }

    public float getTime(){
        return time;
    }

<<<<<<< Updated upstream
    public int getHour(){
        return hours;
    }

    public List<GameObject> getPeople(){
        return people;
    }
=======
    public int getHours(){
        return hours;
    }
>>>>>>> Stashed changes
}
