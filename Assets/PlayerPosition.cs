using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerPosition : MonoBehaviour
{
    List<GameObject> minions;
    public int move = 0;
    public int speed = 10;
    public int jump_force=20;
    public bool jump=true;
    public GameObject slash;
    private Rigidbody2D rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Attack();
        MovePlayer();
    }

    void MovePlayer ()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) this.move = -1;
        else if(Input.GetKey(KeyCode.RightArrow)) this.move = 1;
        else this.move = 0;

        transform.Translate(Vector3.right*move*speed*Time.deltaTime);
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && jump) 
        {
            jump = false;
            rb.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            slash.SetActive(true);
            Invoke("DelaySlash",0.2f);
        }
    }
    void DelaySlash()
    {
        slash.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D hitbox)
    {
        if (hitbox.gameObject.tag == "San" || hitbox.gameObject.tag == "Boss")
            this.jump = true;
    }
    private void OnCollisionExit2D(Collision2D hitbox)
    {/*
        if (hitbox.gameObject.tag == "San")
            this.jump = false;*/
    }
}
