using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMowment : MonoBehaviour
{
    public int jumpForce;
    public Rigidbody Body;
    public bool isMoving;
    public float moveSpeed;

    public void StopMoving()
    {
        isMoving = false;
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    void FixedUpdate()
    {
        if (isMoving==true) 
        {
            float Vertical = Input.GetAxis("Vertical");
            float Horizontal = Input.GetAxis("Horizontal");
            Vector3 direction = transform.forward * Vertical + transform.right * Horizontal;
            Body.velocity = direction*moveSpeed + Vector3.up * Body.velocity.y;
            
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool onGround = Physics.Raycast(transform.position, Vector3.down, 1.1f);
            if (onGround == true)
            { 
                StartCoroutine(Jump());
            }
        }
    }

    IEnumerator Jump()
    {
        int a = jumpForce;
        while (a > 0)
        {
            Body.velocity+=new Vector3(0,a,0);
            a = a - 1;
            yield return new WaitForFixedUpdate();
        }
    }
}
