using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main2 : MonoBehaviour
{
    
    List<Animal> animal = new List<Animal>();
    public Mesh mesh;

    private int tempo = 0;
    private float MAX = 20;
    public Text text;

    void Start()
    {
        text.text = UnityEngine.Random.Range(0.1f,0.9f).ToString();
        for(int i = 0; i<6; i++)
        {
            switch(i)
            {
                case 0:
                    animal.Add(new Animal(mesh, i, new Vector4(Color.blue.a, Color.blue.g, Color.blue.b, 1)));
                    break;
                case 1:
                    animal.Add(new Animal(mesh, i, new Vector4(0, 0, 0, 1)));
                    break;
                case 2:
                    animal.Add(new Animal(mesh, i, new Vector4(Color.red.a, Color.red.g, Color.red.b, 1)));
                    break;
                case 3:
                    animal.Add(new Animal(mesh, i, new Vector4(Color.yellow.a, Color.yellow.g, Color.yellow.b, 1)));
                    break;
                case 4:
                    animal.Add(new Animal(mesh, i, new Vector4(Color.cyan.a, Color.cyan.g, Color.cyan.b, 1)));
                    break;
                case 5:
                    animal.Add(new Animal(mesh, i, new Vector4(Color.gray.a, Color.gray.g, Color.gray.b, 1)));
                    break;


            }
            
        }
        
    }

   
    void Update()
    {
        if (animal.Count >= 100)
        {


            for (int i = 0; i < animal.Count/2; i++)
            {
                if (float.Parse(text.text) > 0.5f)
                {
                    if ((animal[i].color.x + animal[i].color.y + animal[i].color.z) / 3 < float.Parse(text.text))
                    {
                        Destroy(animal[i].animalGO);
                        animal.Remove(animal[i]);

                    }
                }
                else
                {
                    if ((animal[i].color.x + animal[i].color.y + animal[i].color.z) / 3 > float.Parse(text.text))
                    {
                        Destroy(animal[i].animalGO);
                        animal.Remove(animal[i]);

                    }
                }
                
            }


        }
        if(animal.Count >= 300)
        {
            for (int i = 0; i < animal.Count / 2; i++)
            {
                Destroy(animal[i].animalGO);
                animal.Remove(animal[i]);
            }
        }

        tempo++;
        if (tempo >= MAX)
        {
            tempo = 0;

            Animal filho = new Animal(mesh, animal.Count, new Vector4(0, 0, 0, 1));
            Randomiza(filho);


        }
        for (int i = 0; i < animal.Count; i++)
        {
            animal[i].Update(Time.deltaTime);
        }

        



    }

    public void Randomiza(Animal ani)
    {
        Vector2 pai = new Vector2(UnityEngine.Random.Range(0, animal.Count), UnityEngine.Random.Range(0, animal.Count));
        

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

        novaCor = new Vector4((ani1.color.x + ani2.color.x) /2, (ani1.color.y + ani2.color.y)/2,(ani1.color.z + ani2.color.z)/2, ani2.color.w);
        int r = UnityEngine.Random.Range(0, 4);
        int r2 = UnityEngine.Random.Range(0, 2);
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
