using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "New Symptom", menuName = "Symptom")]
public class Symptom : ScriptableObject, IEquatable<Symptom>
{
    public new string name;
    public double infectivityRate;
    public double lethalityRate = 0;
    public double mutationChance;

    public static double counter = 0;

    public void setInfo(string n, double i, double l, double m){
        if(n == null)
            name = "Symptom" + ++counter;
        else
            name = n;

        if(i < 0)
            infectivityRate = 0;
        else if(i > 1)
            infectivityRate = 1;
        else
            infectivityRate = i;

        if(l < 0)
            lethalityRate = 0;
        else if(l > 1)
            lethalityRate = 1;
        else
            lethalityRate = l;

        if(m < 0)
            mutationChance = 0;
        else if(m > 1)
            mutationChance = 1;
        else
            mutationChance = m;
    }

    public override string ToString(){
        return name;
    }

    public override bool Equals(object obj){
        return Equals(obj as Symptom);
    }

    public bool Equals(Symptom s){
        // If parameter is null, return false.
            if (object.ReferenceEquals(s, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (object.ReferenceEquals(this, s))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != s.GetType())
            {
                return false;
            }

            // Returns true if all the fields match
            return (name == s.name) && 
                   (infectivityRate == s.infectivityRate) &&
                   (lethalityRate == s.lethalityRate) &&
                   (mutationChance == s.mutationChance);
    }

    public static bool operator ==(Symptom lhs, Symptom rhs){
        if(object.ReferenceEquals(lhs, null)){
            if(object.ReferenceEquals(rhs, null))
                return true;
            return false;
        }
        return lhs.Equals(rhs);
    }

    public static bool operator !=(Symptom lhs, Symptom rhs){
        return !(lhs == rhs);
    }
}
