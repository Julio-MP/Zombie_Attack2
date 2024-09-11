using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour {

    public GameObject Zumbi;
    private float contadorTempo = 0;
    public float TempoGerarZumbi = 1;
    public LayerMask LayerZombie;
    public int cont = 0;

	
	void Update () {

        contadorTempo += Time.deltaTime;

        if(contadorTempo >= TempoGerarZumbi)
        {
            GerarNovoZumbi();
            contadorTempo = 0;
        }
    }
    void GerarNovoZumbi()
    {
        Vector3 posicaoDeCriacao = Aleatorizar();
        Collider[]  colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZombie);

        while (colisores.Length > 0) 
        {
            posicaoDeCriacao = Aleatorizar();
            colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZombie);
        }


        Instantiate(Zumbi, transform.position, transform.rotation);

    }
            
    Vector3 Aleatorizar() 
    { 
        Vector3 posicao = Random.insideUnitSphere * 3;
        posicao += transform.position;
        posicao.y = 0;

        return posicao;
    }
}
