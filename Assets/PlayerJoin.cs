using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerJoin : MonoBehaviour {

    public static PlayerJoin playerjoin;

    public string fire1_P1 = "Fire1_P1";
    public string fire1_P2 = "Fire1_P2";
    public string fire1_P3 = "Fire1_P3";
    public string fire1_P4 = "Fire1_P4";

    int[] playerChars;
    List<int> characters;
    int amountPlayers = 0;
    bool P1Pressed = false, P2Pressed = false, P3Pressed = false, P4Pressed = false;

    public GameObject[] players = new GameObject[4];
    public GameObject[] playerSprites = new GameObject[4];
    public GameObject[] buttons = new GameObject[4];

    void Awake()
    {
        playerChars = new int[4];
        characters = new List<int>();

        DontDestroyOnLoad(this);

        if (playerjoin == null)
        {
            playerjoin = this;
        }
        else
        {
            Destroy(this);
        }
    }

	void Start () {
        characters.Add(1);
        characters.Add(2);
        characters.Add(3);
        characters.Add(4);
	}

    void OnLevelWasLoaded()
    {
        Debug.Log(playerChars[0] + " " + playerChars[1] + " " + playerChars[2] + " " + playerChars[3]);
        if (Application.loadedLevelName == "SebasTestScene")
        {
            for (int i = 0; i < 4; i++)
            {
                Debug.Log("Instanciating: " + players[playerChars[i] - 1]);
                if (playerChars[i] != null || playerChars[i] != 0)
                {
                    
                    GameObject a = Instantiate(players[playerChars[i] - 1], new Vector3(transform.position.x + (i * 4), transform.position.y, transform.position.z), transform.rotation) as GameObject;
                    a.GetComponent<PlayerStats>().player = i + 1;
                    a.GetComponent<PlayerStats>().character = playerChars[i];
                    a.GetComponent<PlayerStats>().SetUIBar(a.GetComponent<PlayerStats>().player);
                    a.GetComponent<PlayerStats>().SetControls(a.GetComponent<PlayerStats>().player);
                    a.GetComponent<PlayerStats>().SetColor(a.GetComponent<PlayerStats>().character);
                }
            }
        }
    }

	void Update () {

        if (Input.GetButtonDown(fire1_P1))
        {
            if (!P1Pressed)
            {
                int rnd = characters[Random.Range(0, characters.Count)];
                characters.Remove(rnd);
                playerChars[0] = rnd;
                UpdateGUI(0, rnd);
                amountPlayers++;
                P1Pressed = true;
                Debug.Log("Player1 Joined");
            }
            else if(Application.loadedLevelName == "PickScreen")
            {
                Application.LoadLevel("SebasTestScene");
            }
        }
        if (Input.GetButtonDown(fire1_P2) && !P2Pressed)
        {
            int rnd = characters[Random.Range(0, characters.Count)];
            characters.Remove(rnd);
            playerChars[1] = rnd;
            UpdateGUI(1, rnd);
            amountPlayers++;
            P2Pressed = true;
            Debug.Log("Player2 Joined");
        }
        if (Input.GetButtonDown(fire1_P3) && !P3Pressed)
        {
            int rnd = characters[Random.Range(0, characters.Count)];
            characters.Remove(rnd);
            playerChars[2] = rnd;
            UpdateGUI(2, rnd);
            amountPlayers++;
            P3Pressed = true;
            Debug.Log("Player3 Joined");
        }
        if (Input.GetButtonDown(fire1_P4) && !P4Pressed)
        {
            int rnd = characters[Random.Range(0, characters.Count)];
            characters.Remove(rnd);
            playerChars[3] = rnd;
            UpdateGUI(3, rnd);
            amountPlayers++;
            P4Pressed = true;
            Debug.Log("Player4 Joined");
        }
	}

    void UpdateGUI(int player, int character)
    {
        buttons[player].SetActive(false);
        playerSprites[character - 1].SetActive(true);
        Vector3 newPos = new Vector3(playerSprites[character - 1].GetComponent<RectTransform>().position.x + (player * 161.7f), playerSprites[character - 1].GetComponent<RectTransform>().position.y, playerSprites[character - 1].GetComponent<RectTransform>().position.z);
        playerSprites[character - 1].GetComponent<RectTransform>().position = newPos;
    }
}
