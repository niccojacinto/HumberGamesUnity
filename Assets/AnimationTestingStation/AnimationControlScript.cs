using UnityEngine;
using System.Collections;

/*Somehow, this class is responsible for both animation triggers and character movement. */
[RequireComponent(typeof(Character))]
public class AnimationControlScript : MonoBehaviour {
    /* Animation Priority:
    If multiple animation conditions are true, the top-most animation on the 'Transitions List' of the state is chosen.
     */


    Transform myTransform;
    Character character;
    public float speed = 10.0F;
    public float rotationSpeed = 300.0F;
    public string verticalInputAxis;
    public string horizontalInputAxis;
    public string slash;

    Animator anim;
	// Use this for initialization
	void Start () {
        // Get the Animator component from your gameObject
        anim = GetComponent<Animator>();
        myTransform = transform;
        character = GetComponent<Character>();

        if (speed == 0 || rotationSpeed == 0 || verticalInputAxis == null || horizontalInputAxis == null)
        {
            throw new System.Exception("Uninitialized properties in script AnimationControlScript.");
        }
    }
	
	// Update is called once per frame
	void Update () {
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


        // Debug.Log(Input.GetAxisRaw("Vertical2") + ", " + Input.GetAxisRaw("Horizontal2"));

        float translation = Input.GetAxis(verticalInputAxis) * speed;
        float rotation = Input.GetAxis(horizontalInputAxis) * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        myTransform.Translate(0, 0, translation);
        myTransform.Rotate(0, rotation, 0);

        // Player1: WASD - Player2: IJKL
        // Should also work if you plug in a joystick
        if (Input.GetAxisRaw(verticalInputAxis) > 0) {
            anim.SetBool("walkForwards", true);
            anim.SetBool("walkBackwards", false);
        } else if (Input.GetAxisRaw(verticalInputAxis) < 0 ) {
            anim.SetBool("walkForwards", false);
            anim.SetBool("walkBackwards", true);
        } else {
            anim.SetBool("walkForwards", false);
            anim.SetBool("walkBackwards", false);
        }
    }

    /* I debated using Triggers over boolean as     parameter types.
        I chose booleans because you can hold a key to spam an action after the animation ends,
        while triggers will only activate one action per keydown.
        It's possible to use 'GetKey' instead of 'GetKeyDown' to replicate this behavior with Triggers,
        but that would flood the console with debug messages. */
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
