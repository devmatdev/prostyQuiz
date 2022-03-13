using System;
using System.Collections.Generic;
using System.Text;

namespace MojQuiz
{
    public class Question
    {
        public string QuestionContents { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }
        public int CorrectAnswerScore { get; set; }

    }
}
