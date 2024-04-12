using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound;

    private float sideBound;
    private EggCount eggControl = null;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = FindObjectOfType<Camera>();
        topBound = cam.orthographicSize;
        sideBound = cam.orthographicSize * cam.aspect;
        eggControl = FindObjectOfType<EggCount>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
            eggControl.numEgg--;
        }
        else if (transform.position.y < -topBound)
        {
            Destroy(gameObject);
            eggControl.numEgg--;
        }
        else if (transform.position.x > sideBound)
        {
            Destroy(gameObject);
            eggControl.numEgg--;
        }
        else if (transform.position.x < -sideBound)
        {
            Destroy(gameObject);
            eggControl.numEgg--;
        }
    }
}
