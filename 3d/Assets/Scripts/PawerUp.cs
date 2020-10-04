using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goDown();
        if (isReachedBottom())
        {
            Destroy(this.gameObject);
        }
    }

    void goDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    bool isReachedBottom()
    {
        return transform.position.y < -7;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player) {
                player.activateTripleShot();
            }
            Destroy(this.gameObject);
        }
    }
}
