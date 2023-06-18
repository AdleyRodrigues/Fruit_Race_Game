using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarVaieVoltaRigidbody2D : MonoBehaviour
{
    public float distanciaDeslocamento;
    public float velocidadeIda;
    public float velocidadeVolta;
    public float tempoAntesIda;
    public float tempoAntesVolta;
    public bool moverNoEixoX;
    public bool moverNoEixoY;

    private Rigidbody2D rb;
    private Vector2 posicaoInicial;
    private Vector2 posicaoDestino;
    private bool indo;
    private float tempoAtual;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicaoInicial = rb.position;
        posicaoDestino = posicaoInicial + ObterDirecaoDeslocamento();
        indo = true;
        tempoAtual = tempoAntesIda;
    }

    private void FixedUpdate()
    {
        tempoAtual -= Time.fixedDeltaTime;

        if (tempoAtual <= 0)
        {
            if (indo)
            {
                float velocidade = velocidadeIda;
                if (Vector2.Distance(rb.position, posicaoDestino) <= 0.01f)
                {
                    indo = false;
                    tempoAtual = tempoAntesVolta;
                    posicaoDestino = posicaoInicial;
                    velocidade = velocidadeVolta;
                }

                rb.MovePosition(Vector2.MoveTowards(rb.position, posicaoDestino, velocidade * Time.fixedDeltaTime));
            }
            else
            {
                if (Vector2.Distance(rb.position, posicaoDestino) <= 0.01f)
                {
                    indo = true;
                    tempoAtual = tempoAntesIda;
                    posicaoDestino = posicaoInicial + ObterDirecaoDeslocamento();
                }

                rb.MovePosition(Vector2.MoveTowards(rb.position, posicaoDestino, velocidadeVolta * Time.fixedDeltaTime));
            }
        }
    }

    private Vector2 ObterDirecaoDeslocamento()
    {
        Vector2 direcao = Vector2.zero;

        if (moverNoEixoX)
            direcao += Vector2.right;

        if (moverNoEixoY)
            direcao += Vector2.up;

        return direcao.normalized * distanciaDeslocamento;
    }
}