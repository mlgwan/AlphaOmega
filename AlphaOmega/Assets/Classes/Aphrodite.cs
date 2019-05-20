using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Aphrodite : Classes
{
	private Boolean skillUsed = false;
	public Aphrodite(int id, string team){
		/* TODO BALANCE
		strengh = ;
		airMul = ;
		waterMul = ;
		groundMul = ;
		defense = ; 
		speed = ;
		*/
		this.id = id;
		this.team = team;
	}
	void skill(int id){
		//TODO FREUND FEIND ERKENNUNG
		/*for (int i = 0, i < game.classes.size, i++){
			if(game.players[i] == id){
				game.classes[i].team = this.team;
				break;
			}
		}*/
		return;
	}
}
