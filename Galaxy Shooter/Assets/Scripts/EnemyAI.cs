﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private float _speedEnemy = 4.0f;
    [SerializeField]
    private GameObject _explosion;
    Player player;

    private UI_Manager uiManager;
    private GameManager _gameManager;


    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }
    void Update()
    {
        transform.Translate(Vector3.down * _speedEnemy * Time.deltaTime);


        float _randomRange = Random.Range(-7.55f, 7.55f);

        if (this.transform.position.y < -6.3f)
        {
            transform.position = new Vector2(_randomRange, 8);
        }
        if (_gameManager != null)
        {
            if (_gameManager.gameOver == true)
            {
                Destroy(this.gameObject);
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Laser"))
        {
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    player = other.GetComponent<Player>();
                    if (player != null)
                    {
                        if (player.canShield == true)
                        {
                            player.canShield = false;
                            player._shieldPlayer.SetActive(false);
                            return;
                        }
                        else
                        {
                            player.lifePoints--;
                            player.uiManager.UpdateLives(player.lifePoints);
                            player.ShipLife();
                        }
                    }
                }

                else
                {
                    if (uiManager != null)
                    {
                        uiManager.UpdateScore();
                        Destroy(other.gameObject);
                    }

                }
                Instantiate(_explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

        }
    }
}
