using UnityEngine;

public class MobTarget : MonoBehaviour
{
    private readonly Rigidbody2D rigidbody2D;
    private Vector3 target;
    private readonly Animator animator;
    private GameObject rrrr;

    private void OnTriggerStay2D(Collider2D collision)
    {
        rrrr.transform.parent.transform.position = Vector3.MoveTowards(transform.position, target, 0.005f);
    }

    private void Start()
    {
    }

    private void Update()
    {
        target = GameObject.Find("Warrior").transform.position;
    }
}