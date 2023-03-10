using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // fator de desaceleração

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //verifica se é o player que colidiu
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            other.GetComponent<PlayerController>().moveSpeed = slowDownFactor; //diminui a velocidade do jogador
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //verifica se é o player que saiu da colisão
        {
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();
            playerRigidbody.velocity /= slowDownFactor; //restaura a velocidade normal do jogador
        }
    }
}

