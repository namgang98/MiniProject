using Unity.VisualScripting;
using UnityEngine;


public interface IState<T>
{
    public void Enter(T obj);
    public void Exit(T obj);
    public void Update(T obj);
}

public class StateMachin<T>
{

    protected IState<T> currentState;

    private T obj;

public void ChangeState(IState<T> state)
    {
        currentState.Exit(obj);
        currentState = state;
        currentState.Enter(obj);
    }

    public void Update() => currentState?.Update(obj);



}

