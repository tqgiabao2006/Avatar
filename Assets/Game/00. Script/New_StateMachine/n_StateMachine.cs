using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class n_StateMachine 
{
    StateNode current;
    Dictionary<Type,StateNode> nodes =  new();
    HashSet<n_ITransition> anyTransitions = new();

    public void Update()
    {
        var transition = GetTransition();
        if(transition != null)
        {
            ChangeState(transition.To);
        }
        current.State?.OnUpdate();
    }

    public void SetState(n_IState state)
    {
        current = nodes[state.GetType()];
        current.State?.OnEnter();

    }

    protected void ChangeState(n_IState state)
    {
        if(current == current.State) return;

        var previousState = current.State;
        var nextStte = nodes[state.GetType()].State;
        previousState?.OnExit();
        nextStte?.OnEnter();
        current = nodes[state.GetType()];

    }
public void AddTransition(n_IState from, n_IState to, n_IPredicate condition)
{
    GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
}
public void AddAnyTranition(n_IState to, n_IPredicate condition)
{
    anyTransitions.Add(new n_Transition(GetOrAddNode(to).State, condition));
}

StateNode GetOrAddNode(n_IState state)
{
    var node =nodes.GetValueOrDefault(state.GetType());
    if(node == null)
    {
        node = new StateNode(state);
        nodes.Add(state.GetType(), node);
    }
    return node;
}
 n_ITransition GetTransition()
 {
    foreach (var transition in anyTransitions)
        {
            if(transition.Condition.Evaluate()) return transition;
        }
    foreach (var transition in current.Transitions)
    {
        if(transition.Condition.Evaluate()) return transition;

    }
    return null;
 }
  

  class StateNode
  {
    public n_IState State {get;}
    public HashSet<n_ITransition> Transitions {get;}

    public StateNode (n_IState state)
    {
        State = state;
        Transitions = new HashSet<n_ITransition>();
    }

    public void AddTransition(n_IState To, n_IPredicate Condition)
    {
        Transitions.Add(new n_Transition(To,Condition));
    }
  }
}
