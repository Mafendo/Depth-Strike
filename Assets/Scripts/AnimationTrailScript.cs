using System.Collections;
using UnityEngine;

public class AnimationTrailScript : MonoBehaviour
{
    [SerializeField] GameObject trailSprite;
    private float trailWidth;
    private void Awake()
    {
        trailWidth = trailSprite.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void OnEnable()
    {
        Vector3 startPos = transform.position;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.SetActive(true);

            // Offset behind the bullet
            child.position = startPos + Vector3.left * trailWidth * i;

            // Reset animator with delay
            Animator anim = child.GetComponent<Animator>();
            if (anim != null)
            {
                float delay = i * 0.1f; // 0.1 sec delay per segment
                StartCoroutine(PlayAnimDelayed(anim, delay));
            }
        }
    }

    private IEnumerator PlayAnimDelayed(Animator anim, float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.Play(anim.GetCurrentAnimatorStateInfo(0).shortNameHash, -1, 0f);
    }


}

