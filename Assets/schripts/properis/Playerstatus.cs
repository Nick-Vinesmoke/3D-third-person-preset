using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/status")]

public class Playerstatus : ScriptableObject
{
    public bool isAiming;
    public bool isSprinting;
    public bool isGround;
    public bool Isruning;
    public bool isAimingMove;
    public bool IsCouching;


}
