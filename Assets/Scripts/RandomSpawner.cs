using UnityEngine;
using System.Collections;

public class RandomSpawner : MonoBehaviour {


    private Object[] spawnableObjects;
    public float showTime = 3.0f;
    private float timeLeft;


    private GameObject currentObject;
    private int index;

    public float rotSpeed;
    public bool iterateBackwards = false;


	// Use this for initialization
	void Start () {
        spawnableObjects = Resources.LoadAll("AnimationFolderA/PROPS", typeof(GameObject));
        index = iterateBackwards ? spawnableObjects.Length - 1: -1;
        timeLeft = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeLeft <= 0) {
            if (!iterateBackwards) {
                index = index == spawnableObjects.Length - 1 ? 0 : index + 1;
            } else {
                index = index == 0 ? spawnableObjects.Length - 1 : index - 1;
            }

            // Debug.Log(index);
            if (currentObject) Destroy(currentObject);
            currentObject = Instantiate(spawnableObjects[index], transform.position, Quaternion.identity) as GameObject;
            currentObject.transform.localScale = new Vector3(1, 1, 1);
            timeLeft = 3.0f;
        }

        float rot = rotSpeed * Time.deltaTime;
        if (iterateBackwards) rot *= -1;
        currentObject.transform.Rotate(new Vector3(rot, rot, rot));

        timeLeft -= Time.deltaTime;
    }
}
