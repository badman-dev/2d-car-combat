using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_playerLocater : MonoBehaviour
{
    public float maxSpeed;
    private bool playerInSight = false;
    private GameObject Player;
    private GameObject Enemy;
    public Rigidbody2D rb;
    public double detectionRadius;
    private float negativeDistance = -1;
    public float acceleration;
    public float reverse;
    public float strength;
    public float rotationSpeed;
    float targetAngle;  
    Vector3 playerLocation;
    Vector3 playerTarget;
    // Start is called before the first frame update
    void Start()
    {
        //waypoints[waypointIndex].transform.position = transform.position;
        
    }

    private void Awake()
    {
        //Finding the Enemy and player GameObjects and setting them equal to their respective variables
        Player = GameObject.Find("playerCar");
        Enemy = GameObject.Find("Enemy");
    }
    // Update is called once per frame
    void Update()
    {
       // Debug.Log(rb.rotation); 
         //Finding the Distance from the player 
            Vector2 distanceFromPlayer = Player.transform.position - Enemy.transform.position;
         //Finding Player Location
           // playerLocation = Player.transform.position;
            playerTarget = Player.transform.position - transform.position;
         //Targeting Player Location
          //  playerTarget.z = 0f;
           // playerTarget.x = playerTarget.x - playerLocation.x;
           // playerTarget.y = playerTarget.y - playerLocation.y;
            targetAngle = Mathf.Atan2(playerTarget.y, playerTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(targetAngle-90, Vector3.forward);
            // Makes sure the distance from the player is always  positive number since you can not have negative distance
            if (distanceFromPlayer.x < 0)
            {
                distanceFromPlayer.x = distanceFromPlayer.x * negativeDistance;
            }
            if (distanceFromPlayer.y < 0)
            {
                distanceFromPlayer.y = distanceFromPlayer.y * negativeDistance;
            } 
            //checking to see if the Enemy can "See" the player , will lead into code that has AI follow/attack
            if (distanceFromPlayer.x <= detectionRadius && distanceFromPlayer.y <= detectionRadius)
            {
                 // transform.rotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));
                Vector2 dir = Player.transform.position - transform.position;
               // Debug.Log("Sees player is true");
                playerInSight = true;
                Vector2 forward = Enemy.transform.up;
                float angle = Vector2.Angle(dir, forward);
                Debug.Log(angle);
                //player is in front of AI
                if (angle <=90)
                {
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
                Vector2 speed = transform.up * (-1 * acceleration - (reverse * -1 * acceleration));
                    rb.AddForce(speed);
                rb.angularVelocity = 0;
            }
                //player is behind AI
                else 
                {
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
                Vector2 speed = transform.up * (1 * acceleration - (reverse * 1 * acceleration));
                    rb.AddForce(speed);
                rb.angularVelocity = 0;
            }
            }
            // If Enemy cannot "See" the player then it will continue with predetermined path
            else
            {
               // Debug.Log("Sees player is false");
                playerInSight = false;

            }
            // Force max speed limit
         if (rb.velocity.magnitude > maxSpeed)
         {
             rb.velocity = rb.velocity.normalized * maxSpeed;
         }
         //currentSpeed = rb.velocity.magnitude;
        
    }

}
   


