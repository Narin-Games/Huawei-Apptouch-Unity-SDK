using UnityEngine;

namespace Sana.Apptouch {
    public abstract class AbstractManager : MonoBehaviour {
        private static GameObject _apptouchGameObject;
        private static MonoBehaviour _apptouchGameObjectMonobehaviourRef;

        private const string ApptouchObjectName = "ApptouchSDK";

        public static GameObject getApptouchManagerGameObject() {
            if (_apptouchGameObject != null)
                return _apptouchGameObject;

            _apptouchGameObject = GameObject.Find(ApptouchObjectName);
            if (_apptouchGameObject == null) {
                _apptouchGameObject = new GameObject(ApptouchObjectName);
                DontDestroyOnLoad(_apptouchGameObject);
            }

            return _apptouchGameObject;
        }

        public static void Initialize(System.Type type) {
            try {
                if ((FindObjectOfType(type) as MonoBehaviour) != null)
                    return;

                GameObject managerGameObject = getApptouchManagerGameObject();
                GameObject gameObject = new GameObject(type.ToString());
                gameObject.AddComponent(type);
                gameObject.transform.parent = managerGameObject.transform;
            }
            catch (UnityException ex) {
                string str1 = "It looks like you have the " + type + " on a GameObject in your scene. Our prefab-less manager system does not require the " + type
                    + " to be on a GameObject.\nIt will be added to your scene at runtime automatically for you. Please remove the script from your scene." + ex;

                Debug.LogWarning(str1);
            }
        }

        private void Awake() {
            gameObject.name = GetType().ToString();
            DontDestroyOnLoad(this);
        }
    }
}