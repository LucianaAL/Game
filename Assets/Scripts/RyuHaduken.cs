using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyuHaduken : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("ken")){
			Destroy (this.gameObject);
		}
	}
}
