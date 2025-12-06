using Godot;
using System;

[GlobalClass]
public partial class DialogueSpeaker : Label
{
	[Export]
	public string Speaker;

	private string CurrentLine;

	public void SetLine(string line)
	{
		CurrentLine = line;
		Text = $"{Speaker}: {CurrentLine}";
	}
}
