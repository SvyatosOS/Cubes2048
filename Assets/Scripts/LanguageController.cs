using UnityEngine;
using System.IO;
using TMPro;
public class LanguageController : MonoBehaviour
{
    public TextMeshProUGUI play;
    private struct Language
    {
        public string playButtonText;

        public static void SaveToFile(Language languageObject, string filePath)
        {
            File.WriteAllText(filePath, JsonUtility.ToJson(languageObject));
        }

        public static Language LoadFromFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var language = JsonUtility.FromJson<Language>(json);
            return language;
        }
    }
    private void Awake()
    {
        SaveLanguageToFile();
    }

    private void SaveLanguageToFile()
    {
        ////////Russian
        var russian = new Language
        {

            playButtonText = "Играть"
        };

        var russianLanguageFilePath = $"{Application.dataPath}/StreamingAssets/Ru-language.json";
        Language.SaveToFile(russian, russianLanguageFilePath);


        ////////English
        var english = new Language
        {

            playButtonText = "Play"
        };

        var englishLanguageFilePath = $"{Application.dataPath}/StreamingAssets/En-language.json";
        Language.SaveToFile(english, englishLanguageFilePath);
    }

    public void LoadRussianLanguageFromFile()
    {
        var russianLanguageFilePath = $"{Application.dataPath}/StreamingAssets/Ru-language.json";
        var russian = Language.LoadFromFile(russianLanguageFilePath);
        var russianJson = JsonUtility.ToJson(russian);
        var russianLanguageFromJson = JsonUtility.FromJson<Language>(russianJson);

        play.text = russianLanguageFromJson.playButtonText;
    }
    public void LoadEnglishLanguageFromFile()
    {
        var englishLanguageFilePath = $"{Application.dataPath}/StreamingAssets/En-language.json";
        var english = Language.LoadFromFile(englishLanguageFilePath);
        var englishJson = JsonUtility.ToJson(english);
        var englishLanguageFromJson = JsonUtility.FromJson<Language>(englishJson);

        play.text = englishLanguageFromJson.playButtonText;
    }
    
}
