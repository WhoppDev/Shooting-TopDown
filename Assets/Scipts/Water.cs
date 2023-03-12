using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float slowDownFactor = 4f; // fator de desacelera��o

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player")) //verifica se � o player que colidiu
        {
            player.GetComponent<PlayerController>().moveSpeed *= slowDownFactor; //diminui a velocidade do jogador;
            
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player")) //verifica se � o player que saiu da colis�o
        {
            player.GetComponent<PlayerController>().moveSpeed /= slowDownFactor;
        }
    }
}

