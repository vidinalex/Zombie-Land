using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyInstance : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotateSpeed;
    [SerializeField]
    private float
        _actionDuration,
        _initialMaxForce;
    [SerializeField]
    private int _moneyAmount;
    [SerializeField]
    private Rigidbody _rb;

    private Transform _plTransformPos;
    private const string PLAYER_TAG = "Player";

    private void Start()
    {
        _plTransformPos = Manager.Default.GetPlayerCharacterTransform();

        _rb.AddForce(new Vector3(Random.Range(-_initialMaxForce, _initialMaxForce), _initialMaxForce, Random.Range(-_initialMaxForce, _initialMaxForce)));
    }

    private void Update()
    {
        transform.Rotate(_rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == PLAYER_TAG)
        {
            StartCoroutine(CFlyTowardsPlayer());
        }
    }

    private IEnumerator CFlyTowardsPlayer()
    {
        float timeElapsed = 0;

        while (timeElapsed < _actionDuration)
        {
            transform.position = Vector3.Lerp(transform.position, _plTransformPos.position, timeElapsed / _actionDuration);
            timeElapsed += Time.deltaTime;

            if(Vector3.Distance(transform.position, _plTransformPos.position) < 1f)
            {
                MoneyMenuController.Default.UpdateMoney(_moneyAmount);
                Destroy(gameObject);
            }

            yield return null;
        }

        
    }
}
