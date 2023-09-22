using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Command
{
    private PlayerMovement _playerMovement;
    public MoveLeft(PlayerMovement playerMovement)
    {
        rb = playerMovement.rb;
        _playerMovement = playerMovement;
    }

    public override void Execute()
    {
        rb.AddForce(-_playerMovement.sidewaysForce * Time.deltaTime, 0,0, ForceMode.VelocityChange);
    }
}
