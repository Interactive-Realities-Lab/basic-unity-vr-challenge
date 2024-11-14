using UnityEngine;

public class RandomAnimation : MonoBehaviour
{
    Animator animator;
    private float aniOffset;
    void Start()
    {
        animator = GetComponent<Animator>();
        aniOffset = Random.Range(0f, 1f);
        
        animator.Play("Eat",0, aniOffset);
    }
    
}
