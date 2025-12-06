using Godot;
using System;

public partial class Main : Node2D
{
	public override void _Ready()
	{
		DialogueRunner dialogueRunner = GetNode<DialogueRunner>("DialogueRunner");
		dialogueRunner.RunDialogue();
	}

	public void OnNextButtonPressed()
	{
		DialogueRunner dialogueRunner = GetNode<DialogueRunner>("DialogueRunner");
		if (dialogueRunner.HasNext())
		{
			dialogueRunner.NextLine();
		}
	}
}
