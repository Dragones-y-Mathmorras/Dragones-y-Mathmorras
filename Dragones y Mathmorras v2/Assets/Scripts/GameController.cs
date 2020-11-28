using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public GameObject answerBox1;
    public GameObject answerBox2;
    public GameObject answerBox3;
    public GameObject questionBox;
    public RawImage backgroundImg;
    public Texture room2;
    public Sprite door2;
    public Sprite answerBoxSprite;

    public Text numSala;

    private Text numberBox1;
    private Text numberBox2;
    private Text numberBox3;

    private GameObject pantallaPerdido;
    private GameObject pantallaGanado;

    private GameObject pantallaEntradaMaz;
    private GameObject pantallaPerdidoMaz;
    private GameObject pantallaGanadoMaz;

    private GameObject pantallaSalir;

    private Text[] answers;
    private GameObject[] answerBoxes;

    private int q1;
    private int q2;
    public int result;
    private int result1;
    private int result2;
    private int decidirMalo;

    private int rightAns;
    public int vidas;

    // Start is called before the first frame update
    public void Start()
    {      
        //Empiezas con 3 vidas
        vidas = 3;

        
        if (SceneManager.GetActiveScene().name == "SampleScene")//si estamos en la escena del Juego
        { 

            //Inicialmente no sale la pantalla de que hayas perdido
            pantallaPerdido = GameObject.Find("PantallaHasPerdido");
            pantallaPerdido.SetActive(false);

            //Inicialmente no sale la pantalla de que hayas ganado tampoco
            pantallaGanado = GameObject.Find("PantallaHasGanado");
            pantallaGanado.SetActive(false);
        }
        else //si estamos en la mazmorra
        {
            //Inicialmente no sale la pantalla de que hayas llegado a la mazmorra
            pantallaEntradaMaz = GameObject.Find("EntradaMazmorra");
            pantallaEntradaMaz.SetActive(true);

            //Inicialmente no sale la pantalla de que hayas perdido en la mazmorra
            pantallaPerdidoMaz = GameObject.Find("SalidaMazmorra");
            pantallaPerdidoMaz.SetActive(false);

            //Inicialmente no sale la pantalla de que hayas ganado en la mazmorra tampoco
            pantallaGanadoMaz = GameObject.Find("VictoriaMazmorra");
            pantallaGanadoMaz.SetActive(false);
        }

        //Inicialmente, no sale la pantalla de si quieres salir
        pantallaSalir = GameObject.Find("ConfirmSalir");
        pantallaSalir.SetActive(false);

        //Textos de las cajas de respuesta
        numberBox1 = answerBox1.GetComponentInChildren<Text>();
        numberBox2 = answerBox2.GetComponentInChildren<Text>();
        numberBox3 = answerBox3.GetComponentInChildren<Text>();

        answers = new Text[] { numberBox1, numberBox2, numberBox3 }; //guardo los textos en un array    

        answerBoxes = new GameObject[] { answerBox1, answerBox2, answerBox3 }; //me guardo las cajas de respuesta tambien en un array

        //Le doy valor a las posibles respuestas en funcion de los operandos    
        darValores();
    }

    // Update is called once per frame
    void Update()
    {

        if(SceneManager.GetActiveScene().name == "SampleScene")
        { 
            numSala.text = StaticNumSala.numSala.ToString();
        }

        if ((StaticNumSala.numSala > 10) && SceneManager.GetActiveScene().name == "SampleScene") //si nuestra puntuacion es superior a 10 y estamos en la torre (no en la mazmorra) cambiamos los Textures dela sala
        {
            changeRoom();
        }
    }

    public void darValores() //Funcion que "resetea" una operacion y las soluciones
    {
        
        //Accedemos a las componentes Text que estan pasadas a Int (INTS DE LOS TERMINOS DE LA PREGUNTA)
        q1 = questionBox.GetComponent<QuestionController>().getN1();
        q2 = questionBox.GetComponent<QuestionController>().getN2();

        rightAns = Random.Range(0, 3); //numero aleatorio entre el 1 y el 3, que valdra para determinar que caja alberga la repuesta correcta  
        
        //resultado de la operacion
        result = q1 * q2;

        //variables para asignar los valores malos y el bueno a las puertas
        result1 = (q1 + 1) * q2;
        result2 = q1 * (q2 + 1);
        decidirMalo = Random.Range(0, 2);

        //asignamos valores a las posibles respuestas
        if (q1 == q2)
        {
            result1 = (q1 + 2) * q2;
            result2 = q1 * (q2 + 1);
        }
        if (rightAns == 0)
        {
            answers[0].text = result.ToString();
            if (decidirMalo == 0)
            {
                answers[1].text = result1.ToString();
                answers[2].text = result2.ToString();
            }
            else
            {
                answers[1].text = result2.ToString();
                answers[2].text = result1.ToString();
            }
        }
        if (rightAns == 1)
        {
            answers[1].text = result.ToString();
            if (decidirMalo == 0)
            {
                answers[0].text = result1.ToString();
                answers[2].text = result2.ToString();
            }
            else
            {
                answers[0].text = result2.ToString();
                answers[2].text = result1.ToString();
            }
        }
        if (rightAns == 2)
        {
            answers[2].text = result.ToString();
            if (decidirMalo == 0)
            {
                answers[0].text = result1.ToString();
                answers[1].text = result2.ToString();
            }
            else
            {
                answers[0].text = result2.ToString();
                answers[1].text = result1.ToString();
            }
        }
    }

    private void changeRoom()
    {
        //Cambiamos el fondo
        backgroundImg.texture = room2;

        //Recorremos las cajas con posibles respuestas
        for (int i = 0; i < answerBoxes.Length; i++)
        {
            answerBoxes[i].GetComponentInChildren<Image>().sprite = door2; //Cambiamos las puertas
            answerBoxes[i].GetComponentInChildren<Text>().color = new Color(0.49f, 0.23f, 0.38f); //Cambiamos el color de los numeros de las puertas
        }
        //Recorremos las componentes Text hijos del questionBox
        foreach (Text text in questionBox.GetComponentsInChildren<Text>()) 
        { 
            text.color = new Color(0.35f, 0.11f, 0.29f); //Cambiamos el color de los operandos y del signo de multiplicar
        }
        //Cambiamos el sprite que contiene la operacion
        questionBox.GetComponentInChildren<Image>().sprite = answerBoxSprite;
    }
    public void hasPerdido()
    {
        pantallaPerdido.SetActive(true);
    }

    public void hasGanado()
    {
        pantallaGanado.SetActive(true);
    }

    public void confirmSalir()
    {
        pantallaSalir.SetActive(true);
    }

    public void go2menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void go2Game()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void go2Dungeon()
    {
        SceneManager.LoadScene("DungeonScene");
    }

    public void continuePlaying()
    {
        pantallaSalir.SetActive(false);
    }

    //para dungeon
    public void hasPerdidoMaz()
    {
        pantallaPerdidoMaz.SetActive(true);
    }

    public void hasGanadoMaz()
    {
        pantallaGanadoMaz.SetActive(true);
    }
    public void turnOffIntroMaz()
    {
        pantallaEntradaMaz.SetActive(false);
    }
}
