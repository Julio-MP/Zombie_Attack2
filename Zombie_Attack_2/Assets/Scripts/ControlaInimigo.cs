using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour {

    public GameObject Jogador;
    public float Velocidade = 5;
    private MovimentoPersonagem movimentoInimigo;
    private Animacoes Animacao; 
    private float aleatoria = 0;
    private Vector3 direcao;
    public Vector3 posicaoAleatoria;
    private float contadorTime;
    private float tempoEntrePosicaoAleatoria = 4;

    // Use this for initialization
    void Start () {
        Jogador = GameObject.FindWithTag("Jogador");
        Animacao = GetComponent<Animacoes>();
        movimentoInimigo = GetComponent<MovimentoPersonagem>();
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);



        movimentoInimigo.rotacionar(direcao);


        if (distancia > 15)
        {
            Vagar();
        }
        else if (distancia > 2.5)
        {

            movimentoInimigo.movimentar(direcao, Velocidade);
            direcao = Jogador.transform.position - transform.position;
            /*rigidbodyInimigo.MovePosition(
                rigidbodyInimigo.position +
                direcao.normalized * Velocidade * Time.deltaTime);*/

            Animacao.Atacar(false);
        }
        else
        {
            Animacao.Atacar(true);
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
        
        direcao = posicaoAleatoria - transform.position;
        movimentoInimigo.movimentar(direcao, Velocidade);
    }


    Vector3 PosicaoQualquer() 
    {
        Vector3 posicao = Random.insideUnitSphere * 30;
           //Esse insideUnitSphere cria uma esfera, pega uma posição dentro dessa esfera e faz com que o objeto vá para essa posição 
        posicao += transform.position;      
            //Colocando essa esfera na posicao do jogador 
        posicao.y = transform.position.y;
            // Mas como é uma esfera temos que cancelar a posição que ele pode ir do eixo y
        return posicao;
    }

    void AtacaJogador()
    {
        int danoDado = Random.Range(20,30);
        Jogador.GetComponent<ControlaJogador>().PerdeVida(danoDado);
       
    }

}
