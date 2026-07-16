using UnityEngine;


public interface Istate<T>
{
    public void Enter(T obj);
    public void Exit(T obj);
    public void Update(T obj);
}

public class StateMachin<T>
{
    protected Istate<T> currentState;

    private T obj;

    public void ChangeState(Istate<T> state)
    {
        currentState.Exit(obj);
        currentState = state;
        currentState.Enter(obj);
    }

    public void Update()
    {
        currentState.Update(obj);
    }


}
