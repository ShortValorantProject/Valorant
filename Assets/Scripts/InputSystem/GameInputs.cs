using UnityEngine;

public class GameInputs : MonoBehaviour
{
    public static GameInputs Instance {get; private set;}
    public InputSystem_Actions inputActions {get; private set;}

    void Awake()
    {
        Instance = this;
        inputActions = new InputSystem_Actions();
        ActivateInputs();
    }

    void Start()
    {
        
    }

    #region Input Actions Properties 
    public Vector2 MoveVector => inputActions.Player.Move.ReadValue<Vector2>();
    public Vector2 LookVector => inputActions.Player.Look.ReadValue<Vector2>();

    public bool AttackButtonPressed => inputActions.Player.Attack.WasPressedThisFrame();

    public bool InteractButtonPressed => inputActions.Player.Interact.WasPressedThisFrame();

    #endregion


    #region Controller 
    public void ActivateInputs()
    {
        inputActions.Enable();
    }

    public void DeactivateInputs()
    {
        inputActions.Disable();
    }

    public void ActivateUIInputs()
    {
        inputActions.UI.Enable();
    }

    public void DeactivateUIInputs()
    {
        inputActions.UI.Disable();
    }

    public void ActivatePlayerInputs()
    {
        inputActions.Player.Enable();
    }

    public void DeactivatePlayerInputs()
    {
        inputActions.Player.Disable();
    }
    #endregion
}
