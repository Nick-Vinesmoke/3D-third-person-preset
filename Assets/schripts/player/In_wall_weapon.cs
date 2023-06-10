using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_wall_weapon : MonoBehaviour
{
    public Playerstatus ps;




    private void OnTriggerStay(Collider other)
    {
        if (ps.isAiming)
        {
            ps.isAiming = false;
            
        }
    }
}
