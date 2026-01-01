using UnityEngine;

public class StopMusicOnJointBreak : MonoBehaviour
{
    [Header("Background Music")]
    public AudioSource backgroundMusic;

    FixedJoint2D joint;
    bool musicStopped = false;

    void Start()
    {
        joint = GetComponent<FixedJoint2D>();

        if (joint == null)
            Debug.LogWarning("No FixedJoint2D found on " + gameObject.name);
    }

    void Update()
    {
        if (musicStopped) return;

        // Joint has been broken or destroyed
        if (joint == null)
        {
            if (backgroundMusic != null && backgroundMusic.isPlaying)
            {
                backgroundMusic.Stop();
                Debug.Log("Joint gone → Background music stopped");
            }

            musicStopped = true;
        }
    }
}
