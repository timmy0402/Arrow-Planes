using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    private GameController control = null;
    // Start is called before the first frame update
    private EggCount eggControl = null;
    public Text touched = null;
    private int count = 0;
    void Start()
    {
        control = FindObjectOfType<GameController>();
        eggControl = FindObjectOfType<EggCount>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (gameObject.tag == "Player")
            {
                Destroy(other.gameObject);
                control.EnemyDestroyed();
                control.destroyed++;
                count++;
                touched.text = "TouchedEnemy(" + count + ")";
            }
            else
            {
                SpriteRenderer health = other.gameObject.GetComponent<SpriteRenderer>();
                if (health != null)
                {
                    health.color = new Color(health.color.r, health.color.g, health.color.b, health.color.a * 0.8f);
                }
                Destroy(gameObject);
                eggControl.numEgg--;
            }
        }
    }
}
