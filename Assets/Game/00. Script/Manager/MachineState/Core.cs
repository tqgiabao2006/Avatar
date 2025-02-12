using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Core : MonoBehaviour
{
    public Rigidbody2D _rb;
    public Animator _anim;
    // public GroundCensor _groundCensor;
  
    [field: SerializeField] public MachineState _machine;

    public void SetUpInstances()
    {
        _machine = new MachineState();
        State_Base[] allChildStates = GetComponentsInChildren<State_Base>();
        foreach (State_Base state in allChildStates)
        {
            state.SetCore(this);
        }
    }

}
