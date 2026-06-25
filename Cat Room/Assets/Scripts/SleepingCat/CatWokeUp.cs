using UnityEngine;

public class CatWokeUp : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnMouseDown()
    {
        animator.SetBool("ifCatWokeUp", true);
        StartCoroutine(ResetBoolAfterDelay());
    }

    private System.Collections.IEnumerator ResetBoolAfterDelay() //Als je weer klikt speelt de animatie nog een keer
    {
        yield return new WaitForSeconds(4f);
        animator.SetBool("ifCatWokeUp", false);
    }

}
