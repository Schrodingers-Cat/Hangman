using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
	class variables{
		//hold variables in separate class for global access
		public static string word="";
		//create stringbuilder to enable modification of individual characters in display
		public static StringBuilder display=new StringBuilder();
		//hold running list of guesses
		public static string guessesTrue = "";
		public static string guessesFalse = "";
		public static int guessesLeft = 10;
	}

	class MainClass
	{
	
		public static void Main (string[] args)
		{
			Hangman();
		}

		/// <summary>
		/// Hangman game that relies on charGuess and wordGuess functions to test if user has correctly guessed word
		/// </summary>
		static void Hangman(){
			//variable to hold guess given by user, taken as input by charGuess and wordGuess
			string guess = "";
			//introduce game to player
			Console.WriteLine ("What's your name?");
			string name = Console.ReadLine();
			Console.WriteLine ("Hello, " + name);
			Console.WriteLine ("Guess a letter or the full word. You have 10 tries.");
	
			//list of potential words
			List <string> wordList = new List <string> (){"apple", "burrito", "xenophobia", "deoxyribonucleic acid", "monster", "technology"};
			//have computer randomaly select word via index
			Random randpick = new Random();
			variables.word = wordList[randpick.Next (0,4)];
			//initialize display with dashes
			for(int i = 0;i<variables.word.Length;i++){
				variables.display.Append('_');
			}
			//while loop outputs user progress and accepts a new guess as long as user still has guesses left
			while (variables.guessesLeft > 0) {
				//output for user
				Console.WriteLine (variables.display);
				Console.WriteLine ("You have "+variables.guessesLeft+" guesses left: ");
				Console.WriteLine ("Letters guessed "+ variables.guessesFalse+variables.guessesTrue);
				Console.WriteLine ("Guess a letter or "+variables.word.Length+" character word");
				//read in new guess
				guess = Console.ReadLine ();

				//check guess length and call either charGuess or wordGuess
				if(guess.Length==1){
					//call charguess function
					CharGuess (guess);
				}
				else if(guess.Length>1){
					//call wordguess function
					wordguess (guess);
				}
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
		/// Updates display string and true and false guess strings after user guesses a character
		/// </summary>
		/// <param name="guess">Character guessed.</param>
		static void CharGuess(string guess){
			//boolean becomes true if char matches one of the letters in the word
			bool istrue=false;
			//guess is read in as a string by Hangman function, covert it to character for comparison
			char guessChar = Convert.ToChar (guess);
			//loop through all characters in computer's chosen word string to test them again user's guess
			for(int j=0; j<variables.word.Length;j++){
				//if a match is found, set bool to true but continue loop in case there are multiple instances of the character
				if (guessChar == variables.word [j]) {
					variables.guessesTrue += guessChar;
					variables.display [j] = guessChar;
					istrue = true;
				} 
			}
			//if no match is ever found after all looping, decrement guesses left and add guess to false list
			if (!istrue) {
				variables.guessesFalse += guessChar;
				variables.guessesLeft--;
			}

		}

		/// <summary>
		/// Updates display string and true and false guess strings for a full word guess
		/// </summary>
		/// <param name="guess">Guessed word</param>
		static void wordguess(string guess){
			//bool becomes true if word is correct
			bool istrue=false;
			//change display to show full word if guess is correct
			if (guess == variables.word) {
				variables.display.Length = 0;
				variables.display.Append (guess);
			} 
			//decrement guesses left and add guess to false list
			if(!istrue){
				variables.guessesFalse += guess;}
				variables.guessesLeft--;
		}
	}
}
