using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexMovement : MonoBehaviour
{
    public float alexSpeed = 10f;
    private Rigidbody2D alexBody;
    private Animator animator;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        alexBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialogManager = DialogManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        alexBody.rotation = 0;
        alexBody.velocity = new Vector2(dirX * alexSpeed, dirY * alexSpeed);

        if (dirX != 0)
        {
            if (dirX > 0f)
                animator.SetInteger("movement", 2);
            else
                animator.SetInteger("movement", 4);
        }
        else if (dirY != 0)
        {
            if (dirY > 0f)
                animator.SetInteger("movement", 1);
            else
                animator.SetInteger("movement", 3);
        }
        else
        {
            animator.SetInteger("movement", 0);
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
