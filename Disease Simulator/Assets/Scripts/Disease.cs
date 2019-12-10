using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Disease", menuName = "Disease")]
public class Disease : ScriptableObject
{
    public new string name;
    
    public int numPeopleKilled;

    public double totalInfectivity { get; private set; }
    public double totalLethality { get; private set; }

    public List<Symptom> initialSymptoms;
    private List<Symptom> symptoms = new List<Symptom>();

    public void OnEnable(){
        if(initialSymptoms != null)
            symptoms = initialSymptoms;
        updateTotalInfectivity();
        updateTotalLethality();
    }

    // Updates the totalInfectivity
    public void updateTotalInfectivity(){
        // Checks if there are any Symptoms
        if(symptoms == null || symptoms.Count == 0){
            // If not, 0
            totalInfectivity = 0;
        }
        else{
            // Calculates the max and total of the infectivityRates
            double total = symptoms[0].infectivityRate;
            double max = symptoms[0].infectivityRate;

            for(int i = 1; i < symptoms.Count; i++){
                if(symptoms[i].infectivityRate > max){
                    max = symptoms[i].infectivityRate;
                }
                total += symptoms[i].infectivityRate;
            }

            // max + 10% of average of the other symptoms 
            double temp = max + (.1 * (total-max)/(symptoms.Count-1));

            // Caps the totalInfectivityRate at 90%
            if(temp > .9)
                totalInfectivity = .9;
            else
                totalInfectivity = temp;
        }
    }

    // Updates the totalSeverity
    public void updateTotalLethality(){
        // Checks if there are any Symptoms
        if(symptoms == null || symptoms.Count == 0){
            // If not, 0
            totalLethality = 0;
        }
        else{
            // Calculates the max and total of the lethalityRates
            double total = symptoms[0].infectivityRate;
            double max = symptoms[0].infectivityRate;
            for(int i = 1; i < symptoms.Count; i++){
                if(symptoms[i].lethalityRate > max){
                    max = symptoms[i].lethalityRate;
                }
                total += symptoms[i].lethalityRate;
            }

            // max + 10% of average of the other symptoms 
            double temp = max + (.1 * (total-max)/(symptoms.Count -1));

            // Caps the totalLethalityRate at 90%
            if(temp > .9)
                totalLethality = .9;
            else
                totalLethality = temp;
        }
    }
    
    // Adds a symptom to symptoms
    public void addSymptom(Symptom s){
        symptoms.Add(s);
        updateTotalInfectivity();
        updateTotalLethality();
    }

    // Returns symptoms
    public List<Symptom> getSymptoms(){
        return symptoms;
    }

}
