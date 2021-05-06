using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CPPK.NET
{
    class StringConverter
    {
        private List<Question> questionNo = new List<Question>();

        private string data;

        private QuestionOptionObj questionOptionObj = new QuestionOptionObj();

        private string curs;

        private string theme;

        private List<Question> QuestionNo
        {
            get
            {
                return questionNo;
            }
            set
            {
                questionNo = value;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public QuestionOptionObj QuestionOptionObj
        {
            get
            {
                return questionOptionObj;
            }
            set
            {
                questionOptionObj = value;
            }
        }

        public string Curs
        {
            get
            {
                return curs;
            }
            set
            {
                curs = value;
            }
        }

        public string Theme
        {
            get
            {
                return theme;
            }
            set
            {
                theme = value;
            }
        }

        public void parseDocToQuestion()
        {
            List<string> tempNo = new List<string>();
            int i = 0;
            Regex regex =
                new Regex(@"^\d+.",
                    RegexOptions.IgnoreCase | RegexOptions.Multiline);
            foreach (string row in Data.Split("\n"))
            {
                if (regex.IsMatch(row))
                {
                    if (tempNo.ToArray().Length - 1 > 1)
                    {
                        Question question = new Question();
                        question.QuestionName = tempNo[0];
                        tempNo.Remove(question.QuestionName);
                        foreach (string answer in tempNo)
                        {
                            if (answer.StartsWith("="))
                                question
                                    .AnswerNo
                                    .Add(i > 1
                                        ? QuestionOptionObj.IncorrectTag +
                                        "%" +
                                        100 / i +
                                        "%[moodle]" +
                                        answer.Substring(1)
                                        : answer);
                            else
                                question.AnswerNo.Add(answer);
                        }
                        QuestionNo.Add (question);
                        tempNo = new List<string>();
                        i = 0;
                    }
                    tempNo.Add(row.Substring(regex.Match(row).Value.Length));
                }
                foreach (string incorrectTag in QuestionOptionObj.IncorrectTagNo
                )
                {
                    if (row.StartsWith(incorrectTag))
                        tempNo
                            .Add(QuestionOptionObj.IncorrectTag +
                            row.Substring(1));
                }
                foreach (string correctTag in QuestionOptionObj.CorrectTagNo)
                {
                    if (row.StartsWith(correctTag))
                    {
                        tempNo
                            .Add(QuestionOptionObj.CorrectTag +
                            row.Substring(1));
                        i++;
                    }
                }
            }
        }

        private void prepareRawDataToQuestion(Boolean isMoodle = false)
        {
            if (Data.Split("\n")[0].Split("\t").Length < 2)
            {
                parseDocToQuestion();
                return;
            }
            List<string> rowNo = new List<string>();
            string[] _ = Data.Split("\n");
            Regex regexNewQuestion = new Regex(@"(?:\.|\d)\t");
            foreach (string row in _)
            {
                if (row.Length > 1)
                {
                    if (
                        regexNewQuestion.IsMatch(row) &&
                        rowNo.ToArray().Length > 2
                    )
                    {
                        Question question =
                            new Question { QuestionName = rowNo[1] };
                        rowNo.RemoveAt(1);
                        rowNo.RemoveAt(0);
                        string[] copyRowNo = rowNo.ToArray();

                        int countCorrectAnswer = 0;
                        foreach (string rowAnswer in copyRowNo)
                        {
                            foreach (string
                                _correctTag
                                in
                                QuestionOptionObj.CorrectTagNo
                            )
                            {
                                if (rowAnswer.StartsWith(_correctTag))
                                {
                                    question
                                        .AnswerNo
                                        .Add(QuestionOptionObj.CorrectTag +
                                        rowAnswer.Substring(1));
                                    countCorrectAnswer++;
                                    rowNo.RemoveAt(0);
                                }
                            }
                            foreach (string
                                _incorrectTag
                                in
                                QuestionOptionObj.IncorrectTagNo
                            )
                            {
                                if (rowAnswer.StartsWith(_incorrectTag))
                                {
                                    question
                                        .AnswerNo
                                        .Add(QuestionOptionObj.IncorrectTag +
                                        rowAnswer.Substring(1));
                                    rowNo.RemoveAt(0);
                                }
                            }
                        }
                        copyRowNo = null;
                        if (isMoodle)
                        {
                            string[] answers = question.AnswerNo.ToArray();
                            if (countCorrectAnswer > 1)
                                for (int i = 0; i < answers.Length; i++)
                                {
                                    answers[i] =
                                        questionOptionObj.IncorrectTag +
                                        (
                                        answers[i].Substring(0, 1) ==
                                        QuestionOptionObj.CorrectTag
                                            ? "%" +
                                            (100 / countCorrectAnswer) +
                                            "%[moodle]"
                                            : ""
                                        ) +
                                        answers[i].Substring(1);
                                }
                            question.AnswerNo = new List<string>();
                            question.AnswerNo.AddRange (answers);
                        }

                        foreach (string rowDescription in rowNo)
                        {
                            if (rowDescription.Length > 2)
                                question.DescriptionNo.Add(rowDescription);
                        }

                        rowNo = new List<string>();
                        rowNo = row.Split("\t").ToList();
                        QuestionNo.Add (question);
                    }
                    else
                        rowNo.AddRange(row.Split("\t"));
                }
            }
        }

        public string textToString(Boolean isMoodleTxt = false)
        {
            prepareRawDataToQuestion (isMoodleTxt);
            string file = "";
            foreach (Question question in QuestionNo)
            {
                file +=
                    "\n" +
                    questionOptionObj.AnswerTag +
                    question.QuestionName +
                    (isMoodleTxt ? "{" : "") +
                    "\n";
                foreach (string answer in question.AnswerNo)
                {
                    file += answer + "\n";
                }
                if (question.DescriptionNo.ToArray().Length > 0)
                {
                    if (isMoodleTxt)
                        file += "####";
                    else
                        file += questionOptionObj.DescriptionTag.Open;
                    foreach (string description in question.DescriptionNo)
                    {
                        file += description + "\n";
                    }
                    if (!isMoodleTxt)
                        file += questionOptionObj.DescriptionTag.Close + "\n";
                }
                if (isMoodleTxt)
                    file += "}\n";
                else
                    file += "#";
            }
            if (isMoodleTxt)
                file = "$" + curs + "\n|" + theme + file;
            else
                file = "$" + curs + "\n|" + theme + file + "^\n{\n}";
            QuestionNo = new List<Question>();
            return file;
        }

        public string textToXml()
        {
            prepareRawDataToQuestion();
            string file =
                "<my:curs>" +
                curs +
                "</my:curs><my:temicursov><my:temacursa><my:tktext>" +
                theme +
                "</my:tktext><my:questions>";
            foreach (Question question in QuestionNo)
            {
                file +=
                    "<my:question><my:qtext>" +
                    "<div style=\"FONT-FAMILY: Microsoft Sans Serif\" align=\"center\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><strong>" +
                    question.QuestionName +
                    "</strong></div></my:qtext>";
                foreach (string answer in question.AnswerNo)
                {
                    if (answer.StartsWith("~"))
                        file +=
                            "<my:answer><my:astatus>Неправильный ответ</my:astatus><my:atext>" +
                            answer.Substring(1) +
                            "</my:atext></my:answer>";
                    else
                        file +=
                            "<my:answer><my:astatus>Правильный ответ</my:astatus><my:atext>" +
                            answer.Substring(1) +
                            "</my:atext></my:answer>";
                }
                file +=
                    "<my:qhelp><div xmlns=\"http://www.w3.org/1999/xhtml\">";
                foreach (string description in question.DescriptionNo)
                {
                    file += "<div>" + description + "</div>";
                }
                file += "</div></my:qhelp></my:question>";
            }

            file =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<?mso-infoPathSolution solutionVersion=\"1.0.0.76\" name=\"urn:schemas-microsoft-com:office:infopath:OlimpCourse:-myXSD-2005-09-12T06-50-44\" productVersion=\"14.0.0\" PIVersion=\"1.0.0.0\" ?>" +
                "<?mso-application progid=\"InfoPath.Document\"?><my:field xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xhtml=\"http://www.w3.org/1999/xhtml\" xmlns:my=\"http://schemas.microsoft.com/office/infopath/2003/myXSD/2005-09-12T06:50:44\" xmlns:xd=\"http://schemas.microsoft.com/office/infopath/2003\" xml:lang=\"ru\"><my:group></my:group>" +
                file +
                "</my:questions><my:tkabout></my:tkabout><my:materials><my:material><my:name></my:name>" +
                "<my:filename></my:filename></my:material></my:materials></my:temacursa></my:temicursov></my:field>";
            QuestionNo = new List<Question>();
            return file;
        }

        public string textToGift()
        {
            return textToString(true);
        }
    }
}
