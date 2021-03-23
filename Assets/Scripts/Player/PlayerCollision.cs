using UnityEngine;

[DisallowMultipleComponent]
public class PlayerCollision : MonoBehaviour
{
    //STATES
    bool collisionsDisabled = false;

    //CACHED REFERENCES
    Player player;

    //STRING REFERENCES
    const string TAG_FRIENDLY = "Friendly";
    const string TAG_FINISH = "Finish";


    public void CustomStart()
    {
        player = GetComponent<Player>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (player.isTransitioning || collisionsDisabled) { return; } //ignore collision information when dead

        switch (collision.gameObject.tag)
        {
            case TAG_FRIENDLY:
                //do nothing
                break;
            case TAG_FINISH:
                player.StartSucessSequence();
                break;
            default:
                player.StartDeathSequence();
                break;
        }
    }


    public void Disablecollisions() //for debugging purposes
    {
        collisionsDisabled = !collisionsDisabled;
    }
}