using UnityEngine;

public class PlanetBehavior : MonoBehaviour
{
    [SerializeField] float timeScale = 0.0f;
    [SerializeField] GameObject target;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float radius = 10;
    [SerializeField] float angle = 0;
    [SerializeField] bool isRevert = false;

    void EnableTrail()
    {
        GetComponent<TrailRenderer>().enabled = true;
    }

    public void SetTimeScale(float _timeScale)
    {
        timeScale = _timeScale;
    }

    private void Start()
    {
        PlanetManager.Instance.Add(this);
        angle = Random.Range(0f, 359f);
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Sun");
            Debug.Log("Sun found");
        }
    }

    void Update()
    {
        if(target) Move();
        Rotate();
    }

    void Move()
    {
        angle += (Time.deltaTime * rotationSpeed) * timeScale;
        float _poX = target.transform.position.x + Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
        float _poY = target.transform.position.y;
        float _poZ = target.transform.position.z + Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
        transform.position = new Vector3(_poX, _poY, _poZ);
        angle %= 360;
    }

    void Rotate()
    {
        Vector3 _currentRotation = transform.eulerAngles;
        float _rotationSpeed = isRevert ? rotationSpeed : -rotationSpeed;
        _rotationSpeed *= timeScale;
        transform.rotation = Quaternion.Euler(_currentRotation.x, _currentRotation.y + (_rotationSpeed * Time.deltaTime), _currentRotation.z);
    }

    private void OnDestroy()
    {
        PlanetManager.Instance.Remove(this);
    }
    void SetRadius(float _multiplier)
    {
        this.radius *= _multiplier;
    }

    void SetScaleMultiplier(float _multiplier)
    {
        transform.localScale *= _multiplier;
    }

    void SetTrailRenderScale(float _multiplier)
    {
        GetComponent<TrailRenderer>().widthMultiplier *= _multiplier;
    }

    public void UpdateWithMultiplier(float _multiplier)
    {
        SetRadius(_multiplier);
        SetScaleMultiplier(_multiplier);
        SetTrailRenderScale(_multiplier);
        EnableTrail();
    }
}
