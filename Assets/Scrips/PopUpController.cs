using UnityEngine;
using UnityEngine.PlayerLoop;

public class PopUpController : MonoBehaviour
{
    Vector3 popUpOriginalPosition;
    Transform _componentTransform;
    private void Awake()
    {
        _componentTransform = GetComponent<Transform>();
        popUpOriginalPosition = _componentTransform.localPosition;
        _componentTransform.localPosition = new Vector3(_componentTransform.localPosition.x + 800, _componentTransform.localPosition.y, _componentTransform.localPosition.z);
    }
    public void SetOriginalPosition()
    {
        _componentTransform.localPosition = popUpOriginalPosition;
    }
    private void OnDisable()
    {
        PlayerController.OnReachTheEndGame -= SetOriginalPosition;
    }
    private void OnEnable()
    {
        PlayerController.OnReachTheEndGame += SetOriginalPosition;
    }
}
