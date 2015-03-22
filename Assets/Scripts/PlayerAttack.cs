using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    
    public Animator anim;
    public AudioClip[] clips;
    int randomClip;

    public string fire2 = "Fire2_P1";

    private float attackRange = 3f;
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
        if (Input.GetButtonDown(fire2) && cooldown <= 0)
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
        // Random Audio
        randomClip = Random.Range(0, 3);
        audio.clip = clips[randomClip];
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
