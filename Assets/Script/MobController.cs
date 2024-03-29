using System.Collections;
using UnityEngine;

public class MobController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private Vector2 range;
    private Transform target;
    private readonly float speed = .4f;
    private readonly int m_facingDirection = 1;
    private readonly float m_delayToIdle = 0.0f;
    private bool isAttack = false;
    private Coroutine coroutine;

    private void Start()
    {
        target = GameObject.Find("Warrior").GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Target();
    }

    private void Target()
    {
        if (Vector2.Distance(transform.position, target.position) <= 1.5f && Vector2.Distance(transform.position, target.position) > 1.3f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            animator.SetInteger("AnimState", 1);
        }
        else if (Vector2.Distance(transform.position, target.position) <= 1.3f && Vector2.Distance(transform.position, target.position) > 1.0f)
        {
            rigidbody2D.velocity = Vector2.zero;
            animator.SetInteger("AnimState", 0);
        }
        else if (Vector2.Distance(transform.position, target.position) <= 1.0f && coroutine == null)
        {
            rigidbody2D.velocity = Vector2.zero;
            isAttack = true;
            animator.SetInteger("AnimState", 0);

            animator.SetTrigger("Attack" + Random.Range(1, 3));
            coroutine = StartCoroutine(Delay(5f));
        }
        else if (Vector2.Distance(transform.position, target.position) >= 1.5f)
        {
            rigidbody2D.velocity = Vector2.zero;
            animator.SetInteger("AnimState", 0);
        }
    }

    private IEnumerator Delay(float x)
    {
        yield return new WaitForSeconds(x);
        isAttack = false;
        coroutine = null;
    }
}