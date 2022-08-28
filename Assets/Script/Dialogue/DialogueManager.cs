using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public string Next;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue) //��ȭ ����
    {
        sentences.Clear(); //���� ��ȭ ����

        nameText.text = dialogue.name; //ȭ��

        foreach (string sentence in dialogue.sentences) //ť�� ������ �� ���徿 �־���.
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(); //sentences�� ��� ������ �� ���ھ� ���
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        FindObjectOfType<Fade>().Move_Scene(Next);//AirConditional
    }


    // Update is called once per frame
    void Update()
    {

    }
}
