using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//Attach this onto the camera. This Script will grab the camera, and send Rays based on click input. If a Ray collides
//with a collider on the Interactive Layer, it will send a message to call the OnInteract() function on the object.
public class Cam_FPSInteract_Mobile : MonoBehaviour {


    public float interactRange = 100f;
    public float timeBetweenInteract = 0.15f;

    float timer;
    RaycastHit rayHit;
    int interactiveMask;
    private Camera cameraForRay;

    //use slider for interactions
    public Slider interactSlider;
    //how far to move slider on interact
    public float sliderIncrement = 0.01f;

    void Awake()
    {
        //Set the Mask variable to the Interactive layer
        interactiveMask = LayerMask.GetMask("Interactive");
        //Get camera Component
        cameraForRay = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //increment time
        timer += Time.deltaTime;

        //Debug Ray
        //Debug.DrawRay(transform.position, Vector3.forward * interactRange, Color.magenta);

        //if enough time has passed, interact
        if (Input.GetButtonDown("Fire1") && timer >= timeBetweenInteract)
        {
            //Debug.Log("I pressed a button");
            Interact();

        }

        //if there is an interact slider
        if (interactSlider != null)
        {
            MoveSlider();
        }


    }

    void MoveSlider()
    {

    }

    public void DisableEffects()
    {
        //interactLight.enabled = false;
    }

    void Interact()
    {


        //reset timer
        timer = 0f;

        //declare ray at camera position and mouse click direction
        Ray interactRay = cameraForRay.ScreenPointToRay(Input.mousePosition);

        //If the raycast detects a collider on the Interactive layer
        if (Physics.Raycast(interactRay, out rayHit, interactRange, interactiveMask))
        {
            //Debug.Log("I shot a ray and hit" + rayHit.collider.gameObject.name);
            rayHit.collider.gameObject.SendMessage("OnInteract",SendMessageOptions.DontRequireReceiver);
        }


    }
}
