using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    //CACHED REFERENCES
    Player player;

    public void CustomStart()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (player.isTransitioning) { return; }

        RespondToThrustInput();
        RespondToRotateInput();
    }

    //Manage Inputs
    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            player.playerMovement.ApplyThrust();
        }
        else
        {
            player.playerFX.StopThrustEffects();
        }
    }

    private void RespondToRotateInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.playerMovement.Rotate(1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.playerMovement.Rotate(-1);
        }
    }
}