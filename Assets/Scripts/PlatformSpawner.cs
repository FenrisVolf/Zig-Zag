using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Diamonds;
    Vector3 lastPos;
    float size;
    public bool gameOver;

    void Start()
    {
        lastPos = Platform.transform.position;
        size = Platform.transform.localScale.x;
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f); 
    }

    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }        
    }

    void SpawnPlatforms()
    {
        
          int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(Platform, pos, Quaternion.identity);
        //Spawning Diamonds
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(Diamonds, new Vector3(pos.x, pos.y + 1, pos.z), Diamonds.transform.rotation );
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(Platform, pos, Quaternion.identity);
        //Spawning Diamonds
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(Diamonds, new Vector3(pos.x, pos.y + 1, pos.z), Diamonds.transform.rotation );
        }
    }
}