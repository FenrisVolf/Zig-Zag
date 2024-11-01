using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class BallController : MonoBehaviour
{
    public GameObject Particle;
    [SerializeField]
    private float speed;
    bool started;
    bool gameOver;
    Rigidbody rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        started = false;
        gameOver = false;
    }

    void Update()
    {
        if (!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3 (speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();
        }

        if(Input.GetMouseButtonDown(0) && !gameOver) 
        {
            SwitchDirection();
        }

        void SwitchDirection()
        {
            if(rb.velocity.z > 0)
            {
                rb.velocity = new Vector3(speed, 0,0);
            }
            else if(rb.velocity.x > 0)
            {
                rb.velocity = new Vector3(0, 0, speed);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(Particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy (col.gameObject);
            Destroy (part, 3f);
        }
    }
}
