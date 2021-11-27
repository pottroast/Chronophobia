using UnityEngine;

public class EnterDialogueTrigger : MonoBehaviour
{
    public DialogueTrigger dt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector2(-100, -100);
            dt.TriggerDialogue();
        }
    }
}
