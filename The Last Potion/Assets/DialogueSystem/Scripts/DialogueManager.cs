using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue, navButtonText;
    public Image speakerSprite;
    public static bool isOpen;

    public int currentIndex;
    public Conversation currentConvo;
    public static DialogueManager instance;
    private Animator anim;
    private Coroutine typing;
    public bool isActive;

    private void Awake()
    {
        isOpen = false;

        if(instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        isActive = false;
    }

    public void Update()
    {
        if (instance.currentIndex > 0)
        {
            if (isOpen && Input.GetKeyDown(KeyCode.E))
            {
                ReadNext();
            }
        }
    }

    public static void StartConversation(Conversation convo)
    {
        instance.isActive = true;

        instance.anim.SetBool("isOpen", true);
        isOpen = true;

        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.navButtonText.text = ">";

        instance.ReadNext();
    }

    public static void StopConversation()
    {
        instance.anim.SetBool("isOpen", false);
        isOpen = false;
    }

    public void ReadNext()
    {
        if(currentIndex > currentConvo.GetLength())
        {
            instance.anim.SetBool("isOpen", false);
            isOpen = false;
            return;
        }

        if(typing == null)
        {
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }
        else
        {
            instance.StopCoroutine(typing);
            typing = null;
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
        }

        speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
        speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
        currentIndex++;

        if(currentIndex > currentConvo.GetLength())
        {
            navButtonText.text = "X";
        }
    }

    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        bool complete = false;
        int index = 0;

        while (!complete)
        {
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(0.02f);

            if(index == text.Length)
            {
                complete = true;
            }
        }
        typing = null;
    }  
}
