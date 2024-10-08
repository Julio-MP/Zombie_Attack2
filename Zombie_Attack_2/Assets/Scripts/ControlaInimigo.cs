﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 5;
    private MovimentoPersonagem movimentoInimigo;
    private Animacoes Animacao;
    public Vector3 posicaoAleatoria;
    public Vector3 direcao;
    private float contadorTime;
    private float tempoEntrePosicaoAleatoria = 4;
    // Use this for initialization
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        Animacao = GetComponent<Animacoes>();
        movimentoInimigo = GetComponent<MovimentoPersonagem>();
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        
        movimentoInimigo.rotacionar(direcao);
        Animacao.Movimentar(direcao.magnitude);

        if (distancia > 15)
        {
            Vagar();
        }
        else if (distancia > 2.5)
        {
            movimentoInimigo.movimentar(direcao, Velocidade);
            direcao = Jogador.transform.position - transform.position;
            Animacao.Atacar(false);
        }
        else
        {
            Animacao.Atacar(true);
            direcao = Jogador.transform.position - transform.position;
        }
    }

    void Vagar()
    {
        contadorTime -= Time.deltaTime;
        if (contadorTime < 0)
        {
            posicaoAleatoria = PosicaoQualquer();
            contadorTime = tempoEntrePosicaoAleatoria;
        }
        //Em jogos 3D é difícil realmente chegar até zero
        bool ficouPerto = Vector3.Distance(transform.position, posicaoAleatoria) <= 0.05;
        if (ficouPerto == false)
        {
            direcao = posicaoAleatoria - transform.position;
            movimentoInimigo.movimentar(direcao, Velocidade);
        }
    }

    Vector3 PosicaoQualquer()
    {
        Vector3 posicao = Random.insideUnitSphere * 15;
        //Esse insideUnitSphere cria uma esfera, pega uma posição dentro dessa esfera e faz com que o objeto vá para essa posição 
        posicao += transform.position;
        //Colocando essa esfera na posicao do jogador 
        posicao.y = transform.position.y;
        // Mas como é uma esfera temos que cancelar a posição que ele pode ir do eixo y
        return posicao;
    }

    void AtacaJogador()
    {
        int danoDado = Random.Range(20, 30);
        Jogador.GetComponent<ControlaJogador>().PerdeVida(danoDado);
    }
}