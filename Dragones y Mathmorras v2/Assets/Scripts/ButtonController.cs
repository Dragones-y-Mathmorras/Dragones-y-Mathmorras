using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    private Button button; //componente boton
    private Text buttonTxt;//texto del boton (el numero de la caja)
    private int buttonInt;

    private RawImage vidaImg1;
    private RawImage vidaImg2;
    private RawImage vidaImg3;

    private RawImage[] vidasImgs;

    //Para el tema del audio
    private AudioSource audioPlayer;
    public AudioClip rightAudio;
    public AudioClip wrongAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();

        audioPlayer = GetComponent<AudioSource>();

        //Componentes "VidaImg" de cada Empty Object "Vida"
        if (SceneManager.GetActiveScene().name == "SampleScene") //si estamos en el SampleScene cogemos las imagenes de las vidas, y si no no (para la mazmorra)
        { 
            vidaImg1 = GameObject.Find("Vida1").GetComponentInChildren<RawImage>(); 
            vidaImg2 = GameObject.Find("Vida2").GetComponentInChildren<RawImage>();
            vidaImg3 = GameObject.Find("Vida3").GetComponentInChildren<RawImage>();       

        //Las guardo en un array
        vidasImgs = new RawImage[] { vidaImg1, vidaImg2, vidaImg3 };
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckRight()
    {
        int ans = GameObject.Find("Game Canvas").GetComponent<GameController>().result; //en ans guardo el resultado correcto (el truco para que funcione en la mazmorra tambien es que el canvas se llama Game Canvas tambien, asi que busca el resultado igualmente x3 )
        buttonTxt = GetComponentInChildren<Text>();
        buttonInt = int.Parse(buttonTxt.text);

        if (SceneManager.GetActiveScene().name == "SampleScene") //si estamos en SampleScene
        {
            if (buttonInt == ans) //si aciertas 
            {
                
                if (StaticNumSala.numSala < 19)
                {
                    TurnGreen();
                    StaticNumSala.numSala++; //incremento el numero de la sala  
                    GameObject.Find("Game Canvas").GetComponent<GameController>().darValores(); //volvemos a asignar valores a las cajas                       
                }
                else
                {
                    TurnGreen();
                    StaticNumSala.numSala++;//actualizo el numero de la sala    
                    GameObject.Find("Game Canvas").GetComponent<GameController>().hasGanado(); //llamamos a "hasGando" para que se muestre la imagen de victoria
                }
            }
            else //si fallas
            {
                          
                if ((GameObject.Find("Game Canvas").GetComponent<GameController>().vidas) > 1)//si no te has quedado sin vidas
                { 
                    TurnRed();
                    PerderVida(); //perdemos una vida
                }
                else //si pierdes todas las vidas
                {                   
                    PerderVida(); //perdemos una vida
                    GameObject.Find("Game Canvas").GetComponent<GameController>().go2Dungeon(); //llamamos a "hasPerdido" para que se muestre la imagen de derrota             
                }
            
            }
        }
        else //si estamos en la mazmorra 
        {
            if (buttonInt == ans) //si aciertas
            {
                TurnGreen();
                GameObject.Find("Game Canvas").GetComponent<GameController>().hasGanadoMaz();
            }
            else //si fallas
            {
                TurnRed();
                GameObject.Find("Game Canvas").GetComponent<GameController>().hasPerdidoMaz();

            }
        }

    }
    public void TurnGreen()
    {
        //reproducir sonido de "Correcto"
        audioPlayer.clip = rightAudio;
        audioPlayer.Play();

        /*
        ColorBlock colors = button.colors; //variable que puede gauardar el estado de un color (perfecto para nuestro boton)
        Color color = Color.green; //Elijo el color (verde)
        color.a = 0.3f; //Le bajo la opacidad un poco
        colors.selectedColor = color; //Establezco la propiedad selctedColor del boton al color verde con opacidad 0.6      
        button.colors = colors; //igualo los colores del boton a las del ColorBlock        
        //GameObject.Find("Game Canvas").GetComponent<GameController>().puntosInt++;//incremento la puntuacion
        //GameObject.Find("Game Canvas").GetComponent<GameController>().puntosTxt.text = GameObject.Find("Game Canvas").GetComponent<GameController>().puntosInt.ToString(); //actualizo la puntuacion
        */
    }

    public void TurnRed()
    {
        //reproducir sonido de "Incorrecto"
        audioPlayer.clip = wrongAudio;
        audioPlayer.Play();

        /*
        ColorBlock colors = button.colors; //variable que puede gauardar el estado de un color (perfecto para nuestro boton)
        Color color = Color.red;//Elijo el color (rojo)
        color.a = 0.3f;//Le bajo la opacidad un poco 
        colors.selectedColor = color; //Establezco la propiedad selctedColor del boton al color rojo con opacidad 0.6      
        button.colors = colors; //igualo los colores del boton a las del ColorBlock
        */
    }

    public void PerderVida()
    {
        //Cojemos las vidas del script de GameController (si no cada boton tendra su propia variable vidas) -> ESTO ES GameObject.Find("Game Canvas").GetComponent<GameController>().vidas)
        vidasImgs[(GameObject.Find("Game Canvas").GetComponent<GameController>().vidas) - 1].enabled = false;
        (GameObject.Find("Game Canvas").GetComponent<GameController>().vidas)--;
    }

}
