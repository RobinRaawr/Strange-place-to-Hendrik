using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    
    public Animator anim;

    private float attackRange = 2f;
    private int damage = 1;

    AudioSource audio;
    public float cooldown;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime; 
        }


        // ATTAAACCKK
        if (Input.GetButtonDown("Fire2") && cooldown <= 0)
        {
            Attack();
            anim.SetBool("IsAttacking", true);
            
            cooldown = 0.7f;
        }
        else
            anim.SetBool("IsAttacking", false);
    }

    void Attack()
    {
        //TODO: play attack animation
        audio.Play();

        float direction = GetComponent<PlayerMovement>().direction;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(direction, 0, 0), out hit))
        {
            if (hit.distance <= attackRange)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    hit.collider.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
                    Debug.Log("Hit: " + hit.collider.gameObject.name);
                }
            }
        }
    }
}
