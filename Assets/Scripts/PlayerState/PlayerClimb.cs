﻿using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName ="PlayerClimb",menuName ="PlayerState/Climb")]
public class PlayerClimb : PlayerControllerState
{
    public PlayerJump JumpState;

    public override void OnUpdate(Player player, EntityStateMachine<Player> fsm)
    {
        if (!player.GetComponent<MovableEntity>().Climb(InputManager.Instance.GetMovement().y))
        {
            fsm.ChangeState(JumpState);
            return;
        }
        player.GetComponent<AnimationController>().ChangeAnimation(AnimatorController, 0);

        // Jump
        if (InputManager.Instance.GetAction(InputManager.Instance.JumpAction))
        {
            if (player.GetComponent<MovableEntity>().Jump())
                fsm.ChangeState(JumpState);
        }
    }
}
