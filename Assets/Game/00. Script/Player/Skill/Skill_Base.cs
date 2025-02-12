using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType 
{
    White,
    Red,
    Blue,

}
[CreateAssetMenu(menuName = "Skills/ Player_Skills")]
public class Skill_Base : ScriptableObject
{

    public float damge;
    public float CoolDown;
    
    public float cost;
    public AttackType attackType;

    public bool canActivate;
   public AnimationClip animationClip;

}
