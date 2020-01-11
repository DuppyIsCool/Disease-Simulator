using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseSimulator : MonoBehaviour
{
    public float totalInfectivityRate;
    public float totalLethalityRate;
    public float cureChance;
    public Symptoms coughing,sneezing,coma,heartfailure,braintumor;
    public int infectedCount,killedCount,totalPopulation;
    public Cities a;
    // Start is called before the first frame update
    void Start()
    {
		//Initial Variable declaration
        killedCount = 0;
        infectedCount = 1;
        totalPopulation = a.popCount;
        killedCount = 0;
        totalInfectivityRate = 0;
        totalLethalityRate = 0;
        cureChance = (float) Random.Range(1,100)/100;
		
		//Adding all enabled symptom's infectivity and lethality
        if(coma.isEnabled){
            totalInfectivityRate += coma.infectivityRate;
            totalLethalityRate += coma.lethalityRate;
        }

        if(coughing.isEnabled){
             totalInfectivityRate += coughing.infectivityRate;
             totalLethalityRate += coughing.lethalityRate;
        }

        if(sneezing.isEnabled){
             totalInfectivityRate += sneezing.infectivityRate;
             totalLethalityRate += sneezing.lethalityRate;
        }
        if(braintumor.isEnabled){
            totalInfectivityRate += braintumor.infectivityRate;
            totalLethalityRate += braintumor.lethalityRate;
        }
        if(heartfailure.isEnabled){
            totalInfectivityRate += heartfailure.infectivityRate;
            totalLethalityRate += heartfailure.lethalityRate;
        }
		
		//Makes sure infectivity and lethality are not above 100%
        if(totalInfectivityRate > 1)
            totalInfectivityRate = 1;
        if(totalLethalityRate > 1)
            totalLethalityRate = 1;
	
		//Print lethality,infectivity, and cureChance in the editor debug console
        print("lethality "+totalLethalityRate + " infect: "+totalInfectivityRate + " cure: "+cureChance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}