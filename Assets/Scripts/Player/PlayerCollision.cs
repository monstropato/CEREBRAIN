using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //CACHED REFERENCES
    Player player;

    public void CustomStart()
    {
        player = GetComponent<Player>();
    }
}