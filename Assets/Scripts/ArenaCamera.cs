using UnityEngine;
using System.Collections;

public class ArenaCamera : MonoBehaviour {

    [SerializeField]
    private GameObject obj1;
    [SerializeField]
    private GameObject obj2;

    public const float MIN_ZOOM= 2;
    public const float MAX_ZOOM = 12;

    public const float MIN_PITCH = 2;
    public const float MAX_PITCH = 12;

    public float angle;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 p1 = obj1.transform.position;
        Vector3 p2 = obj2.transform.position;
        Vector3 newVector = transform.position;

        // Move the camera to the center of the two objects
        newVector = Vector3.Lerp(p1, p2, 0.5f);
        Vector3 center = newVector;

        angle = Vector3.Angle(p1, p2);
        transform.rotation = Quaternion.Euler(0, angle, 0);

        // Maintain Zoom factor
        float mag = (p2 - p1).magnitude;
        float zoom = Mathf.Clamp(mag, MIN_ZOOM, MAX_ZOOM);
        float pitch = Mathf.Clamp(mag, MIN_PITCH, MAX_PITCH);

        newVector += (transform.forward * -zoom);
        newVector += new Vector3(0, pitch, 0);

        // Update Postiion
        transform.position = newVector;
        transform.LookAt(center);
    }

}
