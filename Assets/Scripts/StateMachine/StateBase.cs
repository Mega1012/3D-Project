using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plataformer.StateMachine
{
    public class StateBase
    {
        public virtual void OnStateEnter(params object[] objs)
        {
            //Debug.Log("On State Enter");
        }

        public virtual void OnChangeState()
        {
            
        }

        public virtual void OnStatestay()
        {
            
        }
        public virtual void OnStateExit()
        {
            
        }
    }
}

