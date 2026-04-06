using UnityEngine;

public class Scene2_DoorScript : MonoBehaviour
{
    
    public bool CanOpen = false;
    [SerializeField]
    AudioClip soundOpen, soundDenied;
    private AudioSource MyAudioSource;

    [SerializeField]
    GameObject endPoint;

    private void Awake()
    {
        MyAudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && CanOpen)
        {
                    GetComponent<Animator>().enabled = true;
                    MyAudioSource.PlayOneShot(soundOpen);
                    endPoint.SetActive(true);
        }
        else
        {
            MyAudioSource.PlayOneShot(soundDenied);
        }
    }
     

}
