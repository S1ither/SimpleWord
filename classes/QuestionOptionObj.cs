using System.Collections.Generic;

namespace CPPK.NET
{
    class QuestionOptionObj
    {
        private string answerTag;

        private string correctTag;

        private string incorrectTag;

        private List<string> incorrectTagNo = new List<string>();

        private List<string> correctTagNo = new List<string>();

        private Description descriptionTag = new Description();

        public string AnswerTag
        {
            get
            {
                return answerTag;
            }
            set
            {
                answerTag = value;
            }
        }

        public string CorrectTag
        {
            get
            {
                return correctTag;
            }
            set
            {
                correctTag = value;
            }
        }

        public string IncorrectTag
        {
            get
            {
                return incorrectTag;
            }
            set
            {
                incorrectTag = value;
            }
        }

        public List<string> IncorrectTagNo
        {
            get
            {
                return incorrectTagNo;
            }
            set
            {
                incorrectTagNo = value;
            }
        }

        public List<string> CorrectTagNo
        {
            get
            {
                return correctTagNo;
            }
            set
            {
                correctTagNo = value;
            }
        }

        public Description DescriptionTag
        {
            get
            {
                return descriptionTag;
            }
            set
            {
                descriptionTag = value;
            }
        }
    }

    class Description
    {
        private string open;

        private string close;

        public string Open
        {
            get
            {
                return open;
            }
            set
            {
                open = value;
            }
        }

        public string Close
        {
            get
            {
                return close;
            }
            set
            {
                close = value;
            }
        }
    }
}
