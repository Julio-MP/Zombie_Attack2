using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour {

    public GameObject Bala;
    public GameObject SA_Wep_Pistol_Silencer;
	public AudioClip SomDoTiro;	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bala, SA_Wep_Pistol_Silencer.transform.position, SA_Wep_Pistol_Silencer.transform.rotation);
			ControlaAudio.instancia.PlayOneShot(SomDoTiro);

        }
	}
}
