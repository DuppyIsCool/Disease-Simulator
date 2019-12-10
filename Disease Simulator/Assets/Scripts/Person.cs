using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    private bool isInside = false;
    
    public GameObject house,work;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setTarget(Transform o){
        if(!isInside)
            agent.SetDestination(o.position);
        else{
            this.gameObject.active = true;
            isInside = false;
            agent.SetDestination(o.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Door"){
            this.gameObject.active = false;
            isInside = true;
        }
    }
    
}
