using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map 
{
    const int MAX = 5;
    GameObject tileGO;
    Mesh mesh;
    public Color color = Color.black;
    public bool visitado = false;
    public int idX;
    public int idY;
    public int peso = 0;

    public Map(Mesh mesh, int idX, int idZ)
    {
        this.mesh = mesh;
        this.idX = idX;
        this.idY = idZ;

        CreateTile();
    }

    public void CreateTile()
    {
        
        tileGO = new GameObject("Tile" + idX + "_" + idY);
        tileGO.AddComponent<MeshFilter>();
        tileGO.AddComponent<MeshRenderer>();
        tileGO.GetComponent<MeshFilter>().mesh = mesh;
        tileGO.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material");
        tileGO.GetComponent<MeshRenderer>().material.color = color;
        tileGO.transform.position = new Vector3(idX + 1,0, idY + 1);
         
        
        


    }
    public void AtualizaCor(Color color)
    {
        tileGO.GetComponent<MeshRenderer>().material.color = color;
    }

}
