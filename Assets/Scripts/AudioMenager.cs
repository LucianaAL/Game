using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenager : MonoBehaviour {

	[SerializeField]
	AudioSource somApito;

	public AudioSource Som{
		get{
			return somApito; 
		}
	}
}
