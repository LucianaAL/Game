using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour {

	int cont;
	[SerializeField]
	GameObject prefabBall;
	[SerializeField]
	Transform posicao;

	void Start () {
		cont = 0;	
	}

	void Update () {
		cont++;
		if (cont % 613 == 0) {
			GameObject bola = Instantiate (prefabBall, posicao.position, Quaternion.identity);
		}
	}
}
