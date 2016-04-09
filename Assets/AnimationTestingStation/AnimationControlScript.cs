using UnityEngine;
using System.Collections;

public class AnimationControlScript : MonoBehaviour {
    /* Animation Priority:
    If multiple animation conditions are true, the top-most animation on the 'Transitions List' of the state is chosen.
     */




    Animator anim;
	// Use this for initialization
	void Start () {
        // Get the Animator component from your gameObject
        anim = GetComponent<Animator>();

        /*
        // Sets the value
        anim.SetBool("InConga", true);
        // Gets the value
        bool isInConga = anim.GetBool("InConga");*/

    }
	
	// Update is called once per frame
	void Update () {
        /* I debated using Triggers over boolean as     parameter types.
        I chose booleans because you can hold a key to spam an action after the animation ends,
        while triggers will only activate one action per keydown.
        It's possible to use 'GetKey' instead of 'GetKeyDown' to replicate this behavior with Triggers,
        but that would flood the console with debug messages. */

        handleKeyDown(KeyCode.Alpha1, "counterHit");
        handleKeyDown(KeyCode.Alpha2, "howCanSheSlap?");
        handleKeyDown(KeyCode.Alpha3, "slash");
        handleKeyDown(KeyCode.Alpha4, "parryUp");
        handleKeyDown(KeyCode.Alpha5, "shieldBash");
        handleKeyDown(KeyCode.Alpha6, "turnLeft");
        handleKeyDown(KeyCode.Alpha7, "turnRight");
        handleKeyDown(KeyCode.Alpha8, "walkForwards");
        handleKeyDown(KeyCode.Alpha9, "walkBackwards");
        handleKeyDown(KeyCode.Alpha0, "death");
        
        
        
        
        
        

        /* COPY THIS CODE!
        if (Input.GetKeyDown(KeyCode.Alpha)) {
            Debug.Log("Setting  to true");
            anim.SetBool("", true);
        }else if (Input.GetKeyUp(KeyCode.Alpha)){
            Debug.Log("Setting  to false");
            anim.SetBool("", false);
        }
        */

    }

    private void handleKeyDown(KeyCode kc, string parameter)
    {
        if (Input.GetKeyDown(kc))
        {
            Debug.Log("Setting " + parameter + " to true");
            anim.SetBool(parameter, true);
        }
        else if (Input.GetKeyUp(kc))
        {
            Debug.Log("Setting " + parameter + " to false");
            anim.SetBool(parameter, false);
        }
    }
}
