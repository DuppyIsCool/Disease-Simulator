using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Symptom : MonoBehaviour, IEquatable<Symptom>
{
    // Property Backups
    private string _name;
    private float _infectivityScore, _severityScore, _mutationRate;

    // Property Declarations
    public string Name {
        get => _name;
        private set {
            if(IsNullOrEmpty(value))
                throw new NullReferenceException();
            else
                _name = value;
        }
    }
    public float InfectivityScore {
        get => _infectivityScore;
        private set {
            if(0 <= value <= 1)
                _infectivityScore = value;
            else
                throw new ArgumentOutOfRangeException();
        }
    }
    public float SeverityScore {
        get => _severityScore;
        private set {
            if(0 <= value <= 1)
                _severityScore = value;
            else
                throw new ArgumentOutOfRangeException();
        }
    }
    public float MutationRate {
        get => _mutationRate;
        private set {
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
    
    // Checks if this object is equal to another
    // Overrides object.Equals
    public override bool Equals(object obj)
    {
        return this.Equals(obj as Symptom);
    }

    // Checks if this Symptom is equal to another Symptom
    // Implements IEquatable<Symptom> interface
    public bool Equals(Symptom s){
        if(Object.ReferenceEquals(s, null))
            return false;
        if(Object.ReferenceEquals(this, s))
            return true;
        if(this.GetType() != s.GetType())
            return false;
        return Name == s.Name;
    }

    // Overrides the == and != operators
    public static bool operator ==(Symptom lhs, Symptom rhs){
        if(Object.ReferenceEquals(lhs, null)){
            if(Object.ReferenceEquals(rhs, null))
                return true;
            return false;
        }
        return lhs.Equals(rhs);
    }
    public static bool operator !=(Symptom lhs, Symptom rhs){
        return !(lhs == rhs);
    }

    // Returns the HashCode of Name
    // Overrides object.GetHasCode()
    public override int GetHashCode(){
        return Name.GetHashCode();
    }

    // Returns the object as a String
    // Overrides object.ToString()
    public override string ToString(){
        return Name;
    }
}
