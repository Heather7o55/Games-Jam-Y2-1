using UnityEngine;

public class AttackBoxScript : MonoBehaviour
{
    public AudioClip Hit;
    public AudioClip noHit;
    public AudioSource audioSource;
    private bool tmp;
    void OnEnable()
    {
        tmp = false;
        if(tmp) audioSource.clip = Hit;
        else audioSource.clip = noHit;
        audioSource.Play();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            tmp = true;
            return;
        }
    }
}
