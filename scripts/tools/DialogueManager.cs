using System.Text.Json;
using Godot;

public static class DialogueManager
{
    public static Dialogue LoadDialogue(string filename, string id)
    {
        string text = FileAccess.GetFileAsString(filename);
        Dialogue result = JsonSerializer.Deserialize<Dialogue>(text);
        return result;
    }
}