using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Plataformer.StateMachine
{
    public class StateBase
    {
        public virtual void OnStateEnter(object O = null)
        {
            Debug.Log("Entrou no Estado");
        }

        public virtual void OnChangeState()
        {
            
        }

        public virtual void OnStatestay()
        {
            Debug.Log("Ficou no estado");
        }
        public virtual void OnStateExit()
        {
            Debug.Log("Mudou de Estado");
        }
    }
}

