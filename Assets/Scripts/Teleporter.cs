using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector2 Teleportation_Position;
    private GameObject player;
    private PlayerController PlayerController;

    void Start()
    {
        player = GameObject.Find("Player");
        PlayerController = player.GetComponent<PlayerController>();

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        PlayerController.velocity = new Vector2(0, 0);
        player.transform.position = Teleportation_Position;
    }
}
