using UnityEngine;

public class SlideableObject : MonoBehaviour, ISlidingObjects
{
    private Rigidbody _rb;

    [SerializeField] private float slideMultiplier = 1f;
    [SerializeField] private int coinsNumber = 10;

    //private Transform _trayTransform;
    //private Accelerometer_Control _control;
    [SerializeField] private float _bufferDistanceBetweenTray = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //_rb = GetComponent<Rigidbody>();

        //GameObject tray = GameObject.FindGameObjectWithTag("Tray");
        //if (tray != null)
        //{
        //    _trayTransform = tray.transform;
        //}

    }

    private void FixedUpdate()
    {
        //if (_control == null) return;

        //// Match plate movement (base velocity)
        //Vector3 stickVelocity = _control.TrayVelocity;

        //// Add sliding reaction
        //Vector3 slideForce = -stickVelocity * slideMultiplier;
        //_rb.AddForce(slideForce, ForceMode.VelocityChange);

        //// Prevent from falling below plate
        //Vector3 pos = transform.position;
        //float trayY = _trayTransform.position.y;

        //if (pos.y < trayY + _bufferDistanceBetweenTray)
        //{
        //    pos.y = trayY + _bufferDistanceBetweenTray;
        //    transform.position = pos;

        //    if (_rb.linearVelocity.y < 0)
        //    {
        //        _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z);
        //    }
        //}

        //Quaternion targetRotation = Quaternion.LookRotation(_trayTransform.forward, _trayTransform.up);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f); // 10f = smoothing speed
    }

    public void OnPlayerMove(Vector3 velocityApply)
    {
        //Vector3 slideForce = velocityApply * slideMultiplier;
        //_rb.AddForce(slideForce, ForceMode.Acceleration);
    }

    public int GetCoinsNumber()
    {
        return coinsNumber;
    }

    public Vector3 AdjustVelocityToSlope(Vector3 velocity)
    {
        //var ray = new Ray(transform.position, Vector3.down);

        //if (Physics.Raycast(ray, out RaycastHit hitInfo, 0.2f))
        //{
        //    var slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        //    var adjustedVelocity = slopeRotation * velocity;

        //    if (adjustedVelocity.y < 0)
        //    {
        //        return adjustedVelocity;
        //    }
        //}

        return velocity;
    }

}