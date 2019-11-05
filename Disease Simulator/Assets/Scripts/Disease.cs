using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease : MonoBehaviour
{
    // Instance fields
    private static int diseaseNum;
    private List<Symptom> symptoms;

    // Property Backup
    private string _name;

    // Property Definition
    public string Name {
        get => _name;
        set {
            if(IsNullOrEmpty(value))
                throw new NullReferenceException();
            else
                _name = value;
        }
    }
    public float totalInfectivity{
        get {
            float temp = 0;
            foreach(Symptom s in symptoms)
                temp += s.InfectivityScore;
        }
    }
    public float totalSeverity{
        get {
            float temp = 0;
            foreach(Symptom s in symptoms)
                temp += s.SeverityScore;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Name = "Disease" + ++diseaseNum;
        symptoms = new List<Symptom>();
    }
    void Start(string n)
    {
        Name = n;
        symptoms = new List<Symptom>();
    }
    void Start(string n, List<Symptom> s)
    {
        Name = n;
        symptoms = s;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Adds a symptom to symptom
    public void addSymptom(Symptom s){
        symptoms.Add(s);
    }

    // Removes a symptom from symptoms
    // Returns false if it is not in symptoms
    public bool removeSymptom(Symptom s){
        return symptoms.Remove(s);
    }
}
