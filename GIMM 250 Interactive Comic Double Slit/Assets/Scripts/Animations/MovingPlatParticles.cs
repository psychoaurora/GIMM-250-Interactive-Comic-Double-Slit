using UnityEngine;

public class MovingPlatParticles : MonoBehaviour
{
    private ParticleSystem particles;
    private MovingPlatform plat;
    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        plat = transform.GetComponentInParent<MovingPlatform>();
    }

    private void Update()
    {
        if (particles.isPlaying && !plat.isMoving)
            particles.Stop();
        else if (!particles.isPlaying)
            particles.Play();
    }


}