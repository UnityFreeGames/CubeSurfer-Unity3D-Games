using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMovementController : MonoBehaviour
{

    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float horizontalLimitValue;

    private float horizontalValue;


    private float newPositionX;


    void FixedUpdate()
    {
        HandleHeroHorizontalInput();
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }

    private void HandleHeroHorizontalInput()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
        {
            horizontalValue = 0;
        }
    }


    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.down * forwardMovementSpeed * Time.fixedDeltaTime);
    }


    private void SetHeroHorizontalMovement()
    {
        newPositionX = transform.position.x + horizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag=="Obstacle")
        {
          Invoke( "rest", 1f);
        }
    }
    void rest()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
