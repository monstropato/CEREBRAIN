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

    void Update()
    {
        if (!player.isTransitioning)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    //Manage Inputs
    private void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();
        }
        else
        {
            player.playerFX.StopThrustEffects();
        }
    }

    private void ApplyThrust()
    {
        float thrustSpeed = (thrustForce * 10) * Time.deltaTime;

        player.rigidBody.AddRelativeForce(Vector3.up * thrustSpeed);
        player.playerFX.PlayThrustEffects();
    }

    private void RespondToRotateInput()
    {
        float rotationSpeed = rotationForce * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
            player.rigidBody.angularVelocity = Vector3.zero;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
            player.rigidBody.angularVelocity = Vector3.zero;
        }
    }
}