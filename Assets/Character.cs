using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float speed;
    [Range(0.0f, 100.0f)]
    public float slowPercent;
    private float slowRate { get { return slowPercent / 100f; } }

    public GameObject TrailerObject;
    public float TrailerDistnace;

    private Vector3 lastTrailerPosition;


    private Quaternion lookatRotation;

    private Rigidbody rb;
    private float defaultHeight;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        //We don't want the physics to change how the 
        // rb.freezeRotation = true;
        defaultHeight = rb.transform.position.y;

        lastTrailerPosition = rb.position;
        
	}
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal") * -1;
        float moveVertical = Input.GetAxis("Vertical") * -1;

        Vector3 position = rb.transform.position;
        position.y = defaultHeight;
        rb.transform.position = position;

        Vector3 velocity = rb.velocity;

        if (moveHorizontal == 0)
            velocity.x *= slowRate;

        if (moveVertical == 0)
            velocity.z *= slowRate;

        velocity.y = 0;

        rb.velocity = velocity;

        //velocity.y = 0;

        //rb.velocity = velocity;

        Vector3 newDirection;// = Vector3.RotateTowards(rb.transform.forward.normalized, forceVector.normalized, .1f, 0f);

        Vector3 forceVector = new Vector3(moveHorizontal, 0f, moveVertical);
        if (forceVector.magnitude == 0)
        {
            newDirection =  rb.transform.forward;
 //           Debug.Log("0Magnitude: " + forceVector.magnitude + " newDirection: " + newDirection);
        }
        else
        {
            newDirection =  Vector3.RotateTowards(rb.transform.forward, forceVector, .1f, 0f);
 //           Debug.Log("SMagnitude: " + forceVector.magnitude + " newDirection: " + newDirection);
        }

//        Debug.Log("Velocity Vector: " + velocity.normalized);
//        Debug.Log("Angular: " + rb.angularVelocity);


       
//        Debug.Log("Forward" + newDirection);

//        Debug.DrawRay(rb.transform.position, newDirection, Color.red, 1f);
 //       Debug.DrawRay(transform.position, newDirection, Color.blue, 1f);

        //lookatRotation = Quaternion.LookRotation(velocity.normalized);
        //rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, lookatRotation, Time.deltaTime);

        var forcy = newDirection * forceVector.magnitude * speed;
 //       Debug.Log("Forcy: " + forcy);
        rb.AddForce(newDirection * forceVector.magnitude * speed);
        rb.transform.forward = newDirection;

        float distance = Vector3.Distance(rb.position, lastTrailerPosition);

        if(distance >= TrailerDistnace)
        {
            CreateTrail();
        }
        

	}
    
    void CreateTrail()
    {
        GameObject trailer = Instantiate(TrailerObject);
        //Rigidbody trailerBody = trailer.GetComponent<Rigidbody>();
        trailer.transform.position = rb.position - rb.transform.forward.normalized;
        //trailerBody.position = rb.position;

        lastTrailerPosition = rb.position;
    }
}
