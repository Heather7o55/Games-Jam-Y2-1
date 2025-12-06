using UnityEngine;

public class AttackBoxScript : MonoBehaviour
{
    public AudioClip Hit;
    public AudioClip noHit;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            PlayerShooting.clip = Hit;
            return;
        }
        else PlayerShooting.clip = noHit;
    }
}
