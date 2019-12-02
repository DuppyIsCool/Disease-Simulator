/**
    Author: Kai Lopez
    Date Created: 10/29/2019
    This script is used to generate a city with buildings with user given variables
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CityGenerator : MonoBehaviour
{
    //Variable declarations

    //Determines how likely a building is to spawn on a tile
    public float houseTileChance = 0.25F;
    public float emptyTileChance = 0.25F;
    public float hospitalTileChance = 0.25F;
    public float workTileChance = 0.25F;
    public NavMeshSurface surface;

    //Tile and Building variables
    public GameObject tile;
    public GameObject hospital;
    public GameObject house;
    public GameObject work;
    public GameObject personHandler;
    private List<GameObject> buildings = new List<GameObject>();
    public int tileCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        List<string> tileTags = new List<string>();
        BuildTagList(tileTags);

        BuildCity(tileTags);
        manipulateSize();
        surface.BuildNavMesh();
        populateCity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Build City
    void BuildCity(List<string> tileTags){
        float x = 0, z = 0, rowNum = 1;
        int maxPerRow = (int)Mathf.Sqrt(tileTags.Count);
        GameObject clone,building = null;
        
        //Loop For every tag
        foreach(string s in tileTags){

            //Instantiate (Create) Buildings based on tag
            clone = Instantiate(tile, new Vector3(x,0,z), Quaternion.identity);
            clone.tag = s;
            if(s == "HouseTile"){
                building = Instantiate(house, new Vector3(x,house.transform.localScale.z/2F + 0.5F,z),Quaternion.identity);
                building.tag = "House";
            }
            else if(s == "HospitalTile"){
                building = Instantiate(hospital, new Vector3(x,hospital.transform.localScale.z/2F + 0.5F,z),Quaternion.identity);
                building.tag = "Hospital";
            }
            else if(s == "WorkTile"){
                building = Instantiate(work, new Vector3(x,work.transform.localScale.z/2F + 0.5F,z),Quaternion.identity);
                building.tag = "Work";
            }
            
            //Setting tile and building to parents of their empty game object (for organization)
            if(s != "EmptyTile"){ //Can't put a building into a empty gameobject if no building is present
                building.transform.parent = GameObject.Find("Buildings").transform;
                buildings.Add(building);
            }
            clone.transform.parent = GameObject.Find("Tiles").transform;
            //Makes sure the position of the buildings is correct. (Can work with any tile size/building size)
            if(rowNum < maxPerRow){
                rowNum = rowNum +1;
                x = x+ tile.transform.localScale.x;
            }
            else{
                rowNum = 1;
                x = 0;
                z = z+tile.transform.localScale.z;
            }

        }

    }

    void populateCity(){
        Instantiate(personHandler, new Vector3(0,0,0),Quaternion.identity);
    }

    //Build 'tileTags' with matching percentages of tiles
    void BuildTagList(List<string> tileTags){
        for(int i = 0; i < tileCount; i++){
            string tag = "Untagged";
            while(tag == "Untagged"){
                if(Random.value <= houseTileChance)
                    tag = "HouseTile";
                else if(Random.value <= emptyTileChance)
                    tag = "EmptyTile";
                else if(Random.value <=hospitalTileChance)
                    tag = "HospitalTile";
                else if(Random.value <= workTileChance)
                    tag = "WorkTile";
            }
            tileTags.Add(tag);
        }
            
    }

    //Randomly changing the size of each building
    void manipulateSize(){
        int size = 0;
        foreach(GameObject g in buildings){
            size = (int) Random.Range(3,50);
            if(size <= 10)
                g.transform.localScale = new Vector3(size,size,size);
            else
               g.transform.localScale = new Vector3(10,size,10); 
            Vector3 pos = g.transform.position;
            pos.y = (float)( g.transform.localScale.y/2 + 0.5);
            g.transform.position = pos;
        }

    }

    //Return list of house game objects
    public List<GameObject> getHouses(){
        List<GameObject> list = new List<GameObject>();
        foreach(GameObject g in buildings){
            if(g.tag == "House")
                list.Add(g);
        }

        return list;
    }
}

