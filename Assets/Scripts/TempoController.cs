using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempoController : MonoBehaviour {

	[SerializeField]
	Text tempo;

	float contadorTempo = 90f, delay = 0.7f;

	int golsKen, golsRyu;
	public AudioMenager audioManager;

	void Start () {
		audioManager = FindObjectOfType<AudioMenager> ();
	}

	void Update () {
		if (contadorTempo > 0f) {
			contadorTempo -= Time.deltaTime;
			tempo.text = contadorTempo.ToString ("F0");
		} else {
			golsKen = PlayerPrefs.GetInt ("golKen");
			golsRyu = PlayerPrefs.GetInt ("golRyu");
			tempo.text = "FIM!";
			audioManager.Som.Play ();
			if (golsKen > golsRyu) {
				delay -= Time.deltaTime;
				if (delay <= 0f) {
					SceneManager.LoadScene ("KenGanhou");
				}
				//Carregar cena Ganhou KEN!!!

			}
			if (golsRyu > golsKen) {
				delay -= Time.deltaTime;
				if (delay <= 0f) {
					SceneManager.LoadScene ("RyuGanhou");
				}
				//Carregar cena Ganhou RYU!!!

			}
			if(golsKen == golsRyu){
				delay -= Time.deltaTime;
				if (delay <= 0f) {
					SceneManager.LoadScene ("Empate");
				}
				//Carregar cena EMPATE!!!
			}
		}
	}
}
