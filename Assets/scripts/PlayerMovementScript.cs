using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;

    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    DialogManager dialogManager; // Reference to the DialogManager script

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        dialogManager = DialogManager.Instance; // Get the DialogManager instance
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        myRigidBody.velocity = moveInput * runSpeed;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1.2f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StudyTable"))
        {
            // Example dialog. Replace this with your actual dialog data.
            Dialog studyDialog = new Dialog();
            studyDialog.Lines.Add("Do you want to study?");
            studyDialog.Lines.Add("This is another line."); // You can add more lines.

            dialogManager.ShowDialog(studyDialog);
            // You might want to pause the game or disable player input here
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("StudyTable"))
        {
            dialogManager.CloseDialog();
            // Resume the game or enable player input here
        }
    }
}
