using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Create Symptoms Scriptable Objects
[CreateAssetMenu(fileName = "SymptomObjects", menuName = "Symptom", order = 51)]
public class Symptoms : ScriptableObject
{
    [SerializeField]
    public bool isEnabled;
    [SerializeField]
    public string name;
    [SerializeField]
    public float infectivityRate;
    [SerializeField]
    public float lethalityRate;
}
