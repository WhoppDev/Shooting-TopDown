using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float slowDownFactor = 4f; // fator de desaceleração

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player")) //verifica se é o player que colidiu
        {
            player.GetComponent<PlayerController>().moveSpeed *= slowDownFactor; //diminui a velocidade do jogador;
            
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player")) //verifica se é o player que saiu da colisão
        {
            player.GetComponent<PlayerController>().moveSpeed /= slowDownFactor;
        }
    }
}

