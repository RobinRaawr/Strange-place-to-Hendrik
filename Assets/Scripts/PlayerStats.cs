using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour {

    public int health = 3;
    private bool dead = false;

    private Color[] color;
    public int player = 1;
    public int character = 4;
    GameObject UIStats;

    void Awake()
    {
        color = new Color[4];
        float a = 0.8f;
        float s = 1f;
        float w = 0.4f;
        color[0] = new Color(s, w, w, a);
        color[1] = new Color(w, s, w, a);
        color[2] = new Color(w, w, s, a);
        color[3] = new Color(s, 0.65f, 0.1f, a);
        //Set the right stats to the right person with the right color
        SetUIBar(player);
        SetColor(character);
    }

    void Update()
    {
        if (dead)
        { 
            //TODO: play dead animation
            //TODO: actually die(remove from game, or lay their being dead
        }
    }

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            Transform hart = UIStats.transform.Find("Hart" + health);
            hart.gameObject.SetActive(false);
        }
        //TODO: take damage animation
        //Take knockdown effect, be imobalized for a second. Not able to attack for a small second, not able to take damage for a longer second.
        health -= damage;
        if (health <= 0)
            dead = true;
        Debug.Log("HP left: " + health);
    }

    private void SetUIBar(int player)
    {
        UIStats = GameObject.Find("Player" + player + "Stats");
    }

    private void SetColor(int character)
    {
        Image[] hearts = UIStats.GetComponentsInChildren<Image>();
        foreach (Image image in hearts)
        {
            image.color = color[character - 1];
        }
        UIStats.GetComponent<Image>().color = color[character - 1];
    }
}
