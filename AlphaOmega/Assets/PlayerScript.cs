using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private bool evil = false; 
    public int position = 0; //0 bedeutet Olymp, 1 bedeutet Hades, 2 bedeutet Tartarus
    public int role = -1; //Nummerierung für die Rollen
    public string roleName = "";

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (role == 0)
        {
            roleName = "Aphrodite";
        }
        else if (role == 1)
        {
            roleName = "Hephaestos";
        }
        else if (role == 2)
        {
            roleName = "Helios";
        }
        else if (role == 3)
        {
            roleName = "Artemis";
        }
        else if (role == 4)
        {
            roleName = "Apollon";
        }
        else if (role == 5)
        {
            roleName = "Hera";
        }
        else if (role == 6)
        {
            roleName = "Ares";
        }
        else if (role == 7)
        {
            roleName = "Hermes";
        }
        else if (role == 8)
        {
            roleName = "Dionysos";
        }
        else if (role == 9)
        {
            roleName = "Heracles";
        }

    }

    public bool getAlignment() {
        return evil;
    }

    public void flipAlignment() {
        evil = !evil;
    }
}
