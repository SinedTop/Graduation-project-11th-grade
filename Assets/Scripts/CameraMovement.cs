using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
         gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(_target.position.x, _target.position.y, -10), 0.25f);
    }
}
