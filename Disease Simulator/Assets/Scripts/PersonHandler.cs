using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHandler : MonoBehaviour
{
    public GameObject person;
    public Camera cam;
    public Color dayColor = Color.blue;
    public Color nightColor = Color.black;
    public int personcount = 10;
    private float time = 0,hours = 0,days = 0;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Camera").GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        for(int i = 0; i < personcount;i++)
            createPerson();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        bool daytime = true;
        if(time % 60 == 0){
            hours++;
            print(hours);
        }
        if(hours % 24 == 0)
            days++;
    }

    void createPerson(){
        //Get list of houses and work places
        List<GameObject> houses = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getHouses();
        List<GameObject> works = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getWorks();
        if(houses.Count != 0){
            //Set housing and spawn person in
            GameObject house = houses[(int) Random.Range(0,houses.Count)];
            person = Instantiate(person, new Vector3(house.transform.GetChild(1).position.x+3,house.transform.position.y+10F,house.transform.position.z),Quaternion.identity);
            person.transform.parent = GameObject.Find("People").transform;
            person.GetComponent<Person>().setTarget(house.transform.GetChild(1));
            person.GetComponent<Person>().house = house;

            //Setting work building
            if(works.Count != 0){
                GameObject work = works[(int) Random.Range(0,works.Count)];
                person.GetComponent<Person>().work = work;
            }
        }
        
    }

    void updateSchedules(){

    }

    float getTime(){
        return time;
    }
}
