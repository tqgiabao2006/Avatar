using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n_FuncPredicate : n_IPredicate
{
    readonly Func<bool> func;
    public n_FuncPredicate(Func<bool> func)
    {
        this.func = func;
    }

    public bool Evaluate() => func.Invoke();
}
