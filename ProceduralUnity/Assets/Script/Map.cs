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
    int idX;
    int idZ;

    public Map(Mesh mesh, int idX, int idZ)
    {
        this.mesh = mesh;
        this.idX = idX;
        this.idZ = idZ;

        CreateTile();
    }

    public void CreateTile()
    {
        
        tileGO = new GameObject("Tile" + idX + "_" + idZ);
        tileGO.AddComponent<MeshFilter>();
        tileGO.AddComponent<MeshRenderer>();
        tileGO.GetComponent<MeshFilter>().mesh = mesh;
        tileGO.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Material");
        tileGO.GetComponent<MeshRenderer>().material.color = color;
        tileGO.transform.position = new Vector3(idX + 1,0, idZ + 1);
         
        
        


    }
    public void AtualizaCor(Color color)
    {
        tileGO.GetComponent<MeshRenderer>().material.color = color;
    }

}
