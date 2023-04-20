using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;

        [Header ("Text Options")]
        [SerializeField]
        private string input;
        [SerializeField]
        private Color textColor;
        [SerializeField]
        private TMP_FontAsset textFont;
        [SerializeField]
        private float delay;
        [SerializeField]
        private float delayBetweenLines;

        [SerializeField]
        private AudioClip sound;

        [SerializeField]
        private Sprite characterSprite;
        [SerializeField]
        private Image imageHolder;


        private void Awake()
        {
            textHolder = GetComponent<TextMeshProUGUI>();
            textHolder.text = "";

            //imageHolder.sprite = characterSprite;
            //imageHolder.preserveAspect = true;
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines));
        }
    }
}