using UnityEngine;

public class AttackBoxScript : MonoBehaviour
{
    public AudioClip Hit;
    public AudioClip noHit;
    public AudioSource audioSource;
    public int damage;
    private bool tmp;
    void OnEnable()
    {
        tmp = false;
        if(tmp) audioSource.clip = Hit;
        else audioSource.clip = noHit;
        audioSource.Play();
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Enemy-Back") && tmp == false)
        {
            Debug.Log("back hit");
            tmp = true;
            col.gameObject.transform.parent.GetComponent<BaseEntity>()?.ModifyHealth(-damage);
            return;
        }
        else if(col.gameObject.CompareTag("Enemy"))
            col.gameObject.GetComponent<BasicEnemy>()?.Stun();
    }
}
