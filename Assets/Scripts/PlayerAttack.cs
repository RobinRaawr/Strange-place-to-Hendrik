using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    private float attackRange = 5f;
    private int damage = 1;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Attack();
        }
    }

    void Attack()
    {
        //TODO: play attack animation
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
