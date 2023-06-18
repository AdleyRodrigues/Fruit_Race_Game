using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentarVaieVoltaTransf : MonoBehaviour
{
    public float distanciaDeslocamento;
    public float velocidadeIda;
    public float velocidadeVolta;
    public float tempoAntesIda;
    public float tempoAntesVolta;
    public bool moverNoEixoX;
    public bool moverNoEixoY;
    public bool moverNoEixoZ;

    private float tempoAtual;
    private Vector3 posicaoInicial;
    private Vector3 posicaoDestino;
    private bool indo;

    private void Start()
    {
        posicaoInicial = transform.position;
        posicaoDestino = posicaoInicial + ObterDirecaoDeslocamento();
        indo = true;
        tempoAtual = tempoAntesIda;
    }

    private void Update()
    {
        tempoAtual -= Time.deltaTime;

        if (tempoAtual <= 0)
        {
            if (indo)
            {
                float velocidade = velocidadeIda;
                if (Vector3.Distance(transform.position, posicaoDestino) <= 0.01f)
                {
                    indo = false;
                    tempoAtual = tempoAntesVolta;
                    posicaoDestino = posicaoInicial;
                    velocidade = velocidadeVolta;
                }

                transform.position = Vector3.MoveTowards(transform.position, posicaoDestino, velocidade * Time.deltaTime);
            }
            else
            {
                if (Vector3.Distance(transform.position, posicaoDestino) <= 0.01f)
                {
                    indo = true;
                    tempoAtual = tempoAntesIda;
                    posicaoDestino = posicaoInicial + ObterDirecaoDeslocamento();
                }

                transform.position = Vector3.MoveTowards(transform.position, posicaoDestino, velocidadeVolta * Time.deltaTime);
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