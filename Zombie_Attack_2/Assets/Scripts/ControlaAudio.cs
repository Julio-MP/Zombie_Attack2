using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    private AudioSource meuAudioSource;
    public static AudioSource instancia;
    // O static serve para que a variáve não mude de valor mesmo se for usada em outro código, aí se mudar o valor dela em outro código aqui muda também

    void Awake() // O Awake é um start mas que roda primeiro de tudo, então quando o jogo rodar vai ser a primeira coisa que vai abirir.
    {
        meuAudioSource = GetComponent<AudioSource>();
        instancia = meuAudioSource;

    }
}
//Sistema Singleton
