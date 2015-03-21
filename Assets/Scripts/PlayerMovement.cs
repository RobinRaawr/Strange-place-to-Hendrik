using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 15f;

    public bool grounded = true;
    public float jumpPower = 200f;
    private bool hasJumped = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && grounded == true)
        {
            hasJumped = true;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        transform.position += movement * speed * Time.deltaTime;

        if (hasJumped)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0,1,0) * jumpPower);
            grounded = false;
            hasJumped = false;
        }
    }

    void OnCollisionEnter(Collision col)
    { 
        if(col.gameObject.tag == "Ground")
            grounded = true;
    }
}
