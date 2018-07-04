using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RyuController : MonoBehaviour {
	[SerializeField]
	Image barraEnergiaRyu;
	[SerializeField]
	GameObject prefabHaduken;
	[SerializeField]
	Transform localHaduken;

	float r;
	int cont;

	float energiaAtual = 0;
	float vel = 275f;
	float force = 475f;
	float energiaMaxima = 10f;

	Rigidbody2D rb2d;

	Animator anim;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}

	void Update () {
		barraEnergiaRyu.rectTransform.sizeDelta = new Vector2 ((energiaAtual / energiaMaxima) * 112, 17);

		r = Random.Range (0f, 1f);
		cont++;

		movimento ();
		pulo ();
		Haduken ();	
		retornaVel ();
	}

	void pulo(){
		var absY = Mathf.Abs (rb2d.velocity.y);
		if (Input.GetKeyDown (KeyCode.I) && absY <= 0.05f) {
			rb2d.AddForce (new Vector2 (rb2d.velocity.x, force));
			anim.SetBool ("ryuPulando", true);
		} else {
			anim.SetBool ("ryuPulando", false);
		}

	}
	void movimento(){
		if (Input.GetKey (KeyCode.L)) {
			rb2d.velocity = new Vector2 (vel * Time.fixedDeltaTime, rb2d.velocity.y);
			anim.SetBool ("ryuAndandoDireita", true);
		} else {
			rb2d.velocity = new Vector2 (0f, rb2d.velocity.y);
			anim.SetBool ("ryuAndandoDireita", false);
		}

		if (Input.GetKey (KeyCode.J)) {
			rb2d.velocity = new Vector2 (-vel * Time.fixedDeltaTime, rb2d.velocity.y);
			anim.SetBool ("ryuAndando", true);
		} else {
			anim.SetBool ("ryuAndando", false);
		}

		if (Input.GetKeyDown (KeyCode.N)) {
			anim.SetBool ("ryuChutando", true);
		} else {
			anim.SetBool ("ryuChutando", false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (energiaAtual < energiaMaxima) {
			if (Input.GetKey(KeyCode.N) && other.CompareTag ("bola")) {
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
			//Soltar Haduken!!
			GameObject prefabTemp = Instantiate (prefabHaduken, localHaduken.position, Quaternion.identity);
			prefabTemp.GetComponent<Rigidbody2D> ().AddForce (new Vector2(-200f, 0f));
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