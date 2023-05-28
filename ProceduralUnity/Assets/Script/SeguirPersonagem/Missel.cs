using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missel : IMiseel
{
    GameObject misselGO;
    GameObject alvo;
    float speed = 10f;
    
    Vector3 direction = new Vector3(0,0);
    public Missel(Vector2 alvo)
    {
        misselGO = new GameObject("Missel");
        misselGO.AddComponent<SpriteRenderer>();
        misselGO.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Circle");

        

        misselGO.transform.position = new Vector3(5f,0,0);
    }

   


    public void Update(float gameTime)
    {
        Move(gameTime);
    }

    private void Move(float gameTime)
    {
        
        if((Distancia(alvo,misselGO).x <= 500f  &&  Distancia(alvo, misselGO).y <= 500f))
        {
            direction = Direction(alvo,misselGO);
            misselGO.transform.position += new Vector3(gameTime * speed * direction.x, gameTime * speed * direction.y, 0f);
        }
        else
        {
            misselGO.transform.position += new Vector3(gameTime * speed * direction.x, gameTime * speed * direction.y, 0f);
        }
        



    }
    private Vector2 Distancia(GameObject alvo, GameObject objeto )
    {
        Vector2 distancia;
        

        distancia = new  Vector2(Mathf.Abs((alvo.transform.position.x * alvo.transform.position.x) - (objeto.transform.position.x * objeto.transform.position.x)), Mathf.Abs((alvo.transform.position.y * alvo.transform.position.y) - (objeto.transform.position.y * objeto.transform.position.y)));
        
        
        return distancia;
    }

    private Vector2 Direction(GameObject alvo, GameObject objeto)
    {
        Vector2 dir = Distancia(alvo, objeto);
        dir = dir.normalized;
        if (alvo.transform.position.x <= objeto.transform.position.x)
        {
            dir.x *= -1;
        }
        if (alvo.transform.position.y <= objeto.transform.position.y)
        {
            dir.y *= -1;
        }
        return dir;
    }

    public void SetAlvo(GameObject alvo)
    {
        this.alvo = alvo;
    }

}
