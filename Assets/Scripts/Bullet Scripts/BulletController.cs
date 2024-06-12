using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [HideInInspector]
    public int damage;

    private float speed = 60f;

    private WaitForSeconds wait_For_Time_Alive = new WaitForSeconds(2f);

    private IEnumerator coroutineDeactivate;

    private Vector3 direction;

    public GameObject rocket_Explosion;

    void Start()
    {
        if(this.tag == TagManager.ROCKET_MISSILE__TAG)
        {
            speed = 8f;
        }
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        coroutineDeactivate = WaitForDeactivate();
        StartCoroutine(coroutineDeactivate);
    }

    private void OnDisable()
    {
        if (coroutineDeactivate != null)
        {
            StopCoroutine(coroutineDeactivate);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    IEnumerator WaitForDeactivate()
    {
        yield return wait_For_Time_Alive;
        gameObject.SetActive(false);
    }

} // class
