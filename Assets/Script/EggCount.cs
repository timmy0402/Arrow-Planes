using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggCount : MonoBehaviour
{
    public int numEgg = 0;
    public Text count = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count.text = "EGG: OnScreen(" + numEgg + ")";
    }
}
