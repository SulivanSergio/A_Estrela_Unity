using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MEF
{
    public GameObject animalGO;

    public int id;
    public Vector4 color;
    string paiName = "";
    string maeName ="";

    public Animal(Mesh mesh,int id, Vector4 color) : base ()
    {
        this.color = color;
        this.id = id;
        CreateAnimal(mesh);
    }
    public void Update(float gameTime)
    {

        base.UpdateState(gameTime, animalGO);

    }

    public void CreateAnimal(Mesh mesh)
    {

        animalGO = new GameObject("Animal" + this.id +" Pai: " + paiName + " Mae: " + maeName);
        animalGO.AddComponent<MeshFilter>();
        animalGO.AddComponent<MeshRenderer>();
        animalGO.GetComponent<MeshFilter>().mesh = mesh;
        animalGO.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material1");
        animalGO.GetComponent<MeshRenderer>().material.color = color;
        
    }

    public void AtualizaColor()
    {

        animalGO.GetComponent<MeshRenderer>().material.color = color;

    }
    public void AtualizaNome(string pai, string mae)
    {
        this.paiName = pai;
        this.maeName = mae;
        animalGO.name = "Animal" + this.id + " Pai: " + paiName + " Mae: " + maeName;

    }


}
