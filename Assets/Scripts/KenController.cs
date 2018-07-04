using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KenController : MonoBehaviour {

	[SerializeField]
	Image barraEnergiaKen;
	[SerializeField]
	GameObject prefabHaduken;
	[SerializeField]
	Transform localHaduken;

	float energiaAtual = 0;
	float vel = 275f;
	float force = 475f;
	float energiaMaxima = 10f;
	Rigidbody2D rb2d;
	Animator anim;

	float r;
	int cont;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update () {

		barraEnergiaKen.rectTransform.sizeDelta = new Vector2 ((energiaAtual / energiaMaxima) * 112, 17);

		r = Random.Range (0f, 1f);
		cont++;

		movimento ();
		pulo ();
		Haduken ();
		retornaVel ();
	}

	void pulo(){
		var absY = Mathf.Abs (rb2d.velocity.y);
		if (Input.GetKeyDown (KeyCode.W) && absY <= 0.05f) {
			rb2d.AddForce (new Vector2 (rb2d.velocity.x, force));
			anim.SetBool ("kenPulando", true);
		} else {
			anim.SetBool ("kenPulando", false);
		}

	}
	void movimento(){
		if (Input.GetKey (KeyCode.D)) {
			rb2d.velocity = new Vector2 (vel * Time.fixedDeltaTime, rb2d.velocity.y);
			anim.SetBool ("andando", true);
		} else {
			rb2d.velocity = new Vector2 (0f, rb2d.velocity.y);
			anim.SetBool ("andando", false);
		}

		if (Input.GetKey (KeyCode.A)) {
			rb2d.velocity = new Vector2 (-vel * Time.fixedDeltaTime, rb2d.velocity.y);
			anim.SetBool ("andandoEsquerda", true);
		} else {
			anim.SetBool ("andandoEsquerda", false);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			anim.SetBool ("kenChutando", true);
		} else {
			anim.SetBool ("kenChutando", false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (energiaAtual < energiaMaxima) {
			if (Input.GetKey(KeyCode.C) && other.CompareTag ("bola")) {
				energiaAtual = energiaAtual + 1f;
			}
			if (other.CompareTag ("goldball")) {
				if (r < 0.5f) {
					//aumenta energia
					aumentaEnergia();
				}else{
					//reduzir vel
					reduzVel();
					cont = 0;
				}
				Destroy (GameObject.FindWithTag ("goldball"));
			}
		}
	}

	void Haduken(){
		if (energiaAtual == energiaMaxima) {

			//Solta Haduken
			GameObject prefabTemp = Instantiate (prefabHaduken, localHaduken.position, Quaternion.identity);
			prefabTemp.GetComponent<Rigidbody2D> ().AddForce (new Vector2(200f, 0f));
			energiaAtual = 0;

		}
	}
	void aumentaEnergia(){
		if (energiaAtual >= 7f) {
			energiaAtual = 10f;
		} else {
			energiaAtual = energiaAtual + 3f;
		}
	}
	void reduzVel(){
		vel = 125f;
	}
	void retornaVel(){
		if (cont == 300) {
			vel = 275f;
		}
	}
}
