using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Player))]
public class PlayerFX : MonoBehaviour
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

    //CACHED REFERENCES
    Player player;
    AudioSource audioSource;

    public void CustomStart()
    {
        player = GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
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

    public void StopThrustEffects()
    {
        audioSource.Stop();
        mainEngineParticle.Stop();
    }

    public void PlayVictoryEffects()
    {
        StopThrustEffects();
        audioSource.PlayOneShot(victorySound);
        victoryParticle.Play();
    }

    public void PlayDeathEffects()
    {
        StopThrustEffects();
        audioSource.PlayOneShot(deathSound, 3f);
        deathParticle.Play();
    }
}