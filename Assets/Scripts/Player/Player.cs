using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    //CONFIG PARAMS
    [Header("Sounds")]
    [SerializeField] AudioClip mainEngineSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip victorySound;
    [Header("Particles")]
    [SerializeField] ParticleSystem mainEngineParticle;
    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem victoryParticle;

    //STATES
    internal bool isTransitioning = false;

    //INTERNAL CACHED REFERENCES
    internal Rigidbody rigidBody;
    internal AudioSource audioSource;
    PlayerInput playerInput;
    PlayerMovement playerMovement;
    PlayerCollision playerCollision;

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
        audioSource = GetComponent<AudioSource>();

        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCollision = GetComponent<PlayerCollision>();

        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void CallCustomStarts()
    {
        playerInput.CustomStart();
        playerMovement.CustomStart();
        playerCollision.CustomStart();
    }


    public void StartSucessSequence()
    {
        isTransitioning = true;
        StopMainEngine();
        audioSource.PlayOneShot(victorySound);
        victoryParticle.Play();
        sceneLoader.LoadNextSceneWithDelay();
    }

    public void StartDeathSequence()
    {
        isTransitioning = true;
        StopMainEngine();
        audioSource.PlayOneShot(deathSound, 3f);
        deathParticle.Play();
        sceneLoader.RestartSceneWithDelay();
    }

    public void StopMainEngine()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }
    public void PlayThrustEffects()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSound);
        }
        if (!mainEngineParticle.isPlaying)
        {
            mainEngineParticle.Play();
        }
    }
}
