using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    private GameObject pantallaSalir;

    // Start is called before the first frame update
    void Start()
    {
        //Ponemos el numero de sala a 0, para que, al inicio de cada partida, este empieze desde el principio
        StaticNumSala.numSala = 0;

        //Inicialmente, no sale la pantalla de si quieres salir
        pantallaSalir = GameObject.Find("ConfirmSalir");
        pantallaSalir.SetActive(false);
    }  

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goPlay()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void goOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }
    public void confirmSalir()
    {
        pantallaSalir.SetActive(true);
    }
    public void continuePlaying()
    {
        pantallaSalir.SetActive(false);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
