using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symptom : MonoBehaviour
{
    // Property Backups
    private string _name;
    private float _infectivityScore, _severityScore, _mutationRate;

    // Property Declarations
    public string Name {
        get => _name;
        set {
            if(IsNullOrEmpty(value))
                throw new NullReferenceException();
            else
                _name = value;
        }
    }
    public float InfectivityScore {
        get => _infectivityScore;
        set {
            if(0 <= value <= 1)
                _infectivityScore = value;
            else
                throw new ArgumentOutOfRangeException();
        }
    }
    public float SeverityScore {
        get => _severityScore;
        set {
            if(0 <= value <= 1)
                _severityScore = value;
            else
                throw new ArgumentOutOfRangeException();
        }
    }
    public float MutationRate {
        get => _mutationRate;
        set {
            if(0 <= value <= 1)
                _mutationRate = value;
            else
                throw new ArgumentOutOfRangeException();
        }
    }

    // Start is called before the first frame update
    void Start(string n, float i, float s)
    {
        Name = n;
        InfectivityScore = i;
        SeverityScore = s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
