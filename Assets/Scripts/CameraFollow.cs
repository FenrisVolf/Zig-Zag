using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    Vector3 offSet;
    public float lerpRate;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        offSet = ball.transform.position - transform.position;
        gameOver = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offSet;
        pos = Vector3.Lerp (pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
