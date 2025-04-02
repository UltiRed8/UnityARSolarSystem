using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private Vector3 positionOffset = Vector3.zero;
    [SerializeField] InteractionBehaviour interaction = null;

    private void Start()
    {
        interaction.interactedWithGameObject += (GameObject _object) => SetTarget(_object.transform);
    }

    public void SetTarget(Transform _newTarget)
    {
        target = _newTarget;
    }

    private void Update()
    {
        Vector3 _newPosition = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * movementSpeed);
        transform.position = _newPosition;
    }
}
