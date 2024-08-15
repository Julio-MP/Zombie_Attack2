using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    private Rigidbody meuRigidbody;

    void Awake()
    {
        meuRigidbody = GetComponent<Rigidbody>();
    }

    public void movimentar(Vector3 direcaoX, float velocidadeX)  // Tipo adicionado ao parâmetro velocidadeX
    {
        meuRigidbody.MovePosition(
                meuRigidbody.position +  // Corrigido de rigidbodyInimigo para meuRigidbody
                direcaoX.normalized * velocidadeX * Time.deltaTime);
    }

    public void rotacionar(Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        meuRigidbody.MoveRotation(novaRotacao);
    }
}
