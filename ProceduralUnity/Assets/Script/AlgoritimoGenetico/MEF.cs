
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class MEF
{
    public enum STATE
    {
        XP,
        XN,
        YP,
        YN,
        ZP,
        ZN

    }



    private GameObject gameObject;
    private STATE state = STATE.YP;

    private float speed = 5f;
    private int tempo = 0;
    private float MAX = 60;


    public void UpdateState(float gameTime, GameObject gameObject)
    {
        tempo++;
        if (tempo >= MAX)
        {
            tempo = 0;
            ChangeState();
        }

        switch (state)
        {

            case STATE.XP:
                gameObject.transform.position += new Vector3(speed * gameTime, 0, 0);
                break;
            case STATE.XN:
                gameObject.transform.position -= new Vector3(speed * gameTime, 0, 0);
                break;
            case STATE.YP:
                gameObject.transform.position += new Vector3(0, speed * gameTime, 0);
                break;
            case STATE.YN:
                gameObject.transform.position -= new Vector3(0, speed * gameTime, 0);
                break;
            case STATE.ZP:
                gameObject.transform.position += new Vector3(0, 0, speed * gameTime);
                break;
            case STATE.ZN:
                gameObject.transform.position -= new Vector3(0, 0, speed * gameTime);
                break;

        }

        
    }

    public void ChangeState()
    {
        int r = UnityEngine.Random.Range(0, 5);
        switch (state)
        {
            case STATE.XP:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;


                }
                break;
            case STATE.XN:
                switch (r)
                {
                    case 0:
                        state = STATE.XP;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;
                }



                break;

            case STATE.YP:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.XP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;


                }
                break;
            case STATE.YN:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.XP;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;


                }
                break;

            case STATE.ZP:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.XP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;


                }
                break;
            case STATE.ZN:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.XP;
                        break;


                }
                break;


        }
    }

   


}
