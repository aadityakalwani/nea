using System.Collections.Generic;

namespace bobFinal
{
    public class Lesson
    {
        // Properties matching the database schema
        public int LessonId { get; set; }
        public string Topic { get; set; }
        public string Title { get; set; }
        public string Question { get; set; }
        public string ChoiceOne { get; set; }
        public string ChoiceTwo { get; set; }
        public string ChoiceThree { get; set; }
        public string ChoiceFour { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public int Reward { get; set; }
        public bool Completed { get; set; }

        // Constructor (updated to work with fewer parameters)
        public Lesson(int lessonId, string topic, string question, int reward, string choiceOne, string choiceTwo, string choiceThree, string choiceFour)
        {
            LessonId = lessonId;
            Topic = topic;
            Question = question;
            Reward = reward;
            Title = ""; // Default value
            ChoiceOne = choiceOne;
            ChoiceTwo = choiceTwo;
            ChoiceThree = choiceThree;
            ChoiceFour = choiceFour;

            CorrectAnswerIndex = -1; // Default value
            Completed = false; // Default value
        }

        /*
        public Lesson()
        {
            throw new System.NotImplementedException();
        }
        */

        // Marks the lesson as completed
        public void MarkAsCompleted()
        {
            Completed = true;
            DatabaseUtils.MarkLessonComplete(LessonId);
        }

        // Checks if the user's answer is correct
        public bool IsCorrectAnswer(int selectedAnswerIndex)
        {
            return selectedAnswerIndex == CorrectAnswerIndex;
        }
    }
}