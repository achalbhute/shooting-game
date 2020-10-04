using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    void Start()
    {
        
    }

    void Update()
    {
        goDown();
        if (isReachedBottom())
        {
            regenarateEnemy();
            //Destroy(this.gameObject);
        }
    }

    void goDown()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

    }

    void regenarateEnemy()
    {
        //System.Random r = new System.Random();
        //int genRand = r.Next(-8, 8);

        float genRand = Random.Range(-8f, 8f);
        transform.position = new Vector3(genRand, 8, 0);
    }

    bool isReachedBottom()
    {
        return transform.position.y < -7;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            int lives = 0;
            Player player = col.transform.GetComponent<Player>();
            if (player)
            {
                lives = player.damage();
            }
            Destroy(this.gameObject);
        }

        if (col.tag == "Laser")
        {
            Debug.Log("I am Laser");
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }

    }
        /* without spawnmanager
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Player"))
            {
                int lives = 0;
                Player player = other.transform.GetComponent<Player>();
                if (player)
                {
                    lives = player.damage();
                }
                if (lives < 1)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    regenarateEnemy();
                }
            }

            if (other.tag == "Laser")
            {
                Debug.Log("I am Laser");
                Destroy(other.gameObject);
                regenarateEnemy();
            }
        } */

    }
