using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raffle : MonoBehaviour {
    private System.Random _random = new System.Random();
    GameObject[] players;
    int[] array;
    // Use this for initialization
    void Start () {
        getPlayers();                       //Spieler werden in einem Array gesammelt
        fillArray(players.Length);          //Ein gleichgroßes Array wird erstellt und mit Zahlen befüllt
        Shuffle(array);                     //Dieses Array wird "gemischt", sodass eine zufälllige Reihenfolge entsteht
        foreach (int value in array)
        {
            players[value].GetComponent<PlayerScript>().role = array[value];    //Die Rolle jedes Spielers wird durch die Zufallszahlen
            
        }                                                                        //ersetzt, sodass jeder eine einzigartige Rolle bekommt
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Shuffle(int[] array)
    {
        int p = array.Length;
        for (int n = p - 1; n > 0; n--)
        {
            int r = _random.Next(0, n);
            int t = array[r];
            array[r] = array[n];
            array[n] = t;
            
        }
    }

    GameObject[] getPlayers() {
        
        players = GameObject.FindGameObjectsWithTag("Player");
        return players;
    }

    void fillArray(int length) {
        array = new int[length];
        for (int i = 0; i < length; i++) {
            array[i] = i;   
        }
    }
}
