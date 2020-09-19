using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] locationPrefabs;


    private float currentZ;
    private GameObject player;
    private int currLocation = 0;
    private GameObject currPlatform;

    private float firstZ = -12;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Moving>().gameObject;
        currentZ = player.transform.position.z;
        currPlatform = GameObject.FindGameObjectWithTag("FirstPlatform");
    }

    // Update is called once per frame
    void Update()
    {
        platformsSpawn();
    }

    void platformsSpawn()
    {
        if (currentZ+firstZ>player.transform.position.z)
        {
            firstZ = -17;
            currentZ = player.transform.position.z;
            currLocation = Random.Range(0, locationPrefabs.Length);
            currPlatform = Instantiate(locationPrefabs[currLocation], new Vector3(currPlatform.transform.position.x, currPlatform.transform.position.y, currPlatform.transform.position.z - 25),Quaternion.Euler(0,0,0));
        }
    }

}
