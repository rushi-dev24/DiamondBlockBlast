using UnityEngine;

namespace BlockPuzzle.Services.Save
{
    public sealed class SaveService : MonoBehaviour
    {
        public SaveData Data { get; private set; }

        private void Awake()
        {
            Load();
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(Data);

            PlayerPrefs.SetString(SaveKeys.SaveDataKey, json);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            if (!PlayerPrefs.HasKey(SaveKeys.SaveDataKey))
            {
                CreateNewSave();

                Debug.Log($"Created Save. High Score: {Data.HighScore}");
                return;
            }

            string json = PlayerPrefs.GetString(SaveKeys.SaveDataKey);

            Data = JsonUtility.FromJson<SaveData>(json);

            if (Data == null)
            {
                CreateNewSave();

                Debug.Log($"Recovered Save. High Score: {Data.HighScore}");
                return;
            }

            Debug.Log($"Loaded Save. High Score: {Data.HighScore}");
        }

        public void ResetSave()
        {
            CreateNewSave();
            Save();
        }

        private void CreateNewSave()
        {
            Data = new SaveData();

            Data.HighScore = 998;

            Save();
        }
    }
}