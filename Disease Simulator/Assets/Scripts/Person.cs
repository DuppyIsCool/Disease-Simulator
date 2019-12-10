using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    private bool isInside = false;
    
    public GameObject house,work;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setTarget(Transform o){
        //If it's not inside, walk to destination
        if(!isInside){
            agent.SetDestination(o.position);
            target = o;
        }
        //If it's inside, go outside then walk to destination.
        else{
            this.gameObject.active = true;
            isInside = false;
            agent.SetDestination(o.position);
            target = o;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Checks if the gameobject is a door, if it is "enter" the building
        if(collision.gameObject.tag == "Door" && collision.gameObject.transform == target){
            this.gameObject.active = false;
            isInside = true;
        }
    }
    
}
