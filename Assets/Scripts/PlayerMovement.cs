using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRB;

    private void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PCMovement();
    }
    private void PCMovement()
    {
        float X;
        float Y;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) X = -1;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) X = 1;
        else X = 0;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) Y = -1;
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) Y = 1;
        else Y = 0;

        _playerRB.MovePosition(_playerRB.position + new Vector2(X, Y) * 10 * Time.fixedDeltaTime);
    }
}
