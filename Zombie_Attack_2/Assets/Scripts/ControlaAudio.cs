using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    private AudioSource meuAudioSource;
    public static AudioSource instancia;
    // O static serve para que a vari�ve n�o mude de valor mesmo se for usada em outro c�digo, a� se mudar o valor dela em outro c�digo aqui muda tamb�m

    void Awake() // O Awake � um start mas que roda primeiro de tudo, ent�o quando o jogo rodar vai ser a primeira coisa que vai abirir.
    {
        meuAudioSource = GetComponent<AudioSource>();
        instancia = meuAudioSource;

    }
}
//Sistema Singleton
