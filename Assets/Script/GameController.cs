using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private float height;
    private float width;
    public int destroyed = 0;
    private int numPlane = 0;
    private int maxPlane = 10;
    public GameObject enemy;
    public Text destroy = null;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = FindObjectOfType<Camera>();
        height = cam.orthographicSize;
        width = cam.orthographicSize * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        destroy.text = "ENEMY: Count(" + numPlane + ") " + "Destroyed(" + destroyed + ")";
        if (Input.GetKey(KeyCode.Q))
        {
#if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        if (numPlane < maxPlane)
        {
            Vector3 pos;
            pos.x = Random.Range(-width * 0.9f, width * 0.9f);
            pos.y = Random.Range(-height * 0.9f, height * 0.9f);
            pos.z = 0;
            Instantiate(enemy, pos, transform.rotation);
            numPlane++;
        }
    }
    public void EnemyDestroyed()
    {
        numPlane--;
    }
}
