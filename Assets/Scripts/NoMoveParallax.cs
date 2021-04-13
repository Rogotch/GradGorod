using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт паралакса фона без движения камеры
public class NoMoveParallax : MonoBehaviour
{
    private float length, startpos;
    public float SpeedMove;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * SpeedMove * Time.deltaTime);

        if (transform.position.x > startpos + length || transform.position.x < startpos - length)
            transform.position = new Vector3(startpos, transform.position.y, transform.position.z);
    }
}
