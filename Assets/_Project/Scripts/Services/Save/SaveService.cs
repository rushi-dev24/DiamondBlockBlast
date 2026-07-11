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
                return;
            }

            string json = PlayerPrefs.GetString(SaveKeys.SaveDataKey);

            Data = JsonUtility.FromJson<SaveData>(json);

            if (Data == null)
            {
                CreateNewSave();
                return;
            }
        }

        public void ResetSave()
        {
            CreateNewSave();
            Save();
        }

        private void CreateNewSave()
        {
            Data = new SaveData();

            Save();
        }
    }
}