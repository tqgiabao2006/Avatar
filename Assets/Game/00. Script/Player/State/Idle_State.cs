using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_State : State_Base
{    PlayerController _playerController;

 private void Start()
    {
        _playerController = _core.GetComponent<PlayerController>();

    }

    public override void Enter()
    {
        _anim.Play("Player_Idle");
    }
    public override void Do()
    {

    }
      public override void InExit()
    {
       
    }


}
