using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace CPPK.NET
{
    public partial class App : Form
    {
        // GroupBox
        private GroupBox
            groupHeader =
                new GroupBox {
                    Location = new Point(10, 10),
                    Width = 780,
                    Height = 40,
                    Text = "Прогресс конвертации",
                    BackColor = Color.LightGray,
                    FlatStyle = FlatStyle.Flat
                };

        private GroupBox
            groupBody =
                new GroupBox {
                    Location = new Point(10, 60),
                    Width = 780,
                    Height = 380,
                    Text = "Рабочая зона",
                    BackColor = Color.LightGray,
                    FlatStyle = FlatStyle.Flat
                };

        // ProgressBar
        private ProgressBar
            progressConvert =
                new ProgressBar {
                    Maximum = 100,
                    Minimum = 0,
                    Value = 0,
                    Step = 1,
                    MarqueeAnimationSpeed = 1,
                    ForeColor = Color.Green
                };

        // ListBox
        private ListBox
            listCorrectTagNo =
                new ListBox {
                    Text = "Знак правильных ответов",
                    MinimumSize = new Size(new Point(60))
                };

        private ListBox
            listInCorrectTagNo =
                new ListBox {
                    Text = "Знак не правильных ответов",
                    MinimumSize = new Size(new Point(60))
                };

        ListBox
            listTypeConvertation =
                new ListBox {
                    Text = "Варианты конвертации",
                    MinimumSize = new Size(new Point(60))
                };

        // TextBox
        private TextBox
            textTheme = new TextBox { PlaceholderText = "Название темы" };

        private TextBox
            textCurs = new TextBox { PlaceholderText = "Название курса" };

        private TextBox textCorrectTag = new TextBox();

        private TextBox textInCorrectTag = new TextBox();

        // Button
        private Button
            butAddCorrectTagNo =
                new Button { Text = "Добавить вариант правильного ответа" };

        private Button
            butDelCorrectTagNo =
                new Button { Text = "Удалить вариант правильного ответа" };

        private Button
            butAddInCorrectTagNo =
                new Button { Text = "Добавить вариант правильного ответа" };

        private Button
            butDelInCorrectTagNo =
                new Button { Text = "Удалить вариант правильного ответа" };

        private Button
            butFileRead =
                new Button {
                    Name = "fileRead",
                    Text = "Выбрать файл",
                    FlatStyle = FlatStyle.Flat
                };

        private Button
            butFileWrite =
                new Button {
                    Name = "fileWrite",
                    Text = "Сохранить",
                    FlatStyle = FlatStyle.Flat
                };

        // RadioButton
        private RadioButton
            radioTxtLenivec =
                new RadioButton { Text = "LenivecTxt", Name = "radio" };

        private RadioButton
            radioXmlLenivec =
                new RadioButton { Text = "LenivecXml", Name = "radio" };

        private RadioButton
            radioTxtMoodle =
                new RadioButton { Text = "MoodleTxt", Name = "radio" };

        private RadioButton
            radioGiftMoodle =
                new RadioButton { Text = "MoodleGift", Name = "radio" };

        private RadioButton
            radioCustom = new RadioButton { Text = "Custom", Name = "radio" };

        // Label
        Label
            labelCorrectTagNo =
                new Label { Text = "Символы правильных ответов", Width = 190 };

        Label
            labelInCorrectTagNo =
                new Label {
                    Text = "Символы не правильных ответов",
                    Width = 200
                };

        // Configure element controls
        private void ConfigureElementControls()
        {
            // Configure groupHeader
            progressConvert.Size =
                new Size(groupHeader.Width - 10, groupHeader.Height - 25);
            progressConvert.Location = new Point(5, 20);
            groupHeader.Controls.Add (progressConvert);

            // Configure groupBody
            // Text
            textCurs.Location = new Point(groupBody.Width / 2, 20);
            textCurs.Width = groupBody.Width / 2 - 10;
            textTheme.Location =
                new Point(groupBody.Width / 2,
                    textCurs.Location.Y + textCurs.Height + 10);
            textTheme.Width = groupBody.Width / 2 - 10;

            // Label
            labelCorrectTagNo.Location =
                new Point(groupBody.Width / 2,
                    textCurs.Height + textTheme.Height + 40);
            labelInCorrectTagNo.Location =
                new Point(groupBody.Width - 200,
                    textCurs.Height + textTheme.Height + 40);

            // LsitBox
            listTypeConvertation
                .Items
                .AddRange(new string[] {
                    radioTxtLenivec.Text,
                    radioTxtMoodle.Text,
                    radioXmlLenivec.Text
                });
            listTypeConvertation.Location = new Point(5, groupBody.Height - 5);
            listCorrectTagNo.Location =
                new Point(groupBody.Width / 2,
                    textCurs.Height + textTheme.Height + 60);
            listCorrectTagNo.Width = labelCorrectTagNo.Width - 10;
            listInCorrectTagNo.Location =
                new Point(groupBody.Width / 2 + listCorrectTagNo.Width + 10,
                    textCurs.Height + textTheme.Height + 60);
            listInCorrectTagNo.Width = labelInCorrectTagNo.Width - 10;

            // Text
            textCorrectTag.Location =
                new Point(listCorrectTagNo.Location.X,
                    listCorrectTagNo.Location.Y + listCorrectTagNo.Height + 10);
            textCorrectTag.Width = listCorrectTagNo.Width;
            textInCorrectTag.Location =
                new Point(listInCorrectTagNo.Location.X,
                    listInCorrectTagNo.Location.Y +
                    listInCorrectTagNo.Height +
                    10);
            textInCorrectTag.Width = listInCorrectTagNo.Width;

            // Button
            butAddCorrectTagNo.Location =
                new Point(listCorrectTagNo.Location.X,
                    textCorrectTag.Location.Y + textCorrectTag.Height + 10);
            butDelCorrectTagNo.Location =
                new Point(listCorrectTagNo.Location.X +
                    textCorrectTag.Width -
                    butDelCorrectTagNo.Width,
                    textCorrectTag.Location.Y + textCorrectTag.Height + 10);
            butAddInCorrectTagNo.Location =
                new Point(listInCorrectTagNo.Location.X,
                    textCorrectTag.Location.Y + textCorrectTag.Height + 10);
            butDelInCorrectTagNo.Location =
                new Point(listInCorrectTagNo.Location.X +
                    textInCorrectTag.Width -
                    butDelInCorrectTagNo.Width,
                    textCorrectTag.Location.Y + textCorrectTag.Height + 10);
            butFileWrite.Location =
                new Point(groupBody.Width / 2,
                    butAddCorrectTagNo.Location.Y +
                    butAddCorrectTagNo.Height +
                    10);
            butFileWrite.Width = groupBody.Width / 2 - 10;
            butFileRead.Location = new Point(5, 20);
            butFileRead.Width = groupBody.Width / 2 - 10;

            // RadioButton
            radioTxtLenivec.Location =
                new Point(butFileRead.Location.X,
                    butFileRead.Location.Y + butFileRead.Height + 10);
            radioXmlLenivec.Location =
                new Point(radioTxtLenivec.Location.X,
                    radioTxtLenivec.Location.Y + radioTxtLenivec.Height + 10);
            radioTxtMoodle.Location =
                new Point(radioXmlLenivec.Location.X,
                    radioXmlLenivec.Location.Y + radioXmlLenivec.Height + 10);
            radioGiftMoodle.Location =
                new Point(radioTxtMoodle.Location.X,
                    radioTxtMoodle.Location.Y + radioTxtMoodle.Height + 10);
            radioCustom.Location =
                new Point(radioGiftMoodle.Location.X,
                    radioGiftMoodle.Location.Y + radioGiftMoodle.Height + 10);

            List<Control> controls =
                new List<Control> {
                    listTypeConvertation,
                    listCorrectTagNo,
                    listInCorrectTagNo,
                    labelCorrectTagNo,
                    labelInCorrectTagNo,
                    textCorrectTag,
                    textCurs,
                    textInCorrectTag,
                    textTheme,
                    butAddCorrectTagNo,
                    butAddInCorrectTagNo,
                    butDelCorrectTagNo,
                    butDelInCorrectTagNo,
                    butFileRead,
                    butFileWrite,
                    radioCustom,
                    radioGiftMoodle,
                    radioTxtLenivec,
                    radioTxtMoodle,
                    radioXmlLenivec
                };
            controls
                .ForEach(action =>
                {
                    if (action.Name != "fileRead") action.Enabled = false;
                });
            groupBody.Controls.AddRange(controls.ToArray());
        }

        private void enableControlText()
        {
            if (textCurs.Enabled == false)
            {
                textCurs.Enabled = true;
                textTheme.Enabled = true;
            }
        }

        private void ConfigureElementEvents()
        {
            StringConverter stringConverter = new StringConverter();
            OpenFileDialog ofd =
                new OpenFileDialog { Filter = "Текстовые файлы (*.txt)|*.txt" };
            SaveFileDialog sfd = new SaveFileDialog();

            butFileRead.Click += (object sender, EventArgs e) =>
            {
                if (ofd.ShowDialog() == DialogResult.Cancel) return;
                stringConverter = new StringConverter();
                stringConverter.Data = System.IO.File.ReadAllText(ofd.FileName);
                progressConvert.Value = 0;
                foreach (Control element in groupBody.Controls)
                {
                    if (element.Name == "radio") element.Enabled = true;
                }
            };
            butFileWrite.Click += (object sender, EventArgs e) =>
            {
                float fileByteSize = 0;
                string file = "";
                string fileName =
                    ofd.FileName.Substring(0, ofd.FileName.Length - 3) +
                    "output" +
                    sfd.FilterIndex;
                sfd.FileName = fileName.Split("\\").Reverse().First();
                if (sfd.ShowDialog() == DialogResult.Cancel) return;
                if (sfd.FileName == fileName.Split("\\").Reverse().First())
                    sfd.FileName = fileName;
                if (radioTxtLenivec.Checked)
                {
                    file = stringConverter.textToString();
                    fileByteSize = file.Length;
                    System.IO.File.WriteAllText(sfd.FileName, file);
                }
                if (radioXmlLenivec.Checked)
                {
                    file = stringConverter.textToXml();
                    fileByteSize = file.Length;
                    System.IO.File.WriteAllText(sfd.FileName, file);
                }
                if (radioTxtMoodle.Checked)
                {
                    file = stringConverter.textToString(true);
                    fileByteSize = file.Length;
                    MessageBox.Show("Checked");
                    System.IO.File.WriteAllText(sfd.FileName, file);
                }
                if (radioGiftMoodle.Checked)
                {
                    file = stringConverter.textToGift();
                    fileByteSize = file.Length;
                    System.IO.File.WriteAllText(sfd.FileName, file);
                }
                if (radioCustom.Checked)
                {
                    if (sfd.FileName.EndsWith(".txt"))
                        file = stringConverter.textToString();
                    else
                        file = stringConverter.textToXml();
                    fileByteSize = file.Length;
                    System.IO.File.WriteAllText(sfd.FileName, file);
                }
                /* float fileWriteByteSize =
                    new System.IO.FileInfo(sfd.FileName).Length - 1;
                do
                {
                    int itogo =
                        (
                        int
                        )(Math.Floor(fileWriteByteSize / fileByteSize) * 100);
                    if (itogo > 100)
                        progressConvert.Value = 100;
                    else
                        progressConvert.Value = itogo;
                    fileWriteByteSize =
                        new System.IO.FileInfo(sfd.FileName).Length - 1;
                }
                while (fileWriteByteSize < fileByteSize); */
                MessageBox.Show("Файл успешно сконвертирован и сохранен.");
                progressConvert.Value = 100;
            };
            radioCustom.CheckedChanged += (object sender, EventArgs e) =>
            {
                enableControlText();
                listCorrectTagNo.Enabled = !listCorrectTagNo.Enabled == true;
                listInCorrectTagNo.Enabled =
                    !listInCorrectTagNo.Enabled == true;
                textCorrectTag.Enabled = !textCorrectTag.Enabled == true;
                textInCorrectTag.Enabled = !textInCorrectTag.Enabled == true;
                butAddCorrectTagNo.Enabled =
                    !butAddCorrectTagNo.Enabled == true;
                butDelCorrectTagNo.Enabled =
                    !butDelCorrectTagNo.Enabled == true;
                butAddInCorrectTagNo.Enabled =
                    !butAddInCorrectTagNo.Enabled == true;
                butDelInCorrectTagNo.Enabled =
                    !butDelInCorrectTagNo.Enabled == true;
                stringConverter.QuestionOptionObj =
                    new QuestionOptionObj {
                        CorrectTag = "+",
                        CorrectTagNo = new List<string>(),
                        IncorrectTag = "~",
                        IncorrectTagNo = new List<string>(),
                        AnswerTag = "@",
                        DescriptionTag =
                            new Description { Close = "]", Open = "[" }
                    };
                sfd.Filter = "Txt (*.txt)|*.txt|XML (*.xml)|*.xml";
            };
            radioTxtLenivec.Click += (object sender, EventArgs e) =>
            {
                enableControlText();
                stringConverter.QuestionOptionObj =
                    new QuestionOptionObj {
                        CorrectTag = "+",
                        CorrectTagNo = new List<string> { "+" },
                        IncorrectTag = "~",
                        IncorrectTagNo = new List<string> { "_", "-" },
                        AnswerTag = "@",
                        DescriptionTag =
                            new Description { Close = "]", Open = "[" }
                    };
                sfd.Filter = "Text (*.txt)|*.txt";
            };
            radioXmlLenivec.Click += (object sender, EventArgs e) =>
            {
                enableControlText();
                stringConverter.QuestionOptionObj =
                    new QuestionOptionObj {
                        CorrectTag = "+",
                        CorrectTagNo = new List<string> { "+" },
                        IncorrectTag = "~",
                        IncorrectTagNo = new List<string> { "_", "-" },
                        AnswerTag = "@",
                        DescriptionTag =
                            new Description { Close = "]", Open = "[" }
                    };
                sfd.Filter = "XML (*.xml)|*.xml";
            };
            radioTxtMoodle.Click += (object sender, EventArgs e) =>
            {
                butFileWrite.Enabled = true;
                stringConverter.QuestionOptionObj =
                    new QuestionOptionObj {
                        CorrectTag = "=",
                        CorrectTagNo = new List<string> { "+" },
                        IncorrectTag = "~",
                        IncorrectTagNo = new List<string> { "_", "-" },
                        AnswerTag = "::",
                        DescriptionTag =
                            new Description { Close = "]", Open = "[" }
                    };
                sfd.Filter = "Text (*.txt)|*.txt";
            };
            radioGiftMoodle.Click += (object sender, EventArgs e) =>
            {
                butFileWrite.Enabled = true;
                stringConverter.QuestionOptionObj =
                    new QuestionOptionObj {
                        CorrectTag = "=",
                        CorrectTagNo = new List<string> { "+" },
                        IncorrectTag = "~",
                        IncorrectTagNo = new List<string> { "_", "-" },
                        AnswerTag = "::",
                        DescriptionTag =
                            new Description { Close = "]", Open = "[" }
                    };
                sfd.Filter = "Gift (*.gift)|*.gift";
            };
            textCurs.TextChanged += (object sender, EventArgs e) =>
            {
                if (textCurs.Text.Length - 1 < 1)
                {
                    textCurs.BackColor = Color.Red;
                    butFileWrite.Enabled = false;
                }
                else
                {
                    butFileWrite.Enabled = true;
                    textCurs.BackColor = Color.Green;
                    stringConverter.Curs = textCurs.Text;
                }
            };
            textTheme.TextChanged += (object sender, EventArgs e) =>
            {
                if (textTheme.Text.Length - 1 < 1)
                {
                    textTheme.BackColor = Color.Red;
                    butFileWrite.Enabled = false;
                }
                else
                {
                    butFileWrite.Enabled = true;
                    textTheme.BackColor = Color.Green;
                    stringConverter.Theme = textTheme.Text;
                }
            };
            butAddCorrectTagNo.Click += (object sender, EventArgs e) =>
            {
                if (textCorrectTag.Text.Length == 0) return;
                listCorrectTagNo.Items.Add(textCorrectTag.Text);
                stringConverter.QuestionOptionObj.CorrectTagNo.Add(textCorrectTag.Text);
            };
            butDelCorrectTagNo.Click += (object sender, EventArgs e) =>
            {
                if (listCorrectTagNo.SelectedItem == null) return;
                listCorrectTagNo.Items.Remove(listCorrectTagNo.SelectedItem);
                stringConverter.QuestionOptionObj.CorrectTagNo.Remove(textCorrectTag.Text);
            };
            butAddInCorrectTagNo.Click += (object sender, EventArgs e) =>
            {
                if (textInCorrectTag.Text.Length == 0) return;
                listInCorrectTagNo.Items.Add(textInCorrectTag.Text);
                stringConverter.QuestionOptionObj.IncorrectTagNo.Add(textInCorrectTag.Text);
            };
            butDelInCorrectTagNo.Click += (object sender, EventArgs e) =>
            {
                if (listInCorrectTagNo.SelectedItem == null) return;
                listInCorrectTagNo.Items.Remove(listInCorrectTagNo.SelectedItem);
                stringConverter.QuestionOptionObj.IncorrectTagNo.Remove(textInCorrectTag.Text);
            };
        }

        // Application
        public App()
        {
            InitializeComponent();
            ConfigureElementControls();
            ConfigureElementEvents();

            // Form configure
            FormBorderStyle = FormBorderStyle.Fixed3D;
            BackColor = Color.WhiteSmoke;

            // Prepare to add element controls
            List<Control> controls =
                new List<Control> { groupHeader, groupBody };

            // Add element controls
            Controls.AddRange(controls.ToArray());
        }
    }
}
