using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public ShootingRangeScript shootingRange;
    public GameObject light1;
    public GameObject light2;
    public void HitTarget()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Animator>().SetTrigger("Hit");
        gameObject.GetComponent<AudioSource>().Play();
        light1.SetActive(false);
        light2.SetActive(true);
        shootingRange.HitTargerts();
    }
    public void ReadyTarget()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        light2.SetActive(false);
        light1.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HitTarget();
        }
    }
}
