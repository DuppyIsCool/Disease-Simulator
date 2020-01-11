using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Declare Cities Scriptable Object
[CreateAssetMenu(fileName = "SymptomObjects", menuName = "Cities", order = 51)]
public class Cities : ScriptableObject
{
    [SerializeField]
    public int tileCount;
    [SerializeField]
    public int popCount;
}
