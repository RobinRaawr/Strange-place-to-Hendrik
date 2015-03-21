using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    private int health = 3;
    private bool dead = false;

    public void TakeDamage(int damage)
    {
        //TODO: take damage animation
        //Take knockdown effect, be imobalized for a second. Not able to attack for a small second, not able to take damage for a longer second.
        health -= damage;
        if (health <= 0)
            dead = true;
        Debug.Log("HP left: " + health);
    }

    void Update()
    {
        if (dead)
        { 
            //TODO: play dead animation
            //TODO: actually die(remove from game, or lay their being dead
        }
    }
}
