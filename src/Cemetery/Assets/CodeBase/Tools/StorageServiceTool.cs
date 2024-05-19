using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Tools
{
    public class StorageServiceTool : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake() => 
            button.onClick.AddListener(ClearPlayerPrefs);

        private void OnDestroy() => 
            button.onClick.RemoveListener(ClearPlayerPrefs);

        private void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}
