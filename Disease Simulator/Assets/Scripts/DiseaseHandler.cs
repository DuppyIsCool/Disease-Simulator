using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseHandler : MonoBehaviour
{
    
    // Instance Fields
    private List<Disease> diseases;
    private List<Symptom> possibleSymptoms;

    // Start is called before the first frame update
    void Start(List<Disease> d, List<Symptom> s)
    {
        diseases = d;
        possibleSymptoms = s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Adds a symptom to possibleSymptoms
    public bool addPossibleSymptom(Symptom s){
        if(possibleSymptoms.Contains(s))
            return false;
        possibleSymptoms.Add(s);
        return true;
    }

    // Removes a symptom from possibleSymptoms
    public bool removePossibleSymptoms(){

    }
}
