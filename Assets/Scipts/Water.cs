using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().moveSpeed = 1;
        }
    }

}
