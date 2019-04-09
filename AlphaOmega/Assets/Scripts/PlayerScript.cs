using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private bool evil = false; 
    public int position = 0; //0 bedeutet Olymp, 1 bedeutet Hades, 2 bedeutet Tartarus
    public int role = -1; //Nummerierung für die Rollen
    public string roleName = "";
    public Sprite roleSprite;
    private Database manager;

	// Use this for initialization
	void Awake () {
        manager = GameObject.FindWithTag("GameController").GetComponent<Database>();

	}

  
    public void AssignRole() {
        if (role == 0)
        {
            roleName = manager.AphroditeName;
            roleSprite = manager.AphroditeSprite;
        }
        else if (role == 1)
        {
            roleName = manager.HephaistosName;
            roleSprite = manager.HephaistosSprite;
        }
        else if (role == 2)
        {
            roleName = manager.HeliosName;
            roleSprite = manager.HeliosSprite;
        }
        else if (role == 3)
        {
            roleName = manager.ArtemisName;
            roleSprite = manager.ArtemisSprite;
        }
        else if (role == 4)
        {
            roleName = manager.AsklepiosName;
            roleSprite = manager.AsklepiosSprite;
        }
        else if (role == 5)
        {
            roleName = manager.HeraName;
            roleSprite = manager.HeraSprite;
        }
        else if (role == 6)
        {
            roleName = manager.AresName;
            roleSprite = manager.AresSprite;
        }
        else if (role == 7)
        {
            roleName = manager.HermesName;
            roleSprite = manager.HermesSprite;
        }
        else if (role == 8)
        {
            roleName = manager.DionysosName;
            roleSprite = manager.DionysosSprite;
        }
        else if (role == 9)
        {
            roleName = manager.AthenaName;
            roleSprite = manager.AthenaSprite;
        }
        else if (role == 10)
        {
            roleName = manager.HekateName;
            roleSprite = manager.HekateSprite;
        }
        else if (role == 11)
        {
            roleName = manager.PoseidonName;
            roleSprite = manager.PoseidonSprite;
        }

    }

    public bool GetAlignment() {
        return evil;
    }

    public void FlipAlignment() {
        evil = !evil;
    }
}
