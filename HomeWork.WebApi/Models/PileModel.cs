namespace HomeWork.WebApi.Models
{
    public class PileQuestionModel
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }

        public string QuestionDesp { get; set; }
    }

    public class PileAnswerModel
    {
        public int AnswerId { get; set; }

        public string AnswerImageUrl { get; set; }
        public string AnswerName { get; set; }

        public string AnswerDesp { get; set; }

        public int QuestionId { get; set; }
    }
}
