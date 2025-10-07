using System;
using System.IO;

namespace FileOperation { 
public class TextFileProcessor
{
	private readonly string _filePath;
	private readonly LogFileWriter _logger;

	public TextFileProcessor(string filePath, LogFileWriter logger)
	{
		_filePath = filePath;
		_logger = logger;
	}

	public void CountContents()
	{
		try
		{
			string text = File.ReadAllText(_filePath);
			int lineCount = File.ReadAllLines(_filePath).Length;
			int wordCount = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
			int charCount = text.Length;

			Console.WriteLine("Line Count: " + lineCount);
			Console.WriteLine("Word Count: " + wordCount);
			Console.WriteLine("Character Count: " + charCount);

			_logger.Log("Counted contents of file: " + _filePath);
		}
		catch (Exception ex)
		{
			_logger.Log("Error in CountContents: " + ex.Message);
		}
	}

	public void CreateBackup()
	{
		try
		{
			string backupPath = _filePath + ".bak";
			File.Copy(_filePath, backupPath, true);
			Console.WriteLine($"Backup created at: {backupPath}");

			_logger.Log("Backup created for file: " + _filePath);
		}
		catch (Exception ex)
		{
			_logger.Log("Error in CreateBackup: " + ex.Message);
		}
	}

	public void SearchText(string searchText)
	{
		try
		{
			string[] lines = File.ReadAllLines(_filePath);
			int foundCount = 0;

			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].Contains(searchText, StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine($"Line {i + 1}: {lines[i]}");
					foundCount++;
				}
			}

			if (foundCount == 0)
			{
				Console.WriteLine("No matches found.");
			}

			_logger.Log($"Searched for '{searchText}' in file: {_filePath}  Found {foundCount} times.");
		}
		catch (Exception ex)
		{
			_logger.Log("Error in textserch " + ex.Message);
		}
	}
}
	}