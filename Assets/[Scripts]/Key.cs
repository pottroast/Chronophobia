using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public DialogueTrigger dt;

    public GameObject exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector2(-100, -100);
            dt.TriggerDialogue();
            exit.SetActive(true);

        }
    }
}
