using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarCena : MonoBehaviour {

	float delay = 0.7f;
	bool trocaCena;

	void Start(){
		PlayerPrefs.SetString ("cena", null);
	}

	void Update(){
		if (trocaCena) {
			delay -= Time.deltaTime;
			if (delay <= 0.0f) {
				SceneManager.LoadScene (PlayerPrefs.GetString("cena"));
			}
		}
	}


	public void CarregaCena(string cena){
		trocaCena = true;
		PlayerPrefs.SetString ("cena", cena);
	}
}
