using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Object Pool")]
    public List<GameObject> listOfLightnings;
    public List<GameObject> listOfBarriers;
    private int lightningIndex = 0;
    private int barriersIndex = 0;
    private int objectNextPosition;
    private int objectToSpawn;


    [Header("Time variables")]
    public float timer = 0;
    public float spawnerTimer;
    public float maxSpawnTime = 6;
    public float minSpawnTime = 4;

    [Header("Player")]
    public SpeedController playerSpeedController;

    // Start is called before the first frame update
    void Start()
    {
        spawnerTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnerTimer)
        {
            objectToSpawn = Random.Range(1, 4);
            switch(objectToSpawn)
            {
                case 1:
                    lightningIndex = SpawnObject(listOfLightnings, lightningIndex);
                    break;
                case 2:
                    barriersIndex = SpawnObject(listOfBarriers, barriersIndex);
                    break;
                case 3:
                    barriersIndex = SpawnObject(listOfBarriers, barriersIndex);
                    break;
            }
            timer = 0;
            spawnerTimer = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
    private int SpawnObject(List<GameObject> GOlist, int listIndex)
    {
        float Yvalue = GOlist[listIndex].transform.position.y;
        float Zvalue = 50;
        objectNextPosition = Random.Range(-1, 2);
        GOlist[listIndex].transform.position =
            new Vector3(objectNextPosition, Yvalue, Zvalue);
        GOlist[listIndex].SetActive(true);

        //Accelerate the spawn time if the speed is big
        float change = 0;
        switch(playerSpeedController.speed)
        {
            case float n when n <= 20:
                change = 0;
                break;
            case float n when n <= 40:
                change = 1;
                break;
            case float n when n > 40:
                change = 3;
                break;
        }
        minSpawnTime = 4 - change;
        maxSpawnTime = 6 - change;

        //Move to the next object index in our pool or come back to index 0
        if (listIndex < GOlist.Count - 1)
        {
            listIndex++;
            Debug.Log("Updating index " + listIndex);
        }
        else
        {
            Debug.Log("Index is 0");
            listIndex = 0;
        }

        return listIndex;
    }
}
