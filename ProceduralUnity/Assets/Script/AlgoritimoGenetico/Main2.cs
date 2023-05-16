using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main2 : MonoBehaviour
{
    
    List<Animal> animal = new List<Animal>();
    public Mesh mesh;

    private int tempo = 0;
    private float MAX = 100;

    void Start()
    {

        for(int i = 0; i<5; i++)
        {
            animal.Add(new Animal(mesh,i,new Vector4(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.5f, 1.0f) )));
        }
        
    }

   
    void Update()
    {
        if (animal.Count <= 100)
        {


            tempo++;
            if (tempo >= MAX)
            {
                tempo = 0;

                Animal filho = new Animal(mesh, animal.Count, new Vector4(0, 0, 0, 1));
                Randomiza(filho);


            }
        }
        for (int i = 0; i < animal.Count; i++)
        {
            animal[i].Update(Time.deltaTime);
        }

        



    }

    public void Randomiza(Animal ani)
    {
        Vector2 pai = new Vector2(Random.Range(0, animal.Count), Random.Range(0, animal.Count));
        

        if (pai.x != pai.y)
        {
            ani.color = Cruzar(animal[(int)pai.x], animal[(int)pai.y]);
            ani.AtualizaColor();
            ani.AtualizaNome(animal[(int)pai.x].id.ToString(), animal[(int)pai.y].id.ToString());
            animal.Add(ani);
            
        }
        else
        {
            Randomiza(ani);
        }

       
    }

    public Vector4 Cruzar(Animal ani1, Animal ani2)
    {
        Vector4 novaCor;

        novaCor = new Vector4(ani1.color.x, ani1.color.y, ani2.color.z, ani2.color.w);
        int r = Random.Range(0, 4);
        int r2 = Random.Range(0, 2);
        switch (r2)
        {
            case 0:
                switch (r)
                {

                    case 0:
                        novaCor.x = ani1.color.x;
                        break;
                    case 1:
                        novaCor.y = ani1.color.y;
                        break;
                    case 2:
                        novaCor.z = ani1.color.z;
                        break;
                    case 3:
                        novaCor.w = ani1.color.w;
                        break;


                }
                break;
            case 1:
                switch (r)
                {

                    case 0:
                        novaCor.x = ani2.color.x;
                        break;
                    case 1:
                        novaCor.y = ani2.color.y;
                        break;
                    case 2:
                        novaCor.z = ani2.color.z;
                        break;
                    case 3:
                        novaCor.w = ani2.color.w;
                        break;


                }
                break;
        }


        return novaCor;
    }


}
