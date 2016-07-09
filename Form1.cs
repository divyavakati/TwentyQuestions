using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwentyQuestions
{
    public partial class Form1 : Form
    {
        Question root;
        Question Current;
        Question Previous;
        bool? YesOrNo = null;
        public Form1()
        {
            InitializeComponent();
            WhatWasIt.Visible = false;
            NewQuestion.Visible = false;
            WhatwasittextBox.Visible = false;
            GiveMeQuestiontextBox.Visible = false;
            Commit_Button.Visible = false;
            RestartYes.Visible = false;
            RestartNo.Visible = false;
            AddQuestionNo.Visible = false;
            AddQuestionYes.Visible = false;
            Question q1 = new Question();
            q1.question = "Is it Organic?";
            q1.yes = new Question();
            q1.yes.question = "Is it chocolate?";
            q1.No = new Question();
            q1.No.question = "Is it sand?";
            root = q1;
            Current = q1;
            TwentyQuestion.Text = q1.question;
            
            //show the question
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            if (Current.yes == null && Current.No == null)
            {
                TwentyQuestion.Text = "Yeah, you have nailed it! Do you want to play again?";
                YesButton.Visible = false;
                NoButton.Visible = false;
                RestartYes.Visible = true;
                RestartNo.Visible = true;
            }
            else {
                TwentyQuestion.Text = Current.yes.question;
                Previous = Current;
                Current = Current.yes;
                YesOrNo = true;
            }
            

            //was this a leaf?
            //if yes, we guessed it!
            //if no, move down the yes branch
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            if (Current.yes == null && Current.No == null)
            {
                TwentyQuestion.Text = "Sorry I Couldnot guess, Do you want to add the question?";
                YesButton.Visible = false;
                NoButton.Visible = false;
                RestartYes.Visible = false;
                RestartNo.Visible = false;
                AddQuestionNo.Visible = true;
                AddQuestionYes.Visible = true;

            }
            else {
                TwentyQuestion.Text = Current.No.question;
                Previous = Current;
                Current = Current.No;
                YesOrNo = false;
            }
            //was this a leaf?
            //if yes, we dont know it, so get new info.
            //if no, move down the no branch.
        }

        private void RestartYes_Click(object sender, EventArgs e)
        {
            TwentyQuestion.Text = root.question;
            Current = root;
            YesButton.Visible = true;
            NoButton.Visible = true;
            RestartNo.Visible = false;
            RestartYes.Visible = false;
            YesOrNo = null;
        }

        private void AddQuestionYes_Click(object sender, EventArgs e)
        {
            WhatWasIt.Visible = true;
            NewQuestion.Visible = true;
            WhatwasittextBox.Visible = true;
            GiveMeQuestiontextBox.Visible = true;
            Commit_Button.Visible = true;
            RestartYes.Visible = false;
            RestartNo.Visible = false;
            AddQuestionNo.Visible = false;
            AddQuestionYes.Visible = false;
            YesButton.Visible = false;
            NoButton.Visible = false;
            TwentyQuestion.Text = "Please add the question";

        }

        private void AddQuestionNo_Click(object sender, EventArgs e)
        {
            TwentyQuestion.Text = "Thanks For Playing :)";
            AddQuestionNo.Visible = false;
            AddQuestionYes.Visible = false;
        }

        private void Commit_Button_Click(object sender, EventArgs e)
        {
            TwentyQuestion.Visible = true;
            
            Question newquestion = new Question();
            Question Answer = new Question();
            Answer.question = WhatwasittextBox.Text;
            newquestion.question = GiveMeQuestiontextBox.Text;
            newquestion.yes = Answer;
            if (YesOrNo == true)
            {
                newquestion.No = Current;
                Previous.yes = newquestion;
            }
            else
            {
                newquestion.No = Current;
                Previous.No = newquestion;
            }
            TwentyQuestion.Text = "Thanks for Letting me know. Do you want to play again?";
            WhatWasIt.Visible = false;
            NewQuestion.Visible = false;
            WhatwasittextBox.Visible = false;
            GiveMeQuestiontextBox.Visible = false;
            Commit_Button.Visible = false;
            RestartYes.Visible = true;
            RestartNo.Visible = true;
            YesButton.Visible = false;
            NoButton.Visible = false;
            AddQuestionNo.Visible = false;
            AddQuestionYes.Visible = false;
            
        }

        private void RestartNo_Click(object sender, EventArgs e)
        {
            TwentyQuestion.Text = "Thanks For Playing :)";
            YesButton.Visible = false;
            NoButton.Visible = false;
            RestartYes.Visible = false;
            RestartNo.Visible = false;
        }
    }
}
