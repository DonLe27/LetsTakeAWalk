// References: https://www.youtube.com/watch?v=blO039OzUZc&ab_channel=Holistic3d
using UnityEngine;

public class CamMouseLook : MonoBehaviour
{
    public Vector2 mouseLook; // Current mouse spherical coordinate
    public Vector2 smoothV;
    public float sensitivity = 1;
    public float smoothing;

    public GameObject character;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Wait until player instantiates camera and sets character
        if (character == null) return;
        Vector2 vct2 = new Vector2(Input.GetAxis("Mouse X") * sensitivity, Input.GetAxis("Mouse Y") * sensitivity); //The delta or change in coordinates
        smoothV.x = Mathf.Lerp(smoothV.x, vct2.x, 1 / smoothing); // Interpolate 
        smoothV.y = Mathf.Lerp(smoothV.y, vct2.y, 1 / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right); // TODO: Have the heads rotate
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up); // Rotate the character
    }
}