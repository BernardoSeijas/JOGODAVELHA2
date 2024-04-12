using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class dinamicaDoJogo : MonoBehaviour
{
    public GameObject MachineAux;
    public static GameObject Machine;  //Peça da máquina

    public static int Dificuldade = 0;

    public static int Jogada;
    public static int Andamento;  //Conta o número de jogadas que foram necessárias para o jogador ou a máquina vencerem o jogo
    
    public static int[] po = new int[10];

    public static int jogadaMaquinaEm1;

    void Start()
    {
        jogadaMaquinaEm1 = UnityEngine.Random.Range(1, 10);
        Machine = MachineAux;

        Dificuldade = 2;  //DEFINE O NÍVEL DE DIFICULDADE COMO DIFÍCIL

        Jogada = UnityEngine.Random.Range(1, 3); //ESCOLHE O PRIMEIRO A COMEÇAR 
    }

    void Update()
    {
        

        if (Andamento >= 3)  //Chegou em um momento do jogo no qual é possível vercer ou perder
        {

            TESTECONFLITO();
       
        }
 
        if (Jogada == 2) //Vez da máquina
        {
 
            JOGADAMAQUINA();

        }

    }

    public static double Fil(double a, double b)
    {
        double i = 0;
        if (a != 0 && b != 0)
        {
            i = a / b;
        }
        if (i != 1)
        {
            i = 0;
        }
        return i;
    }
    private static double Fil3(double a, double b, double c)
    {
        double i = 0;

        if (a != 0 && b != 0 && c != 0)
        {
            i = a / b;
        }
        if (a/c != 1 || i != 1)
        {
            i = 0;
        }
        return i;
    }
    public static int Vit(int a, int b, int c)
    {
        int resp = 0;
        if(Fil3(a,b,c) == 1)
        {
            resp = a;
        }
        return resp;
    }

    public static void TESTECONFLITO()
    {

        if (po[1] == 0){
            po[1] = (int)(Fil(po[3] , po[2]) +
            Fil(po[4] , po[7]) +
            Fil(po[5] , po[9]));
            po[1] *= 4;
        }
        if (po[2] == 0)
        {
            po[2] = (int)(Fil(po[5] , po[8]) +
                Fil(po[1] , po[3]));
            po[2] *= 4;
        }
        if (po[3] == 0)
        {
            
            po[3] = (int)(Fil(po[1] , po[2]) +
                Fil(po[5] , po[7]) +
                Fil(po[6] , po[9]));
            po[3] *= 4;
        }
        if (po[4] == 0)
        {
            po[4] = (int)(Fil(po[1] , po[7]) +
                Fil(po[5] , po[6]));
            po[4] *= 4;
        }
        if (po[5] == 0)
        {
            po[5] = (int)(Fil(po[4] , po[6]) +
                Fil(po[2] , po[8]) +
                Fil(po[1] , po[9]) +
                Fil(po[3] , po[7]));
            po[5] *= 4;
        }
        if (po[6] == 0)
        {
            po[6] = (int)(Fil(po[3] , po[9]) +
                Fil(po[4] , po[5]));
            po[6] *= 4;
        }
        if (po[7] == 0)
        {
            po[7] = (int)(Fil(po[1] , po[4]) +
                Fil(po[8] , po[9]) +
                Fil(po[3] , po[5]));
            po[7] *= 4;
        }
        if (po[8] == 0)
        {
            po[8] = (int)(Fil(po[2] , po[5]) +
                Fil(po[7] , po[9]));
            po[8] *= 4;
        }
        if (po[9] == 0)
        {
            po[9] = (int)(Fil(po[7] , po[8]) +
                Fil(po[1] , po[5]) +
                Fil(po[3] , po[6]));
            po[9] *= 4;
        }

    }

    public static void JOGADAMAQUINA()
    {
        Boolean conflito = false;
        for (int busc = 1; busc < 10; busc++)
        {
            if (po[busc] == 4)
            {
                Instantiate(Machine, new Vector3(GameObject.Find(String.Concat("Slot",busc)).transform.position.x, GameObject.Find(String.Concat("Slot", busc)).transform.position.y, GameObject.Find(String.Concat("Slot", busc)).transform.position.z), Quaternion.identity); ;
                //Insere a peça da máquina na cena
                po[busc] = 3;  //Insere a peça da máquina na MATRIZ
                Debug.Log("Busc:" + busc);
                conflito = true;
                break;
            }
        }

        if (Dificuldade == 2)
        {
            if (conflito == false)
            {
                
                if (po[5] == 0){
                    Instantiate(Machine, new Vector3(GameObject.Find("Slot5").transform.position.x, GameObject.Find("Slot5").transform.position.y, GameObject.Find("Slot5").transform.position.z), Quaternion.identity); ;
                    //Insere a peça da máquina na cena
                    po[5] = 3;  //Insere a peça da máquina na MATRIZ
                }
                else if (po[1] == 0)
                {
                    Instantiate(Machine, new Vector3(GameObject.Find("Slot1").transform.position.x, GameObject.Find("Slot1").transform.position.y, GameObject.Find("Slot1").transform.position.z), Quaternion.identity); ;
                    //Insere a peça da máquina na cena
                    po[1] = 3;  //Insere a peça da máquina na MATRIZ
                }
                else if (po[3] == 0)
                {
                    Instantiate(Machine, new Vector3(GameObject.Find("Slot3").transform.position.x, GameObject.Find("Slot3").transform.position.y, GameObject.Find("Slot3").transform.position.z), Quaternion.identity); ;
                    //Insere a peça da máquina na cena
                    po[3] = 3;  //Insere a peça da máquina na MATRIZ
                }
                else if (po[7] == 0)
                {
                    Instantiate(Machine, new Vector3(GameObject.Find("Slot7").transform.position.x, GameObject.Find("Slot7").transform.position.y, GameObject.Find("Slot7").transform.position.z), Quaternion.identity); ;
                    //Insere a peça da máquina na cena
                    po[7] = 3;  //Insere a peça da máquina na MATRIZ
                }
                else if (po[9] == 0)
                {
                    Instantiate(Machine, new Vector3(GameObject.Find("Slot9").transform.position.x, GameObject.Find("Slot9").transform.position.y, GameObject.Find("Slot9").transform.position.z), Quaternion.identity); ;
                    //Insere a peça da máquina na cena
                    po[9] = 3;  //Insere a peça da máquina na MATRIZ
                }
            }
        }
        if (Dificuldade == 1 && conflito == false)  //Dificuldade Baixa
        {
            while (po[jogadaMaquinaEm1] != 0)
            {
                jogadaMaquinaEm1 = UnityEngine.Random.Range(0, 10);
            }
            Instantiate(Machine, new Vector3(GameObject.Find(String.Concat("Slot",jogadaMaquinaEm1)).transform.position.x, GameObject.Find(String.Concat("Slot", jogadaMaquinaEm1)).transform.position.y, GameObject.Find(String.Concat("Slot", jogadaMaquinaEm1)).transform.position.z), Quaternion.identity); ;
            //Insere a peça da máquina na cena
            po[jogadaMaquinaEm1] = 3;  //Insere a peça da máquina na MATRIZ
        }
        Andamento++;
        Jogada = 1;

    }
}
