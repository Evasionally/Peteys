using System.Collections;
using UnityEngine;
using TMPro;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; private set; }

        protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder, Color textColor, TMP_FontAsset textFont, float delay, AudioClip sound, float delayBetweenLines)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                //SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitUntil(() => Input.GetMouseButton(0));

            finished = true;
        }
    }
}

