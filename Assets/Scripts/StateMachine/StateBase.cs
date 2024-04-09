using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase
{
    public virtual void OnStateEnter(object O = null)
    {
        Debug.Log("OnStateEnter");
    }
    public virtual void OnStatestay()
    {
        Debug.Log("OnStatestay");
    }
    public virtual void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }
}

