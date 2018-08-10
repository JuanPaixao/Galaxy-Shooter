﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private float _mov = 10.0f;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _nextFire = 0.0f;
    void Start()
    {
        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ShipMovement();
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) && Time.time >= _nextFire)
        {
            ShootLaser();
        }
    }
    private void ShipMovement()
    {
        float movHor = Input.GetAxis("Horizontal");
        float movVer = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(movHor, movVer) * _mov * Time.deltaTime);


        //Y
        if (transform.position.y <= -4.2f)
        {
            transform.position = new Vector2(transform.position.x, -4.2f);
        }
        else if (transform.position.y >= 0)
        {
            transform.position = new Vector2(transform.position.x, 0f);
        }


        //X
        if (transform.position.x > 9.4f)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
            Debug.Log("Passei pra direita");
        }
        else if (transform.position.x < -9.4f)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
            Debug.Log("Passei pra esquerda");
        }
    }
    private void ShootLaser()
    {
        _nextFire = Time.time + _fireRate;
        Instantiate(_laser, new Vector3(transform.position.x, transform.position.y + 0.88f, 0), Quaternion.identity);
    }
}
