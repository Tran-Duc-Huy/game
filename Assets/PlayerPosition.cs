using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public float PlayerPosX;
    List<GameObject> minions;
    public int move = 0;
    public GameObject minionPrefab;
    public int speed = 10;
    public int jump_force=3;
    public bool jump=true;

    private void Start()
    {
        minions = new List<GameObject>();
    }
    void Update()
    {
        this.PlayerPosX = transform.position.x;
        int spawnLocation = 7;
        if (PlayerPosX >= spawnLocation) this.Spawn();
        else this.NotSpawn();
        MovePlayer();
        checkMinionDead();
    }
    void MovePlayer ()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) this.move = -1;
        else if(Input.GetKey(KeyCode.RightArrow)) this.move = 1;
        else this.move = 0;

        transform.Translate(Vector3.right*move*speed*Time.deltaTime);
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))&&jump ) transform.Translate(Vector2.up * jump_force);
    }

    void Spawn()
    {
        Debug.Log("Spawn");
        if (this.minions.Count >= 7) return; 

        int index = this.minions.Count+1;
        GameObject minions = Instantiate(this.minionPrefab);
        minions.name = "MinionPrefab #" + index;

        minions.transform.position = transform.position;
        minions.gameObject.SetActive(true);
        this.minions.Add(minions);
    }
    void checkMinionDead()
    {
        GameObject minion;
        for (int i = 0; i < this.minions.Count; i++)
        {
            minion = this.minions[i];
            if (minion == null)
            {
                this.minions.RemoveAt(i);
            }
        }
    }
    void NotSpawn()
    {
        Debug.Log("Not Spawn");
    }
    private void OnTriggerEnter2D(Collider2D hitbox)
    {
        if (hitbox.gameObject.tag == "San")
            this.jump = true;
    }
    private void OnCollisionExit2D(Collision2D hitbox)
    {
        if (hitbox.gameObject.tag == "San")
            this.jump = false;
    }
}
