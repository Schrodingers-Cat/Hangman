using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
	class variables{
		//hold variables in separate class so they can be accessed anywhere
		public static string word="";
		//use stringbuilder so that you can change individual characters in display
		public static StringBuilder display=new StringBuilder();
		public static string guessesTrue = "";
		public static string guessesFalse = "";
	}

	class MainClass
	{
		public static void Main (string[] args)
		{

			Hangman();
		}

		static void Hangman(){
			//introduce game
			Console.WriteLine ("What's your name?");
			string name = Console.ReadLine();
			Console.WriteLine ("Hello, " + name);
			Console.WriteLine ("Guess a letter or the full word. You have 10 tries.");
			//create strings to hold computer's word, string to be displayed, and guessed made
//			string word="";
//			string display="";
//			string guessesTrue = "";
//			string guessesFalse = "";
			int guessesLeft = 10;
			string guess = "";
			List <string> wordList = new List <string> (){"apple", "burrito", "xenophobia", "deoxyribonucleic acid"};
			//initialize word
			Random randpick = new Random();
			variables.word = wordList[randpick.Next (0,3)];
			//initialize display with dashes
			for(int i = 0;i<variables.word.Length;i++){
				variables.display.Append('_');
			}
			//while loop outputs user progress and accepts a new guess
			while (guessesLeft > 0) {
				Console.WriteLine (variables.display);
				Console.WriteLine ("You have "+guessesLeft+" guesses left: ");
				Console.WriteLine ("Letters guessed "+variables.guessesTrue+variables.guessesFalse);
				Console.WriteLine ("Guess a letter or "+variables.word.Length+" digit word");
				guess = Console.ReadLine ();
				//check if you need charguess or wordguess
				if(guess.Length==1){
					//call charguess function
					CharGuess (guess);
				}
				else if(guess.Length>1){
					//call wordguess function
					wordguess (guess);
				}
				//decrement guesses left every time you go through guessing loop
				guessesLeft--;
				//check if guess has caused victory
				if(variables.display.ToString()==variables.word){
					Console.WriteLine ("You win!");
					return;
				}
			}
			//if guessesleft reaches zero, exit loop and lose game
			Console.WriteLine ("You lose!");
		}
		/// <summary>
		/// Updates display string and t/f guess strings
		/// </summary>
		/// <param name="guess">Guessed character.</param>
		static void CharGuess(string guess){
			char guessChar = Convert.ToChar (guess);
			for(int j=0; j<variables.word.Length;j++){
				if(guessChar == variables.word[j]){
					variables.guessesTrue += guessChar;
					variables.display [j] = guessChar;
				}
			}
		}

		/// <summary>
		/// Updates display string and t/f guess strings
		/// </summary>
		/// <param name="guess">Guessed word.</param>
		static void wordguess(string guess){
			if (guess == variables.word) {
				variables.display.Length = 0;
				variables.display.Append(guess);
				}
		}

	}
}
