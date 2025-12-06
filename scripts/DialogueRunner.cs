using Godot;
using System;
using Godot.Collections;

[GlobalClass]
public partial class DialogueRunner : Node
{
	[Export(PropertyHint.File, "*.json")]
	public string DialogueFile;

	[Export]
	public string DialogueId;

	[Export]
	public Array<DialogueSpeaker> speakers = new();

	private Dictionary<string, DialogueSpeaker> _speakerMap = new();

	private Dialogue _dialogue;
	private int _currentLineIndex = 0;

	public override void _Ready()
	{
		_dialogue = DialogueManager.LoadDialogue(DialogueFile, DialogueId);
		GD.Print($"Loaded dialogue: {_dialogue.Id} with {_dialogue.Lines.Length} lines.");
		MapSpeakers();
	}

	public void RunDialogue()
	{
		DialogueLine line = _dialogue.Lines[0];
		SetLine(line);
	}

	public void NextLine()
	{
		if (HasNext())
		{
			DialogueLine line = _dialogue.Lines[_currentLineIndex];
			SetLine(line);
		}
		else
		{
		   throw new InvalidOperationException("No more lines in dialogue.");
		}
		_currentLineIndex++;
	}

	public bool HasNext()
	{
		GD.Print($"Checking HasNext: {_currentLineIndex} < {_dialogue.Lines.Length - 1}");
		return _currentLineIndex + 1 < _dialogue.Lines.Length;
	}

	private void SetLine(DialogueLine line)
	{
		GD.Print($"Setting line: {line.Speaker}: {line.Text}");
		if (_speakerMap.TryGetValue(line.Speaker, out DialogueSpeaker speaker))
		{
			speaker.SetLine(line.Text);
		}
	}

	private void MapSpeakers()
	{
		foreach (DialogueSpeaker speaker in speakers)
		{
			_speakerMap[speaker.Speaker] = speaker;
		}
		GD.Print($"Mapped {_speakerMap.Count} speakers.");
		GD.Print($"Speakers: {string.Join(", ", _speakerMap.Keys)}");
	}
}
