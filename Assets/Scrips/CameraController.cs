using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject objetive;
    public float minXPosition;
    public float maxXPosition;
    public float minYPosition;
    public float maxYPosition;
    void Update()
    {
        if (objetive != null)
        {
            float positionX = Mathf.Clamp(objetive.transform.position.x, minXPosition, maxXPosition);
            float positionY = Mathf.Clamp(objetive.transform.position.y, minYPosition, maxYPosition);
            transform.position = new Vector3(positionX, positionY, -10);
        }
    }
}
