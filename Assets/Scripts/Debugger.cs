using UnityEngine;

public class Debugger : MonoBehaviour
{
    Player player;
    PlayerCollision playerCollision;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Debug.isDebugBuild)
        {
            RespondToDebugKeys();
        }
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            player.StartSucessSequence();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            player.playerCollision.Disablecollisions();
            Debug.Log("Are collisions disabled? " + player.playerCollision.collisionsDisabled);
        }
    }
}
