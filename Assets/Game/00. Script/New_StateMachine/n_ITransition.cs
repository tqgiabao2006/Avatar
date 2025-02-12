using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  n_ITransition 
{
    n_IState To {get;}
    n_IPredicate Condition {get;}
  
}
