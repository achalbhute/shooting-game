using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;

    [SerializeField]
    private bool _isTripleShotActive = false;

    private SpawnManager _spawnManager;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (!_spawnManager) Debug.LogError("SpawnManager not found");

    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();

        }
    }

    void FireLaser()
    {
        if (_isTripleShotActive)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            //Instantiate(_laserPrefab, transform.position, Quaternion.identity); // : to instantiate on player

            //Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 0.4f, 0), Quaternion.identity);

            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }

        _canFire = Time.time + _fireRate; // cool down system
    }


    void CalculateMovement()
    {
        //transform.Translate(new Vector3(-1, 0, 0) * 5 * Time.deltaTime);
        //transform.Translate(Vector3.left * _speed * Time.deltaTime);

        float horizontalAxios = Input.GetAxis("Horizontal");
        float verticalAxios = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.right * horizontalAxios * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalAxios * _speed * Time.deltaTime);

        Vector3 direction = new Vector3(horizontalAxios, verticalAxios, 0);
        transform.Translate(direction * _speed * Time.deltaTime);



        if (transform.position.x < -9)
        {
            transform.position = new Vector3(9f, transform.position.y, 0);
        }
        if (transform.position.x > 9)
        {
            transform.position = new Vector3(-9f, transform.position.y, 0);
        }
        if (transform.position.y < -3.7)
        {
            transform.position = new Vector3(transform.position.x, -3.7f, 0);
        }
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
    }

    public int damage()
    {
        _lives--;

        if(_lives < 1)
        {
            _spawnManager.isPlayerDead();
            Destroy(this.gameObject);
        }
        return _lives;
    }

    public void activateTripleShot()
    {
        _isTripleShotActive = true;
        StartCoroutine(powerDownTripleShot());
    }

    IEnumerator powerDownTripleShot()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }
}
