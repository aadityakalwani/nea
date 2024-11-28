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
        public List<string> Choices { get; set; } // Choices for the lesson question
        public int CorrectAnswerIndex { get; set; }
        public int Reward { get; set; }
        public bool Completed { get; set; }

        // Constructor (updated to work with fewer parameters)
        public Lesson(int lessonId, string topic, string question, int reward)
        {
            LessonId = lessonId;
            Topic = topic;
            Question = question;
            Reward = reward;
            Choices = new List<string>(); // Initialize Choices as empty list
            CorrectAnswerIndex = -1; // Default value
            Completed = false; // Default value
        }

        public Lesson()
        {
            throw new System.NotImplementedException();
        }

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