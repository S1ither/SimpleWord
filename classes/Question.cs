using System.Collections.Generic;

namespace CPPK.NET
{
    class Question
    {
        private string questionName;

        private List<string> answerNo = new List<string>();

        private List<string> descriptionNo = new List<string>();

        public string QuestionName
        {
            get
            {
                return questionName;
            }
            set
            {
                questionName = value;
            }
        }

        public List<string> AnswerNo
        {
            get
            {
                return answerNo;
            }
            set
            {
                answerNo = value;
            }
        }

        public List<string> DescriptionNo
        {
            get
            {
                return descriptionNo;
            }
            set
            {
                descriptionNo = value;
            }
        }
    }
}
