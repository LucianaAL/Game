using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarcaGolController : MonoBehaviour {
	
	[SerializeField]
	Text placarEsquerda;

	[SerializeField]
	Text placarDireita;

	[SerializeField]
	Transform posKen, posRyu, posBola;

	[SerializeField]
	GameObject ken, ryu, bola;

	[SerializeField]
	AudioSource apito;

	int contDireita = 0, contEsquerda = 0;

	public AudioMenager audioManager;

	void Start(){
		PlayerPrefs.SetInt ("golRyu", 0);
		PlayerPrefs.SetInt ("golKen", 0);
		apito = GetComponent<AudioSource> ();
		audioManager = FindObjectOfType<AudioMenager> ();
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag ("esquerda")) {
			audioManager.Som.Play ();
			contEsquerda ++;
			placarEsquerda.text = contEsquerda.ToString ();
			ken.transform.position = posKen.transform.position;
			ryu.transform.position = posRyu.transform.position;
			bola.transform.position = posBola.transform.position;
			PlayerPrefs.SetInt ("golRyu", contEsquerda);

		}

		if (other.CompareTag ("direita")) {
			audioManager.Som.Play ();
			contDireita ++;
			placarDireita.text = contDireita.ToString ();
			ken.transform.position = posKen.transform.position;
			ryu.transform.position = posRyu.transform.position;
			bola.transform.position = posBola.transform.position;
			PlayerPrefs.SetInt ("golKen", contDireita);

		}

		if (Input.GetKey(KeyCode.N) && other.CompareTag ("ryu")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-8f, 4f));
		}
	
		if (Input.GetKey(KeyCode.C) && other.CompareTag ("ken")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (8f, 4f));
		}
		if (other.CompareTag ("kenHaduken")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (10f, 5f));
		}
		if (other.CompareTag ("ryuHaduken")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-10f, 5f));
		}
			
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("voltaEsquerda")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (1f, 1f));
		}
		if (other.CompareTag ("voltaDireita")) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-1f, 1f));
		}
	}
}
