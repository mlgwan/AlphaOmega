using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raffle : MonoBehaviour {
    private System.Random _random = new System.Random();
    public GameObject player;
    GameObject[] players;
    int[] array;
    int amountOfPlayers = 10;
    int amountOfRoles = 12;
    // Use this for initialization
    void Start () {
        players = getPlayers();                       //Spieler werden in einem Array gesammelt
        FillArray(amountOfRoles);          //Ein gleichgroßes Array wird erstellt und mit Zahlen befüllt
        Shuffle(array);                     //Dieses Array wird "gemischt", sodass eine zufälllige Reihenfolge entsteht
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerScript>().role = array[i];    //Die Rolle jedes Spielers wird durch die Zufallszahlen
            players[i].GetComponent<PlayerScript>().AssignRole();                                                            //ersetzt, sodass jeder eine einzigartige Rolle bekommt
        }

        GameObject.FindWithTag("GameController").GetComponent<GameManagerScript>().AssignCharacteInfo();
     

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

        GameObject[] players = new GameObject[amountOfPlayers];
        for (int i = 0; i < amountOfPlayers; i++) {
            players[i] = Instantiate(player);
            players[i].name = "Player" + (i + 1);
        }
        return players;
    }

    void FillArray(int length) {
        array = new int[length];
        for (int i = 0; i < length; i++) {
            array[i] = i;   
        }
    }
}
