using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlaInterface : MonoBehaviour
{
    private ControlaJogador scriptControlaJoagdor;
    public Slider SliderVidaJogador;


    void Start()
    {
        scriptControlaJoagdor = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scriptControlaJoagdor.vida;
        AtualizaSliderVida();

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizaSliderVida ()
    {
        SliderVidaJogador.value = scriptControlaJoagdor.vida;
    }
}
