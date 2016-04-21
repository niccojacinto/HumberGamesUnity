using UnityEngine;
using System.Collections;

public class ColorChange : MonoBehaviour {

    public Color color;

	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        Material newMat = new Material(Shader.Find("Standard"));
        newMat.color = color;
        rend.material = newMat;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
