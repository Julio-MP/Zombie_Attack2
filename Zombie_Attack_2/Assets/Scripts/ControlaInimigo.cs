using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour {

    public GameObject Jogador;
    public float Velocidade = 5;
    private MovimentoPersonagem movimentoInimigo;
    private Animacoes Animacao; 

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

        Vector3 direcao = Jogador.transform.position - transform.position;

        movimentoInimigo.rotacionar(direcao);

        if (distancia > 2.5)
        {

            movimentoInimigo.movimentar(direcao, Velocidade);
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


    void AtacaJogador()
    {
        int danoDado = Random.Range(20,30);
        Jogador.GetComponent<ControlaJogador>().PerdeVida(danoDado);
       
    }

}
