using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n_Transition : n_ITransition
{

   public  n_IState To {get;}
   public n_IPredicate Condition {get;}

   public n_Transition(n_IState To, n_IPredicate Condition)
   {
     this.To = To;
     this.Condition = Condition;
   }
  
   
}
