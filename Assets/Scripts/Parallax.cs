using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Паралакс при движении камеры
public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float ParallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (cam.transform.position.x * (1 - ParallaxEffect));
        float temp = (cam.transform.position.x * ParallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
            startpos += length;
        else if (temp < startpos - length)
            startpos -= length;
    }
}
