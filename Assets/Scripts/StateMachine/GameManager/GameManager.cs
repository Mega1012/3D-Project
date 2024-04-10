using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plataformer.Core.Singleton;
using Plataformer.StateMachine;
using NaughtyAttributes;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        IDLE,
        RUNNING,
        JUMPING,
        PAUSE,
        FALLING,
        WIN,
        LOSE
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<GameStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.IDLE, new GMStateIdle());
        stateMachine.RegisterStates(GameStates.RUNNING, new GMStateRun());
        stateMachine.RegisterStates(GameStates.JUMPING, new GMStateJump());
        
        stateMachine.SwitchState(GameStates.RUNNING);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.SwitchState(GameStates.IDLE);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SwitchState(GameStates.JUMPING);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.SwitchState(GameStates.RUNNING);
        }
    }
}
