using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : IPersonagem
{


    GameObject personagemGO;
    
    float speed = 10;
    Vector2 direction;
    List<IMiseel> imissel = new List<IMiseel>();
    public Personagem()
    {
        personagemGO = new GameObject("Personagem");
        personagemGO.AddComponent<SpriteRenderer>();
        personagemGO.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Square");

    }


   
    public void Update(float gameTime)
    {
        Move(gameTime);
    }

    private void Move(float gameTime)
    {
        
        
        if(Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
            personagemGO.transform.position -= new Vector3(gameTime * speed ,0,0); 
        }
        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
            personagemGO.transform.position += new Vector3(0,gameTime * speed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
            personagemGO.transform.position -= new Vector3(0,gameTime * speed, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            personagemGO.transform.position += new Vector3(gameTime * speed, 0, 0);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            imissel.Add(new Missel(direction));
        }

    }

    public GameObject GetGameObject()
    {
        return personagemGO;
    }

}
