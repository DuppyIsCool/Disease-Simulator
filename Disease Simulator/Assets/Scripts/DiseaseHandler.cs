using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseHandler : MonoBehaviour
{
    public List<Symptom> mutableSymptoms;
<<<<<<< Updated upstream
    public Disease disease;
    public GameObject personHandler;
    void Start(){
        
=======
    public List<GameObject> people;
    public Disease disease;
    public GameObject personHandler;
    void Start(){
>>>>>>> Stashed changes
        if(disease == null){
            disease = ScriptableObject.CreateInstance<Disease>();
        }
        if(mutableSymptoms == null){
            mutableSymptoms = new List<Symptom>();
        }

        foreach(Symptom s in mutableSymptoms){
            Debug.Log(s.ToString());
        }
        personHandler = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler;
<<<<<<< Updated upstream

        Debug.Log(personHandler.GetComponent<PersonHandler>().people.Count + " People");
        int patient0 = Random.Range(0, personHandler.GetComponent<PersonHandler>().people.Count);
        Debug.Log("Patient 0 " + patient0);
        personHandler.GetComponent<PersonHandler>().people[patient0].GetComponent<Person>().isInfected = true;
        Debug.Log("Person #" + patient0 + " isInfected " + personHandler.GetComponent<PersonHandler>().people[patient0].GetComponent<Person>().isInfected);
    
=======
        Debug.Log(personHandler);
        
>>>>>>> Stashed changes
    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        // If day is multiple of 3
        if(personHandler.GetComponent<PersonHandler>().getTime()/60/60/24 % 3.0 == 0){
            Debug.Log("3rd Day");
            double die = (double)Random.Range(0,100)/100.0;
            Debug.Log("Die: " + die);
            int symptomToMutate = Random.Range(0, mutableSymptoms.Count);
            Debug.Log("Chosen symptom" + mutableSymptoms[symptomToMutate]);
            if(die < mutableSymptoms[symptomToMutate].mutationChance){
                disease.addSymptom(mutableSymptoms[symptomToMutate]);
                mutableSymptoms.Remove(mutableSymptoms[symptomToMutate]);
                Debug.Log("Mutated: " + disease.getSymptoms()[disease.getSymptoms().Count-1]);
            }
            else
                Debug.Log("Failed to mutate" + mutableSymptoms[symptomToMutate]);
        }
=======
        Debug.Log("Before Loop" + GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler);
        people = GameObject.Find("CityGenerator").GetComponent<CityGenerator>().personHandler.GetComponent<PersonHandler>().getPeople();
        Debug.Log(people.Count);
        Debug.Log("Out of loop");
        /*
        Debug.Log("In Update");
        if(personHandler.GetComponent<PersonHandler>().getHour() > 1){
            
        }
        else if(personHandler.GetComponent<PersonHandler>().getTime() > 1) {
            Debug.Log("Time > 1");
            // If day is multiple of 3
            if((double)personHandler.GetComponent<PersonHandler>().getHour() % 3.0 == 0.0){
                Debug.Log("3rd Day");
                double die = (double)Random.Range(0,100)/100.0;
                Debug.Log("Die: " + die);
                int symptomToMutate = Random.Range(0, mutableSymptoms.Count);
                Debug.Log("Chosen symptom" + mutableSymptoms[symptomToMutate]);
                if(die < mutableSymptoms[symptomToMutate].mutationChance){
                    disease.addSymptom(mutableSymptoms[symptomToMutate]);
                    mutableSymptoms.Remove(mutableSymptoms[symptomToMutate]);
                    Debug.Log("Mutated: " + disease.getSymptoms()[disease.getSymptoms().Count-1]);
                }
                else
                    Debug.Log("Failed to mutate" + mutableSymptoms[symptomToMutate]);
            }
        }
        */
    }

    public void myInitialize(){
        Debug.Log("Time = 1");
            Debug.Log(personHandler.GetComponent<PersonHandler>().people.Count + " People");
            int patient0 = Random.Range(0, personHandler.GetComponent<PersonHandler>().people.Count);
            Debug.Log("Patient 0 " + patient0);
            personHandler.GetComponent<PersonHandler>().people[patient0].GetComponent<Person>().isInfected = true;
            Debug.Log("Person #" + patient0 + " isInfected " + personHandler.GetComponent<PersonHandler>().people[patient0].GetComponent<Person>().isInfected);
>>>>>>> Stashed changes
    }
}
