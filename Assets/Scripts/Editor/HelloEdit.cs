using UnityEditor;

[CustomEditor(typeof(HelloPlayMode))]
public class HelloEdit : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Hello Edit Mode");
    }

    public string Speak()
    {
        return "Hello Play Mode";
    }
}
