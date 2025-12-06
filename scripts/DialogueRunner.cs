using Godot;
using System;

[GlobalClass]
public partial class DialogueRunner : Node
{
	[Export(PropertyHint.File, "*.json")]
	public string DialogueFile;

	[Export]
	public string DialogueId;

	private Dialogue _dialogue;

	public override void _Ready()
	{
		_dialogue = DialogueManager.LoadDialogue(DialogueFile, DialogueId);
	}
}
