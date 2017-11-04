using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entardecendo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(10f * Time.deltaTime, 0, 0); // quanto menos o valor...mais demorado fica
    }
}
