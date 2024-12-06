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

        public Lesson(
            int lessonId, string topic, string title, string question,
            int correctAnswerIndex, int reward,
            string choiceOne, string choiceTwo, string choiceThree, string choiceFour,
            bool completed)
        {
            LessonId = lessonId;
            Topic = topic;
            Title = title;
            Question = question;
            CorrectAnswerIndex = correctAnswerIndex;
            Reward = reward;
            ChoiceOne = choiceOne;
            ChoiceTwo = choiceTwo;
            ChoiceThree = choiceThree;
            ChoiceFour = choiceFour;
            Completed = completed;
        }

        public Lesson() { }

        public void MarkAsCompleted()
        {
            Completed = true;
            DatabaseUtils.MarkLessonComplete(LessonId);
        }

        public bool IsCorrectAnswer(int selectedAnswerIndex)
        {
            return selectedAnswerIndex == CorrectAnswerIndex;
        }
    }
}