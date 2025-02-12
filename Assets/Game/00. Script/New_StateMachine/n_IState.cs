using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface n_IState 
{
    void OnEnter();
    void OnExit();
    void OnUpdate();
    void OnFixedUpdate();
}
