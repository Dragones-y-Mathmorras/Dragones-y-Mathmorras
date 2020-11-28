using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Text t1;
    public Text t2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getN1() //devuelve un numero aleatorio del 1 al 10 (int)
    {
        t1.text = Random.Range(1, 11).ToString();
        return int.Parse(t1.text);       
    }
    public int getN2() //devuelve un numero aleatorio del 1 al 10 (int)
    {
        t2.text = Random.Range(1, 11).ToString();
        return int.Parse(t2.text);      
    }
}
