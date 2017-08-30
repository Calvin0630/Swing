using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class WorldGenerator : MonoBehaviour {

    GameObject groundPrefab;
    GameObject[] groundArray;
    GameObject ground;
    GameObject buildingPrefab;
    GameObject[] buildingArray;
    GameObject buildings;
	// Use this for initialization
	void Start () {
        groundPrefab = Resources.Load("Prefab/Ground") as GameObject;
        buildingPrefab = Resources.Load("Prefab/Building") as GameObject;
        ground = new GameObject();
        ground.name = "Ground";
        ground.transform.SetParent(this.transform);
        buildings = new GameObject();
        buildings.name = "Buildings";
        buildings.transform.SetParent(this.transform);
        SpawnGround();
        SpawnBuildings();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnGround() {
        groundArray = new GameObject[100 * 100];
        for (int i=0;i<100;i++) {
            for (int j = 0;j<100;j++) {
                Vector3 pos = new Vector3(495 - i*10, 0, 495 - j*10);
                groundArray[i * 100 + j] = Instantiate(groundPrefab, pos, Quaternion.identity);
                groundArray[i * 100 + j].name = "Ground[" + i + ", " + j + "]";
                groundArray[i * 100 + j].transform.SetParent(ground.transform);
            }
        }
    }

    public void SpawnBuildings() {
        buildingArray = new GameObject[50*50];
        for (int i=0;i<50;i++) {
            for (int j=0;j<50;j++) {
                Vector3 pos = new Vector3(495 - (2*i*10), 10, 495 - (2*j*10));
                buildingArray[i * 50 + j] = Instantiate(buildingPrefab, pos, Quaternion.identity);
                buildingArray[i * 50 + j].name = "Building[" + i + ", " + j + "]";
                buildingArray[i * 50 + j].transform.SetParent(buildings.transform);
            }
        }
    }
}
