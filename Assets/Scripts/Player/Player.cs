using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerCollision))]
[RequireComponent(typeof(PlayerFX))]
public class Player : MonoBehaviour
{
    //STATES
    internal bool isTransitioning = false;

    //INTERNAL CACHED REFERENCES
    internal Rigidbody rigidBody;
    internal PlayerMovement playerMovement;
    internal PlayerCollision playerCollision;
    internal PlayerFX playerFX;

    //EXTERNAL CACHED REFERENCES
    SceneLoader sceneLoader;


    //START
    void Start()
    {
        GetCachedReferences();
        CallCustomStarts();
    }

    private void GetCachedReferences()
    {
        rigidBody = GetComponent<Rigidbody>();

        playerMovement = GetComponent<PlayerMovement>();
        playerCollision = GetComponent<PlayerCollision>();
        playerFX = GetComponent<PlayerFX>();

        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void CallCustomStarts()
    {
        playerMovement.CustomStart();
        playerCollision.CustomStart();
        playerFX.CustomStart();
    }


    //SEQUENCES
    public void StartSucessSequence()
    {
        isTransitioning = true;
        playerFX.PlayVictoryEffects();
        sceneLoader.LoadNextSceneWithDelay();
    }

    public void StartDeathSequence()
    {
        isTransitioning = true;
        playerFX.PlayDeathEffects();
        sceneLoader.RestartSceneWithDelay();
    }
}
