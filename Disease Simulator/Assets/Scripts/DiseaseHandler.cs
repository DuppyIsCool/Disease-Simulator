<<<<<<< Updated upstream
﻿using System.Collections;
=======
using System.Collections;
>>>>>>> Stashed changes
using System.Collections.Generic;
using UnityEngine;

public class DiseaseHandler : MonoBehaviour
{
<<<<<<< Updated upstream
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
=======
    public List<Symptom> mutatableSymptoms;
    public GameObject disease;
    public int numMutationRolls = 0;
    public int symptomToMutate;


    void Start(){
        
        Instantiate(disease, new Vector3(0,0,0), Quaternion.identity);
        disease.GetComponent<Disease>().symptoms = new List<Symptom>();
        disease.GetComponent<Disease>().updateTotalInfectivity();
        disease.GetComponent<Disease>().updateTotalLethality();

        foreach(Symptom s in mutatableSymptoms){
            Debug.Log("Has " + s);
        }
        Debug.Log("Count: " + mutatableSymptoms.Count);
    }

    public void mutateSymptoms()
    {        
        Debug.Log(numMutationRolls + " In mutate symptoms: ");

        foreach(Symptom s in mutatableSymptoms){
            Debug.Log(numMutationRolls + " " + s);
        }

        double die = (double)Random.Range(0.0f,1.0f);
        Debug.Log(numMutationRolls + "Die Roll: " + die);
        symptomToMutate = Random.Range(0, mutatableSymptoms.Count);
        Debug.Log(numMutationRolls + "Symptom to Mutate " + symptomToMutate);
        Debug.Log(numMutationRolls + "Chosen symptom: " + mutatableSymptoms[symptomToMutate]);

        if(disease.GetComponent<Disease>().symptoms.Contains(mutatableSymptoms[symptomToMutate])){
            Debug.Log("Already Mutated");
        }
        else{
            if(die < mutatableSymptoms[symptomToMutate].mutationChance){
                Symptom temp = mutatableSymptoms[symptomToMutate];
                Debug.Log(numMutationRolls + "Attempting to Mutate");
                disease.GetComponent<Disease>().addSymptom(mutatableSymptoms[symptomToMutate]);
                Debug.Log(numMutationRolls + "Mutated: " + disease.GetComponent<Disease>().getSymptoms()[disease.GetComponent<Disease>().getSymptoms().Count-1]);
                Debug.Log(numMutationRolls + "Expected: " + temp);
            }
            else
                Debug.Log(numMutationRolls + "Not attempting to mutate:" + mutatableSymptoms[symptomToMutate]);
        }
        numMutationRolls += 1;
>>>>>>> Stashed changes
    }
}
