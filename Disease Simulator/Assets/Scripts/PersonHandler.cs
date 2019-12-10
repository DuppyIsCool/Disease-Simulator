using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonHandler : MonoBehaviour
{
    public GameObject person;
    public int personcount = 10;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < personcount;i++)
            createPerson();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    void createPerson(){
        List<GameObject> houses = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().getHouses();
        if(houses.Count != 0){
            GameObject house = houses[(int) Random.Range(0,houses.Count)];
            person = Instantiate(person, new Vector3(house.transform.GetChild(1).position.x+3,house.transform.position.y+10F,house.transform.position.z),Quaternion.identity);
            person.transform.parent = GameObject.Find("People").transform;
            person.GetComponent<Person>().setTarget(house.transform.GetChild(1));
        }
        
    }

    void updateSchedules(){

    }

    float getTime(){
        return time;
    }
}
