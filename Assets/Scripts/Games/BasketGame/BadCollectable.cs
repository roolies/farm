using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCollectable : MonoBehaviour
{
    public FarmGame game;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            game.Score--;
            Destroy(gameObject);
        }
    }
}
