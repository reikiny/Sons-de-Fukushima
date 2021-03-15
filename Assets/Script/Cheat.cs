using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour
{
    public float speedFast;
    float speedNormal;
    public Toggle cheat;

    void Start()
    {
        speedNormal = Controller.Instance.PlayerSpeed;
    }

    public void Change(bool on)
    {
        if (on){

            Controller.Instance.PlayerSpeed = speedFast;
            Controller.Instance.RunningSpeed = speedFast+2f;
        }
        else{

            Controller.Instance.PlayerSpeed = speedNormal;
            Controller.Instance.RunningSpeed = speedNormal+2f;
        }

        Controller.Instance.podePular = on;
    }
}
