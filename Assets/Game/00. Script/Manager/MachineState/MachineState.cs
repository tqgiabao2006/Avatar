using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MachineState 
{

    public State_Base _state;
        
    public void Set(State_Base newState, bool forceSet = false)
    {    if(_state != newState || forceSet)
        {
            _state?.Exit();
            _state = newState;
            _state.Initialise(this);
            _state.Enter();

        }
        


    }
    // public List<State_Base> GetActiveStateBranch(List<State_Base> list = null)
    //  {
    //     if(list == null)
    //     {
    //      list = new List<State_Base>();
    //     }

    //     if(list == null)
    //     {
    //      return list;
    //     }else
    //     {
    //      list.Add(_state);
    //      return _state._machine.GetActiveStateBranch(list);

    //     }
    //  }
     
       

   


}
