using UnityEngine;

public abstract class BaseState<T> : IState<T>
{
    public virtual void Enter(T obj)
    {

    }
    public virtual void Exit(T obj)
    {

    }
    public virtual void Update(T obj)
    {

    }
}
