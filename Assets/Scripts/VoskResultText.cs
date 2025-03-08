using UnityEngine;
using UnityEngine.UI;

public class VoskResultText : MonoBehaviour 
{
    public VoskSpeechToText VoskSpeechToText;
    public Text ResultText;

    void Awake()
    {
        VoskSpeechToText.OnTranscriptionResult += OnTranscriptionResult;
    }

    private void OnTranscriptionResult(string obj)
    {
        Debug.Log(obj);
        var result = new RecognitionResult(obj);

        RecognizedPhrase mostConfidence = null;
        float confidence = -1f;
        
        for (int i = 0; i < result.Phrases.Length; i++)
        {
            if (result.Phrases[i].Confidence > confidence)
            {
                confidence = result.Phrases[i].Confidence;
                mostConfidence = result.Phrases[i];
            }
            
            // if (i > 0)
            // {
            //     ResultText.text += ", ";
            // }

            // ResultText.text += result.Phrases[i].Text;
        }

        if (mostConfidence == null || string.IsNullOrEmpty(mostConfidence.Text))
            return;
        
        ResultText.text += mostConfidence.Text;
        ResultText.text += "\n";return;

    }
}
