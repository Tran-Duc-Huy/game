using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : MonoBehaviour
{
    public int mau = 10;
    public GameObject bossPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mau <= 0)
        {
            gameObject.SetActive(false);
            mau = 10;
            Invoke("Spawn", 5f);
        } 
    }
    void Spawn()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kame"))
        {
            mau--;
        }
    }
}
