using UnityEngine;

[RequireComponent(typeof(Player))] 
public class PlayerMovement : MonoBehaviour
{
    //CONFIG STATS
    [SerializeField] float rotationForce = 160f;
    [SerializeField] float thrustForce = 100f;

    //CACHED REFERENCES
    Player player;

    public void CustomStart()
    {
        player = GetComponent<Player>();
    }

    public void ApplyThrust()
    {
        float thrustSpeed = (thrustForce * 10) * Time.deltaTime;

        player.rigidBody.AddRelativeForce(Vector3.up * thrustSpeed);
        player.playerFX.PlayThrustEffects();
    }

    public void Rotate(int direction)
    {
        float rotationSpeed = rotationForce * Time.deltaTime;

        transform.Rotate((Vector3.forward * direction) * rotationSpeed);
        player.rigidBody.angularVelocity = Vector3.zero;
    }
}