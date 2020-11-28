using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    //Variables
    public Text messageField;
    public GameObject recRojo;
    public GameObject recVerde;
    public GameObject recAzulQuestion;
    public GameObject recAzulAnswerB;
    public GameObject recAzulAnswerM;
    public GameObject recAzulVida;
    public GameObject recNumSala;
    public GameObject recAzulSalir;
    public GameObject recAzulHoid;
    private string message1;
    private string message2;
    private string message3;
    private string message4;
    private string message5;
    private string message6;
    private string message7;
    private string message8;
    private string message9;
    private string message10;
    private string message11;
    private string messageExit;
    private string[] txtsArr = new string[11];
    private int messageIndex;
    private GameObject pantallaSalir;

    //auxiliares
    private bool canSoundB;
    private bool canSoundM;

    //Para el tema del audio
    private AudioSource audioPlayer;
    public AudioClip rightAudio;
    public AudioClip wrongAudio;

    // Start is called before the first frame update
    void Start()
    {
        //Inicialmente, la confirmacion de salir no esta activada:
        pantallaSalir = GameObject.Find("ConfirmSalir");
        pantallaSalir.SetActive(false);

        audioPlayer = GetComponent<AudioSource>();
        canSoundB = false;
        canSoundM = false;
        messageIndex = 0;

        messageExit = "¿Quieres CONTINUAR jugando, o quieres SALIR? ¡Si sales perderás todo el progreso!";
        message1 = "¡Hola, soy Hoid, tu acompañante en esta matemágica aventura! Voy a explicarte cómo funciona todo.";
        message2 = "Para empezar, este es el campo de operación. ¡Fíjate bien en lo que se te pide calcular!";
        message3 = "Esta es una de las posibles soluciones. Pulsando cualquiera de ellas darás respuesta a la pregunta de arriba.";
        message4 = "Si aciertas sonará este soindo y avanzarás a la siguiente sala...";
        message5 = "...y si fallas sonará este otro y no avanzarás.";
        message6 = "Estas son tus vidas. Cuando falles en una operación perderás una. Si te quedas sin vidas irás a la mazmorra, ¡así que piensa bien!";
        message7 = "Este número de aquí indica la sala en la que estás. ¡Cuando llegues a '20' habrás demostrado ser un auténtico matemago!";
        message8 = "Del mismo modo, cuando superes la 10ª sala ascenderas de piso, ¡y la decoración de las salas cambiará de ahí en adelante!";
        message9 = "Si te cansas y quieres irte, este es el botón de salir. Si sales perderás el progreso, ¡así que ten cuidado!";
        message10 = "¡Ah, una última cosa! Yo estaré viéndote desde aquí arriba en todo momento, ¡así que si tienes dudas sólo clica en mí!";
        message11 = "Eso es todo lo que necesitas saber para jugar. ¡A pasarlo bien y a aprender!";

        //guardo todos los comentarios de Hoid en un array
        txtsArr[0] = message1;
        txtsArr[1] = message2;
        txtsArr[2] = message3;
        txtsArr[3] = message4;
        txtsArr[4] = message5;
        txtsArr[5] = message6;
        txtsArr[6] = message7;
        txtsArr[7] = message8;
        txtsArr[8] = message9;
        txtsArr[9] = message10;
        txtsArr[10] = message11;
    }

    // Update is called once per frame
    void Update()
    {
        if(pantallaSalir.activeSelf == false) { 

            nextMessage(); //comprobamos el bocadillo en el que estamos en todo momento

            if (messageIndex < 11) //que no intente pintar lo que hay en la pos 10 del array, pues ahi no hay nada
            { 
                messageField.text = txtsArr[messageIndex]; //comprueba todo el rato cual es el contenido del mensaje
            }
            if (Input.GetKeyDown("space")) //si se le da al espacio pasamos al siguiente bocadillo
            {
                messageIndex++; //si avanzas el tutorial Hoid te sigue hablando
            }
            if (Input.GetKeyDown(KeyCode.S)) //si se le da a la S saltamos al juego
            {
                SceneManager.LoadScene("SampleScene");
            }
            if (Input.GetKeyDown(KeyCode.A) && messageIndex > 0) //si se le da a la A saltamos al juego
            {
                messageIndex--; //puedes retroceder el tutorial 
            }
      }
    }

    public void nextMessage()
    {

        if (messageIndex < 11)
        {
            //messageIndex++; //si avanzas el tutorial Hoid te sigue hablando
            switch (messageIndex)
            {
                case 0:
                    recRojo.SetActive(false);
                    recVerde.SetActive(false);
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(false);
                    recAzulAnswerM.SetActive(false);
                    recAzulVida.SetActive(false);
                    recNumSala.SetActive(false);
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(false);
                    break; //todo a false
                case 1:
                    recRojo.SetActive(false);
                    recVerde.SetActive(false);
                    recAzulQuestion.SetActive(true); //brilla la pregunta
                    recAzulAnswerB.SetActive(false);
                    recAzulAnswerM.SetActive(false);
                    recAzulVida.SetActive(false);
                    recNumSala.SetActive(false);
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(false);
                    break;
                case 2:
                    recRojo.SetActive(false);
                    recVerde.SetActive(false);
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(true); //brilla la respuesta correcta
                    recAzulAnswerM.SetActive(false);
                    recAzulVida.SetActive(false);
                    recNumSala.SetActive(false);
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(false);
                    //activar sonido "Correcto"
                    if (!canSoundB)
                    {
                        canSoundB = true;
                    }
                    break;
                case 3:
                    recRojo.SetActive(false);
                    recVerde.SetActive(true); //brilla el recuadro verde
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(true);
                    recAzulAnswerM.SetActive(false);
                    recAzulVida.SetActive(false);
                    recNumSala.SetActive(false);
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(false);
                    //reproducir sonido de "Correcto"
                    if (canSoundB)
                    { 
                        audioPlayer.clip = rightAudio;
                        audioPlayer.Play();
                        canSoundB = false;
                    }
                    //activar sonido "Incorrecto"
                    if (!canSoundM)
                    {
                        canSoundM = true;
                    }
                    break;
                case 4:
                    recRojo.SetActive(true); //brilla el recuadro rojo
                    recVerde.SetActive(false); 
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(false);
                    recAzulAnswerM.SetActive(true); //brilla la respuesta incorrecta
                    recAzulVida.SetActive(false);
                    recNumSala.SetActive(false);
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(false);
                    //activar sonido "Correcto"
                    if (!canSoundB)
                    {
                        canSoundB = true;
                    }
                    //reproducir sonido de "Incorrecto"
                    if (canSoundM)
                    {
                        audioPlayer.clip = wrongAudio;
                        audioPlayer.Play();
                        canSoundM = false;
                    }
                    break;                   
                case 5:
                    recRojo.SetActive(false); 
                    recVerde.SetActive(false);
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(false);
                    recAzulAnswerM.SetActive(false); 
                    recAzulVida.SetActive(true); //brilla el recuadro de las vidas
                    recNumSala.SetActive(false);
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(false);
                    //activar sonido "Incorrecto"
                    if (!canSoundM)
                    {
                        canSoundM = true;
                    }
                    break;
                case 6:
                    recRojo.SetActive(false);
                    recVerde.SetActive(false);
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(false);
                    recAzulAnswerM.SetActive(false);
                    recAzulVida.SetActive(false); 
                    recNumSala.SetActive(true); //brilla el recuadro del num de la sala
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(false);
                    break;
                case 7:
                    recRojo.SetActive(false);
                    recVerde.SetActive(false);
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(false);
                    recAzulAnswerM.SetActive(false);
                    recAzulVida.SetActive(false);
                    recNumSala.SetActive(true); //brilla el recuadro del num de la sala
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(false);
                    break;
                case 8:
                    recRojo.SetActive(false);
                    recVerde.SetActive(false);
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(false);
                    recAzulAnswerM.SetActive(false);
                    recAzulVida.SetActive(false);
                    recNumSala.SetActive(false); 
                    recAzulSalir.SetActive(true); //brilla el recuadro de salir
                    recAzulHoid.SetActive(false);
                    break;
                case 9:
                    recRojo.SetActive(false);
                    recVerde.SetActive(false);
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(false);
                    recAzulAnswerM.SetActive(false);
                    recAzulVida.SetActive(false);
                    recNumSala.SetActive(false);
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(true); //recuadro de Hoid brilla
                    break; 
                case 10:
                    recRojo.SetActive(false);
                    recVerde.SetActive(false);
                    recAzulQuestion.SetActive(false);
                    recAzulAnswerB.SetActive(false);
                    recAzulAnswerM.SetActive(false);
                    recAzulVida.SetActive(false);
                    recNumSala.SetActive(false);
                    recAzulSalir.SetActive(false);
                    recAzulHoid.SetActive(false);
                    break; //todo a false
            }
        }
        else
        {
            SceneManager.LoadScene("SampleScene"); //si acabas el tutorial vas al juego
        }
    }

    public void goMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void confirmSalir()
    {    
        pantallaSalir.SetActive(true);
        messageField.text = messageExit;
    }
    public void continuePlaying()
    {
        pantallaSalir.SetActive(false);
        messageField.text = txtsArr[messageIndex]; //Hoid sigue explicando desde donde lo dejó
    }

}

