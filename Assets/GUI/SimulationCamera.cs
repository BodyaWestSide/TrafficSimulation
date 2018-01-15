using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SimulationCamera : MonoBehaviour
{
    public bool SpectatorMode = true;
    public GameObject menu = null;

    public float InitialSpeed = 10f;
    public float IncreaseSpeed = 1.25f;
    public float CursorSensitivity = 0.025f;

    public KeyCode ForwardButton = KeyCode.W;
    public KeyCode BackwardButton = KeyCode.S;
    public KeyCode RightButton = KeyCode.D;
    public KeyCode LeftButton = KeyCode.A;
    public KeyCode CursorToggleButton = KeyCode.Escape;
    
    private float currentSpeed = 0f;
    private bool moving = false;
    private bool togglePressed = false;
    
    
    private void OnEnable()
    {
        SwitchMode(SpectatorMode);
    }

    private void Update()
    {
        if(SpectatorMode)
        {
            Move();
            Rotate();
        }
        
        CheckToggleMode();
    }

    private void Move()
    {
        var lastMoving = moving;
        var deltaPosition = Vector3.zero;

        if (moving)
            currentSpeed += IncreaseSpeed * Time.deltaTime;

        moving = false;

        CheckMove(ForwardButton, ref deltaPosition, transform.forward);
        CheckMove(BackwardButton, ref deltaPosition, -transform.forward);
        CheckMove(RightButton, ref deltaPosition, transform.right);
        CheckMove(LeftButton, ref deltaPosition, -transform.right);

        if (moving)
        {
            if (moving != lastMoving)
                currentSpeed = InitialSpeed;

            transform.position += deltaPosition * currentSpeed * Time.deltaTime;
        }
        else currentSpeed = 0f;
    }

    private void CheckMove(KeyCode keyCode, ref Vector3 deltaPosition, Vector3 directionVector)
    {
        if (Input.GetKey(keyCode))
        {
            moving = true;
            deltaPosition += directionVector;
        }
    }

    private void Rotate()
    {
        var eulerAngles = transform.eulerAngles;
        eulerAngles.x += -Input.GetAxis("Mouse Y") * 359f * CursorSensitivity;
        eulerAngles.y += Input.GetAxis("Mouse X") * 359f * CursorSensitivity;
        transform.eulerAngles = eulerAngles;
    }

    private void CheckToggleMode()
    {
        if (Input.GetKey(CursorToggleButton))
        {
            if (!togglePressed)
            {
                togglePressed = true;
                SwitchMode(!SpectatorMode);
            }
        }
        else
            togglePressed = false;
    }

    private void SwitchMode(bool isSpectator)
    {
        SpectatorMode = isSpectator;
        
        menu.SetActive(!SpectatorMode);
        Cursor.lockState = SpectatorMode ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !SpectatorMode;
    }
}
