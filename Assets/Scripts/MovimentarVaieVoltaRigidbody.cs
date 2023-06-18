using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarVaieVoltaRigidbody : MonoBehaviour
{
    public float distanciaDeslocamento;
    public float velocidadeIda;
    public float velocidadeVolta;
    public float tempoAntesIda;
    public float tempoAntesVolta;
    public bool moverNoEixoX;
    public bool moverNoEixoY;
    public bool moverNoEixoZ;

    private Rigidbody rb;
    private Vector3 posicaoInicial;
    private Vector3 posicaoDestino;
    private bool indo;
    private float tempoAtual;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
                if (Vector3.Distance(rb.position, posicaoDestino) <= 0.01f)
                {
                    indo = false;
                    tempoAtual = tempoAntesVolta;
                    posicaoDestino = posicaoInicial;
                    velocidade = velocidadeVolta;
                }

                rb.MovePosition(Vector3.MoveTowards(rb.position, posicaoDestino, velocidade * Time.fixedDeltaTime));
            }
            else
            {
                if (Vector3.Distance(rb.position, posicaoDestino) <= 0.01f)
                {
                    indo = true;
                    tempoAtual = tempoAntesIda;
                    posicaoDestino = posicaoInicial + ObterDirecaoDeslocamento();
                }

                rb.MovePosition(Vector3.MoveTowards(rb.position, posicaoDestino, velocidadeVolta * Time.fixedDeltaTime));
            }
        }
    }

    private Vector3 ObterDirecaoDeslocamento()
    {
        Vector3 direcao = Vector3.zero;

        if (moverNoEixoX)
            direcao += Vector3.right;

        if (moverNoEixoY)
            direcao += Vector3.up;

        if (moverNoEixoZ)
            direcao += Vector3.forward;

        return direcao.normalized * distanciaDeslocamento;
    }
}