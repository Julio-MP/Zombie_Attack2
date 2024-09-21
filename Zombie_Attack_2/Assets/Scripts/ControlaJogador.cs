using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlaJogador : MonoBehaviour
{
    public float Velocidade = 10;
    private Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;
    public int vida = 100;
    public ControlaInterface scriptControlaInterface;
    public AudioClip SomDeDano;
    private MovimentoJogador JogadorMovimento;


    private void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
        JogadorMovimento = GetComponent<MovimentoJogador>();

    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if (direcao != Vector3.zero)
        {
            animatorJogador.SetBool("Movendo", true);
        }
        else
        {
            animatorJogador.SetBool("Movendo", false);
        }


    }

    void FixedUpdate()
    {
        JogadorMovimento.movimentar(direcao, Velocidade);
        
        JogadorMovimento.RotacionarJogador(MascaraChao);
    }

    public void PerdeVida (int danoPerdido)
    {
        vida -= danoPerdido;
        scriptControlaInterface.AtualizaSliderVida();
        ControlaAudio.instancia.PlayOneShot(SomDeDano); 
        if (vida <= 0)
        {
            scriptControlaInterface.GameOver();
        }
    }
}
