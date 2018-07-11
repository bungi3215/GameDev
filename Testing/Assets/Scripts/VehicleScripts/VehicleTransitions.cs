using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleTransitions : MonoBehaviour
{
    public Transform InstantiatePlayer;
    public Transform cam;
    public GameObject exitPoint;
    public GameObject entryPoint;
    public bool EntryReady = false;
    private GameObject player;


    void Update()
    {
        
        /******
        * Check if player wants to enter or exit a vehicle
        ******/

        player = GameObject.FindWithTag("PlayerFps");

        if (Input.GetKeyDown("f"))
        {
            if (GameManager.isInsideVehicle == true)
            {
                //Set inside vehicle to false
                GameManager.isInsideVehicle = false;

                //Destroy camera on ship
                Destroy(GameObject.FindWithTag("MainCamera"));

                //Instantiate the player outside the vehicle
                Instantiate(InstantiatePlayer, exitPoint.transform.position, exitPoint.transform.rotation);

                //Set gravity on for vehicle
                gameObject.GetComponent<Rigidbody>().useGravity = true;

            }
            else
            {

                // Check for distance if outside of Vehicle
                if (MeasureDistance.checkDistance(6.5, player, entryPoint) == true && GameManager.hoveredObject == "shipEnterPoint")
                {
                    //Set inside to true
                    GameManager.isInsideVehicle = true;
                    
                    //destroy player
                    Destroy(GameObject.FindWithTag("PlayerFps"));
                    
                    //Create new camera
                    GameObject cameraPosition = GameObject.FindWithTag("ThirdPersonCameraShip");
                    var camera = Instantiate(cam, cameraPosition.transform.position, cameraPosition.transform.rotation);
                    camera.transform.parent = gameObject.transform;

                    //Set the vehicle to not use gravity (Only for space ships)
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            }
           
            //Reset hovered object, since it never made an exit
            GameManager.hoveredObject = "";
        }
    }
}
