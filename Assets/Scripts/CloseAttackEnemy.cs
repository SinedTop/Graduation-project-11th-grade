using UnityEngine;
using System.Collections;

public class CloseAttackEnemy : Enemy
{
    [SerializeField] private float _attackSpeed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == _targetTransform.gameObject)
            StartCoroutine(Attack(_targetTransform.GetComponent<PlayerController>()));
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == _targetTransform.gameObject)
            StopAllCoroutines();
    }
    private IEnumerator Attack(PlayerController _player)
    {
        for(; ; )
        {
            yield return new WaitForSeconds(_attackSpeed);
            _player.TakeHit(_power);
        }
    }
}
