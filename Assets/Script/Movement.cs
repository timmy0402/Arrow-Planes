using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float speed = 0.1f;
    private float rotationSpeed = 45f;
    private float coolDown = 0.2f;
    private float nextSpawn = 0f;
    private bool toggle = false;
    public GameObject projectile;
    public Text hero = null;
    private EggCount eggControl = null;
    void Start()
    {
        eggControl = FindObjectOfType<EggCount>();
    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);


        if (Input.GetKey(KeyCode.M))
        {
            if (toggle)
            {
                toggle = false;
            }
            else
            {
                toggle = true;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            speed += 0.1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            speed -= 0.1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextSpawn)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            nextSpawn = Time.time + coolDown;
            eggControl.numEgg++;
        }
        if (toggle)
        {
            transform.position = Vector2.Lerp(transform.position, mousePos, 1f);
            hero.text = "HERO: Drive(Mouse)";
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.Translate(Vector3.left * transform.rotation.z * Time.deltaTime);
            hero.text = "HERO: Drive(Key)";
        }
    }
}
