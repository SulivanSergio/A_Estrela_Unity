using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    const int MAX = 5;

    Map[,] map = new Map[MAX, MAX];
    Map[,] visitados = new Map[MAX,MAX];
    public Mesh mesh;
    void Start()
    {

        for(int i = 0; i < MAX; i++)
        {
            for (int j = 0; j < MAX; j++)
            {

                map[i,j] = new Map(mesh,i,j);


            }


        }

        for (int i = 0; i < MAX; i++)
        {
            for (int j = 0; j < MAX; j++)
            {

                if (!map[i, j].visitado)
                {
                    visitados[i, j] = map[i, j];
                }


            }


        }
        

    }

    
    void Update()
    {
        
    }

    public void NaoVisitados(Map visitado)
    {

        if (!visitado.visitado)
        {
            visitado.AtualizaCor(Color.blue);
            visitado.visitado = true;
        }
        


    }



}
