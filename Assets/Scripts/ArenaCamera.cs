using UnityEngine;
using System.Collections;

public class ArenaCamera : MonoBehaviour {

    [SerializeField]
    private GameObject obj1;
    [SerializeField]
    private GameObject obj2;

    public const float MIN_ZOOM= 4;
    public const float MAX_ZOOM = 12;

    public const float MIN_PITCH = 2;
    public const float MAX_PITCH = 8;

    public bool use360Camera = true;

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


        float angle;
        if (!use360Camera) {
            angle = Vector3.Angle(p1, p2);
        } else {
            Vector3 rot = transform.rotation.eulerAngles;
            float yComp = rot.y;
            angle = 180 + Mathf.Atan2(p2.x - p1.x, p2.y - p1.y) * Mathf.Rad2Deg; // to Degrees
            angle = Mathf.LerpAngle(yComp, angle, Time.deltaTime);
        }
        // Debug.Log(angle);

        transform.eulerAngles = new Vector3(0, angle, 0);

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
