using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //private float speed = 8.0f;
    void Start()
    {

    }

    void Update()
    {
        fire();
        if (transform.position.y > 8) {
            Destroy(this.gameObject);
        }

    }

    private void fire()
    {
        transform.Translate(0, 0.08f, 0);
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
