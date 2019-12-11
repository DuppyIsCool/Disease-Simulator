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
    public int maxSize,minSize;
    public NavMeshSurface surface;

    //Tile and Building variables
    public GameObject tile;
    public GameObject hospital;
    public GameObject house;
    public GameObject work;
    public GameObject personHandler;
    public GameObject diseaseHandler;
    private List<GameObject> buildings = new List<GameObject>();
    public int tileCount = 10;

    // JD: Creates a DiseaseHandler GameObject
    public GameObject diseaseHandler;

    // Start is called before the first frame update
    void Start()
    {
        //Build tag list
        List<string> tileTags = new List<string>();
        BuildTagList(tileTags);

        //Build city gameobjects
        BuildCity(tileTags);
        manipulateSize();

        //Build Navigation Mesh
        surface.BuildNavMesh();

        //Spawn citizens
        populateCity();

<<<<<<< Updated upstream
        // Spawn disease
        diseaseHandler = Instantiate(diseaseHandler, new Vector3(0,0,0), Quaternion.identity);
=======
        // JD: Initializes diseaseHandler
        Instantiate(diseaseHandler, new Vector3(0,0,0), Quaternion.identity);
>>>>>>> Stashed changes
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
        //Loop for every tile in 'tileCount'
        for(int i = 0; i < tileCount; i++){
            string tag = "Untagged";
            
            //Loop while the tag is Untagged, forcing it to choose one of the four tags
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
            //Add the tag to the tileTags list
            tileTags.Add(tag);
        }
            
    }

    //Randomly changing the size of each building
    void manipulateSize(){
        int size = 0;
        foreach(GameObject g in buildings){

            //Make sure size is not negative or maxSize < minSize
            if(minSize <= 1)
                minSize = 2;
            if(maxSize <= 2 || maxSize < minSize)
                maxSize = minSize + 1;

            //Randomly generate size within range
            size = (int) Random.Range(minSize,maxSize);
            GameObject building = g.transform.GetChild(0).gameObject;
            GameObject door = g.transform.GetChild(1).gameObject;
            Vector3 doorSize = g.transform.localScale;
            //If size does not break the bounding boxes of the tile, resize
            if(size <= 10){
                building.transform.localScale = new Vector3(size,size,size);
            }
            else{
               building.transform.localScale = new Vector3(10,size,10); //Prevents buildings from expanding out of their tile
            }

            //Resize door
            door.transform.localScale = new Vector3(doorSize.x,size/2,building.transform.localScale.z/4);

            //Get a building's new resized vector position
            Vector3 pos = building.transform.position;
            pos.y = (float)( building.transform.localScale.y/2 + 0.5);

            //Get new door position
            Vector3 doorPos = door.transform.position;
            doorPos.x = (pos.x + building.transform.localScale.x/2);
            doorPos.y = (float)(pos.y/2);

            //Set the buildings new vector position
            building.transform.position = pos;
            door.transform.position = doorPos;
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
    public List<GameObject> getHospitals(){
        List<GameObject> list = new List<GameObject>();
        foreach(GameObject g in buildings){
            if(g.tag == "Hospital")
                list.Add(g);
        }

        return list;
    }
    public List<GameObject> getWorks(){
        List<GameObject> list = new List<GameObject>();
        foreach(GameObject g in buildings){
            if(g.tag == "Work")
                list.Add(g);
        }

        return list;
    }
}

