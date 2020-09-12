//  https://gist.github.com/MrSimsek/70a361472a30e93fec74910773115bce
//  https://www.youtube.com/watch?v=5kAbYKXSqj0

using UnityEngine;

public class FPcontroller : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float _sensitivityX = 1f, _sensitivityY = 1f;

    void Update()
    {
        HandleLookX();
        HandleLookY();
    }

    private void HandleLookX()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 rotation = player.transform.localEulerAngles;
        rotation.y += mouseX * _sensitivityX;
        player.transform.localEulerAngles = rotation;
    }

    private void HandleLookY()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = transform.localEulerAngles;
        rotation.x += mouseY * _sensitivityY;
        rotation.x = (rotation.x > 180) ? rotation.x - 360 : rotation.x;
        rotation.x = Mathf.Clamp(rotation.x, -70, 60);
        transform.localEulerAngles = rotation;
    }
}