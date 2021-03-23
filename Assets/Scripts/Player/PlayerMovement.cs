using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //CACHED REFERENCES
    Player player;

    public void CustomStart()
    {
        player = GetComponent<Player>();
    }
}