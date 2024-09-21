using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlaInterface : MonoBehaviour
{
    private ControlaJogador scriptControlaJoagdor;
    public Slider SliderVidaJogador;
    public GameObject PainelGameOver;
    public AudioSource audio;
    public Text TempoTotal;
    public Text TempoRecorde;
    private float tempoMax;


    void Start()
    {
        scriptControlaJoagdor = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scriptControlaJoagdor.vida;
        AtualizaSliderVida();
        GameObject controlaAudio = GameObject.Find("ControlaAudio");
        audio = controlaAudio.GetComponent<AudioSource>();
        tempoMax = PlayerPrefs.GetFloat("Recorde");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizaSliderVida ()
    {
        SliderVidaJogador.value = scriptControlaJoagdor.vida;
    }

    public void GameOver ()
    {
        PainelGameOver.SetActive(true);
        Time.timeScale = 0;
        audio.Stop();

        int minutos = (int)(Time.timeSinceLevelLoad /60);
        int segundos = (int)(Time.timeSinceLevelLoad % 60);
        TempoTotal.text = "You survive for " + minutos + "min and " + segundos + "s";

        PontuacaoMax(minutos, segundos);    
    }




    public void PontuacaoMax(int min, int seg)
    {
        if (Time.timeSinceLevelLoad > tempoMax)
        {
            tempoMax = Time.timeSinceLevelLoad;
            TempoRecorde.text = string.Format("Best time: {0}min and {1}s ", min, seg);
            PlayerPrefs.SetFloat("Recorde", tempoMax);
        }
        if (TempoRecorde.text == "")
        {
            min = (int)(tempoMax / 60);
            seg = (int)(tempoMax % 60);
            TempoRecorde.text = string.Format("Best time: {0}min and {1}s ", min, seg);
        }
    }

    public void Restart() 
    {
        SceneManager.LoadScene("game");
        audio.Play();
    }
}