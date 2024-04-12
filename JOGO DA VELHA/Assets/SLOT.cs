using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLOT : MonoBehaviour
{
    public GameObject Jogador;

    private Boolean PositionValue = false;

    // Start is called before the first frame update

    void OnMouseDown()
    {
       
        if (dinamicaDoJogo.Jogada == 1)
        {
            Debug.Log("Ouch!");
            for (int u = 0; u < 10; u++)
            {

                if (this.gameObject.name == String.Concat("Slot", u) && PositionValue == false) //Slot clicado é resgatado
                {
           
                    PositionValue = true;
                    
                    dinamicaDoJogo.po[u] = 2;  //A matriz do script dinamicaDoJogo recebe a peça do jogador na respectiva posição clicada
                    Instantiate(Jogador, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity); ;
                    //Coloca a peça CUBO na posição clicada
                    dinamicaDoJogo.Jogada = 2;
                    dinamicaDoJogo.Andamento++;

                }

            }
        }
    }
}
