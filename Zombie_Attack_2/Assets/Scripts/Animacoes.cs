using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacoes : MonoBehaviour
{
    private Animator meuAnimator;
    void Awake()
    {
        meuAnimator = GetComponent<Animator>();
    }
    public void Atacar(bool estado)
    {
        meuAnimator.SetBool("Atacando", estado);

    }

    public void Movimentar(float ValorMovimento)
    {
        meuAnimator.SetFloat("Movendo", ValorMovimento);
    }
}
