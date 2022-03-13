using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MojQuiz
{
    public class Quiz
    {
        public List<Question> Questions { get; set; }
        public Quiz()
        {
            LoadQuestionsFromFile("questions.txt");
        }

        private void LoadQuestionsFromFile(string filePath)
        {

            var lines = File.ReadAllLines(filePath);
            
            var counter = 0;
            Questions = new List<Question>();
            var currentQuestion = new Question();
            foreach (var line in lines)
            {
                if (counter == 6)
                {
                    counter = 0;
                }
                if (counter==0)
                {
                    currentQuestion.QuestionContents = line;
                }
                if (counter == 1)
                {
                    currentQuestion.AnswerA = line;
                }
                if (counter == 2)
                {
                    currentQuestion.AnswerB = line;
                }
                if (counter == 3)
                {
                    currentQuestion.AnswerC = line;
                }
                if (counter == 4)
                {
                    currentQuestion.AnswerD = line;
                }
                if (counter == 5)
                {
                    currentQuestion.CorrectAnswer = line[0].ToString();
                    currentQuestion.CorrectAnswerScore = int.Parse(line[1].ToString());

                    var QuestionToSaveInList = new Question()
                    {
                        QuestionContents = currentQuestion.QuestionContents,
                        AnswerA=currentQuestion.AnswerA,
                        AnswerB=currentQuestion.AnswerB,
                        AnswerC=currentQuestion.AnswerC,
                        AnswerD=currentQuestion.AnswerD,
                        CorrectAnswer=currentQuestion.CorrectAnswer,
                        CorrectAnswerScore=currentQuestion.CorrectAnswerScore,
                        
                    };
                    
                    Questions.Add(QuestionToSaveInList);
                }
             
                counter++;
            }

        }
        public void Start()
        {
            var Player = new Player();

            Console.WriteLine("Podaj imię gracza: ");
            Player.PlayerName=Console.ReadLine();
            Player.PlayerScore = 0;
            Player.CurrentQuestion = 1;

            for (int i = 0; i < Questions.Count; i++)
            {
                var score = ShowQuestion(Player.CurrentQuestion);
                Player.PlayerScore += score;
                Player.CurrentQuestion++;
            }
            Console.WriteLine("Twój wynik: "+Player.PlayerScore);
        }
        public int ShowQuestion(int questionCounter)
        {
            var currentQuestionToShow = Questions[questionCounter - 1];
            Console.WriteLine(currentQuestionToShow.QuestionContents);
            Console.WriteLine("A: "+currentQuestionToShow.AnswerA);
            Console.WriteLine("B: " + currentQuestionToShow.AnswerB);
            Console.WriteLine("C: " + currentQuestionToShow.AnswerC);
            Console.WriteLine("D: " + currentQuestionToShow.AnswerD);
            var playerAnswer = Console.ReadLine().ToUpper();
            if(playerAnswer==currentQuestionToShow.CorrectAnswer)
            {
                return currentQuestionToShow.CorrectAnswerScore;
            }
            return 0;
        }
    }
}
