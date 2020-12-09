using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cam_FPSInteract : MonoBehaviour {

    public float interactRange = 100f;
    public float timeBetweenInteract = 0.15f;

    public Slider interactSlider;
    public float sliderIncrement = 0.01f;

    float timer;
    //Ray interactRay;
    RaycastHit rayHit;
    int interactiveMask;

    void Awake()
    {
        //initialize all the variables
        interactiveMask = LayerMask.GetMask("Interactive");
    }
	
	// Update is called once per frame
	void Update () {
        //increment time
        timer += Time.deltaTime;

        //if enough time has passed, interact
        if(Input.GetButtonDown("Fire1") && timer >= timeBetweenInteract)
        {
            //Debug.Log("I pressed a button");
            Interact();
            
        }


	}

    //Shoot Interact Ray from camera
    void Interact()
    {

        //reset timer
        timer = 0f;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out rayHit, interactRange, interactiveMask))
        {
            //Debug.Log("I shot a ray and hit" +rayHit.collider.gameObject.name);
            rayHit.collider.gameObject.SendMessage("OnInteract",SendMessageOptions.DontRequireReceiver);
        }


    }
}
