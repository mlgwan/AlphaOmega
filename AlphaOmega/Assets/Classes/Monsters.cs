using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour{
	public float strengh;
	public float defense;
	public string element;
	public float airMul;
	public float waterMul;
	public float groundMul;
	public float speed;

	float attack(string element, float defense){
		float damage = 0;

		if(element == "water"){
			damage = strengh * waterMul - defense / waterMul;
		}
		if(element == "air"){
			damage = strengh * airMul - defense / airMul;
		}
		if(element == "ground"){
			damage = strengh * groundMul - defense / groundMul;
		}

		return damage;
	}

}
