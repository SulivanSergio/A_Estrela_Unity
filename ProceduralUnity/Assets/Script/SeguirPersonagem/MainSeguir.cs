using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSeguir : MonoBehaviour
{
    IPersonagem iPersonagem;
    IMiseel iMissel;
    void Start()
    {
        iPersonagem = new Personagem();
        
    }

    
    void Update()
    {
        iPersonagem.Update(Time.deltaTime);
        

    }
}
