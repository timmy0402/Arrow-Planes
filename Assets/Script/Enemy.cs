using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int eggCollided = 0;
    private GameController control = null;
    // Start is called before the first frame update
    void Start()
    {
        control = FindObjectOfType<GameController>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            eggCollided++;
        }
        if (eggCollided >= 4)
        {
            Destroy(gameObject);
            control.EnemyDestroyed();
            control.destroyed++;
        }
    }
}
