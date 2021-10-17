using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target : MonoBehaviour
{
    private GameManager gameManager; 
    private Rigidbody objectsRb;
    public ParticleSystem objectParticle;
    private float minSpeed = 10.0f;
    private float maxSpeed = 15.0f;
    private float maxTorque = 15.0f;
    private float minTorque = -15.0f;
    private float xRange = 4.5f;
    private float ySpawnPos = -2.0f;
    public int pointValue;
    void Start()
    {
        objectsRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); //taking reference from game manager class to use  their functions etc..


        objectsRb.AddForce(RandomForce(), ForceMode.Impulse); // adding instant force to the object in the direction of -y to +y
        objectsRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); //adding torque to the objects
        transform.position = RandomSpawnPos();  // positioning the objects between -5 to 5 on  the x axis, -5 on the y axis
    }

    // Update is called once per frame
    void Update()
    { 
    }

    private void OnMouseDown() // click event of mouse
    {
        Destroy(gameObject);
        Instantiate(objectParticle, transform.position, objectParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        
        
    }
    private void OnTriggerEnter(Collider other) // ıt works with an objects which has box collider and its 'is triggered method is checked'
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.gameOver();
        }
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-minTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }

}
