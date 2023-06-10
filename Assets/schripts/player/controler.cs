using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controler : MonoBehaviour
{
    public player_movement pm;
    public Player_animation pa;
    public Player_input pi;


    public void Update()
    {
        pm.MoveUpdate();
        pa.AnimUpdate();
        pi.InputUpdate();
    }
}
