using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    const int MAX = 11;

    Map[,] map = new Map[MAX, MAX];
    Map person, objetivo;
    

    public Mesh mesh;

    int posEscolhidaX = 6;
    int posEscolhidaY = 6;

    int posPersonX = 4;
    int posPersonY = 4;

    List<Map> pilha = new List<Map>();


    void Start()
    {
        posEscolhidaX = (int)UnityEngine.Random.Range(0, MAX - 1);
        posEscolhidaY = (int)UnityEngine.Random.Range(0, MAX - 1);

        posPersonX = (int)UnityEngine.Random.Range(0, MAX - 1);
        posPersonY = (int)UnityEngine.Random.Range(0, MAX - 1);



        for (int i = 0; i < MAX; i++)
        {
            for (int j = 0; j < MAX; j++)
            {

                map[i, j] = new Map(mesh, i, j);


            }


        }



        CriarPesos();

        ColorindoPesos();

        CriandoPerson();
        CriandoDestino();

        CriandoParede();

        Busca(person, map);

        ImprimePilha();
        //MostraGridPercorrido();

        //MostrarPesos();

    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pilha.Clear();
            posEscolhidaX = (int)UnityEngine.Random.Range(0, MAX - 1);
            posEscolhidaY = (int)UnityEngine.Random.Range(0, MAX - 1);

            posPersonX = (int)UnityEngine.Random.Range(0, MAX - 1);
            posPersonY = (int)UnityEngine.Random.Range(0, MAX - 1);


            CriarPesos();

            ColorindoPesos();

            CriandoPerson();
            CriandoDestino();
            
            CriandoParede();


            Busca(person, map);

            ImprimePilha();
            //MostraGridPercorrido();

        }


    }

    private void ColorindoPesos()
    {
        for (int i = 0; i < MAX; i++)
        {
            for (int j = 0; j < MAX; j++)
            {

                if (map[i,j].peso%2 == 0)
                {
                    map[i, j].AtualizaCor(Color.cyan);
                } else
                {
                    map[i, j].AtualizaCor(Color.gray);
                }


            }


        }
    }

    private void CriarPesos()
    {
        /*
            1,1

        0,0
        2,2

        2,0
        0,2

        -+X
        0,1
        2,1

        +-Y
        1,0
        1,2


         */


        for (int i = 0; i < MAX; i++)
        {
            for (int j = 0; j < MAX; j++)
            {

                // DISTANCIA
                //int distanciaX = (int)Mathf.Sqrt(Mathf.Pow(map[i, j].idX - posEscolhidaX, 2));
                //Debug.Log("DistanciaX: " + distanciaX + "Index X e Y: " + i + " " + j);

                //int distanciaY = (int)Mathf.Sqrt(Mathf.Pow(map[i, j].idY - posEscolhidaY, 2));
                //Debug.Log("DistanciaY: " + distanciaY + "Index X e Y: " + i + " " + j);


                int distancia = Mathf.Abs(map[i, j].idX - posEscolhidaX) + Mathf.Abs(map[i, j].idY - posEscolhidaY);
                map[i, j].peso = distancia;



                //map[i, j].peso = distanciaX + distanciaY - 1;
                //Debug.Log("DistanciaX: " + distanciaX + " DistanciaY: " + distanciaY + " Peso: " + map[i, j].peso + " Index X e Y: " + i + " " + j);
                //int distancia = Mathf.Abs(map[i, j].idX - posEscolhidaX) + Mathf.Abs(map[i, j].idY - posEscolhidaY);
                //map[i, j].peso = distancia;

            }


        }

    }

    private void CriandoPerson()
    {

        for (int i = 0; i < MAX; i++)
        {
            for (int j = 0; j < MAX; j++)
            {

                if (map[i, j].idX == posPersonX && map[i, j].idY == posPersonY)
                {
                    person = map[i, j];
                    person.AtualizaCor(Color.white);
                }

            }
        }


    }

    private void CriandoDestino()
    {

        for (int i = 0; i < MAX; i++)
        {
            for (int j = 0; j < MAX; j++)
            {

                if (map[i, j].idX == posEscolhidaX && map[i, j].idY == posEscolhidaY)
                {
                    objetivo = map[i, j];
                    objetivo.AtualizaCor(Color.white);
                }

            }
        }


    }

    private void Busca(Map person, Map[,] map)
    {



        if (person.idX + 1 < MAX && person.idY < MAX && person.idX + 1 >= 0 && person.idY >= 0)
        {

            if (map[person.idX + 1, person.idY].peso < person.peso)
            {

                if (map[person.idX + 1, person.idY].peso > 0)
                {

                    pilha.Add(map[person.idX + 1, person.idY]);
                    Busca(map[person.idX + 1, person.idY],  map);

                }
                else
                {
                    pilha.Add(map[person.idX + 1, person.idY]);
                    
                }



            }



        }


        if (person.idX - 1 < MAX && person.idY < MAX && person.idX - 1 >= 0 && person.idY >= 0)
        {

            if (map[person.idX - 1, person.idY].peso < person.peso)
            {
                if (map[person.idX - 1, person.idY].peso > 0)
                {

                    pilha.Add(map[person.idX - 1, person.idY]);
                    Busca(map[person.idX - 1, person.idY],  map);

                }
                else
                {
                    pilha.Add(map[person.idX - 1, person.idY]);
                    
                }


            }



        }



        if (person.idX < MAX && person.idY + 1 < MAX && person.idX >= 0 && person.idY + 1 >= 0)
        {

            if (map[person.idX, person.idY + 1].peso < person.peso)
            {
                if (map[person.idX, person.idY + 1].peso > 0)
                {

                    pilha.Add(map[person.idX, person.idY + 1]);
                    Busca(map[person.idX, person.idY + 1],  map);

                }
                else
                {
                    pilha.Add(map[person.idX, person.idY + 1]);
                    
                }



            }
        }

        if (person.idX < MAX && person.idY - 1 < MAX && person.idX >= 0 && person.idY - 1 >= 0)
        {

            if (map[person.idX, person.idY - 1].peso < person.peso)
            {

                if (map[person.idX, person.idY - 1].peso > 0)
                {

                    pilha.Add(map[person.idX, person.idY - 1]);
                    Busca(map[person.idX, person.idY - 1],  map);

                }
                else
                {
                    pilha.Add(map[person.idX, person.idY - 1]);
                    
                }



            }
        }

       


    }

    private void ImprimePilha()
    {

        for (int i = 0; i < pilha.Count; i++)
        {
            if (pilha[i].peso != 0)
            {
                //Debug.Log("X: " + pilha[i].idX + " Y: " + pilha[i].idY + "Peso: " + pilha[i].peso);
                pilha[i].AtualizaCor(Color.red);
            }
            else
            {
                //Debug.Log("X: " + pilha[i].idX + " Y: " + pilha[i].idY + "Peso: " + pilha[i].peso);
                pilha[i].AtualizaCor(Color.yellow);
                return;
            }

        }

    }
    private void MostraGridPercorrido()
    {
        for (int i = 0; i < pilha.Count; i++)
        {     
                pilha[i].AtualizaCor(Color.red);
        }
    }

    private void MostrarPesos()
    {
        for (int i = 0; i < MAX; i++)
        {
            for (int j = 0; j < MAX; j++)
            {
                if(map[i,j].peso == 1)
                {
                    map[i, j].AtualizaCor(Color.cyan);
                }
                if (map[i, j].peso == 2)
                {
                    map[i, j].AtualizaCor(Color.gray);
                }
                if (map[i, j].peso == 3)
                {
                    map[i, j].AtualizaCor(Color.green);
                }
                if (map[i, j].peso == 4)
                {
                    map[i, j].AtualizaCor(Color.red);
                }

            }
        }


    }

    private void CriandoParede()
    {
        
        for (int i = 1; i < 8; i++)
        {
            
                map[6, i].peso *= 100;
                map[6, i].AtualizaCor(Color.black);
            

        }

    }
    
    
}


        


