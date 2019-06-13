using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mobi_App_Project.Models;
using Mobi_App_Project.Helpers;

namespace Mobi_App_Project.Helpers
{
    public class DatabaseInit
    {
        public DatabaseInit()
        {
            Seed();
        }

        private void Seed()
        {
            int assessId = 0;

            List<Student> students = App.StudentDB.GetItemsAsync().Result;
            if (students.Count == 0)
            {
                Student s1 = new Student();
                s1.FirstName = "James";
                s1.MiddleName = "Spencer";
                s1.LastName = "Bell";
                s1.Grade = "K";
                s1.Age = 5;

                Student s2 = new Student();
                s2.FirstName = "Garret";
                s2.MiddleName = "Danger";
                s2.LastName = "Allen";
                s2.Grade = "1";
                s2.Age = 6;

                Student s3 = new Student();
                s3.FirstName = "Bryon";
                s3.MiddleName = "Byron";
                s3.LastName = "Steinwand";
                s3.Grade = "2";
                s3.Age = 7;

                App.StudentDB.SaveItemAsync(s1);
                App.StudentDB.SaveItemAsync(s2);
                App.StudentDB.SaveItemAsync(s3);
            }

            List<Assessment> assessments = App.AssesmentDB.GetItemsAsync().Result;
            if(assessments.Count == 0 )
            {
                Assessment assess1 = new Assessment();
                assess1.AssessName = EnumHatersGonnaVerify.AssessName_FeelingsCheckIn;
                assessId = App.AssesmentDB.SaveItemAsync(assess1).Result;
            }
            List<AssessmentQuestion> assessmentQuestions = App.AssesmentQuestionDB.GetItemsAsync().Result;
            List<Question> questions = App.QuestionDB.GetItemsAsync().Result;
            if(questions.Count == 0)
            {
                int id = 0;

                Question q1 = new Question();
                q1.DisplayText = EnumHatersGonnaVerify.DisplayText_HowDoYouFeelRightNow;
                q1.Qtype = EnumHatersGonnaVerify.QType_5WayMultipleChoice;
                q1.Option1 = "Happy,Sad,Excited,Mad,Scared";
                id = App.QuestionDB.SaveItemAsync(q1).Result;

                AssessmentQuestion aq1 = new AssessmentQuestion();
                aq1.AssessmentId = assessId;
                aq1.QuestionId = id;
                aq1.OrderNum = 1;
                App.AssesmentQuestionDB.SaveItemAsync(aq1);

                Question q2 = new Question();
                q2.DisplayText = EnumHatersGonnaVerify.DisplayText_WhereDoYouLive;
                q2.Qtype = EnumHatersGonnaVerify.QType_SingleTextResponse;
                id = App.QuestionDB.SaveItemAsync(q2).Result;

                AssessmentQuestion aq2 = new AssessmentQuestion();
                aq2.AssessmentId = assessId;
                aq2.QuestionId = id;
                aq2.OrderNum = 2;
                App.AssesmentQuestionDB.SaveItemAsync(aq2);

                Question q3 = new Question();
                q3.DisplayText = EnumHatersGonnaVerify.DisplayText_WhoDoYouLiveWith;
                q3.Qtype = EnumHatersGonnaVerify.QType_SingleTextResponse;
                id = App.QuestionDB.SaveItemAsync(q3).Result;

                AssessmentQuestion aq3 = new AssessmentQuestion();
                aq3.AssessmentId = assessId;
                aq3.QuestionId = id;
                aq3.OrderNum = 3;
                App.AssesmentQuestionDB.SaveItemAsync(aq3);

                Question q4 = new Question();
                q4.DisplayText = EnumHatersGonnaVerify.DisplayText_DoYouHaveFriends;
                q4.Qtype = EnumHatersGonnaVerify.QType_2WayMultipleChoice;
                q4.Option1 = "Yes,No";
                id = App.QuestionDB.SaveItemAsync(q4).Result;

                AssessmentQuestion aq4 = new AssessmentQuestion();
                aq4.AssessmentId = assessId;
                aq4.QuestionId = id;
                aq4.OrderNum = 4;
                App.AssesmentQuestionDB.SaveItemAsync(aq4);

                Question q5 = new Question();
                q5.DisplayText = EnumHatersGonnaVerify.DisplayText_WhoAreThePeopleThatLoveYouAndMakeYouFeelSafe;
                q5.Qtype = EnumHatersGonnaVerify.QType_SingleTextResponse;
                id = App.QuestionDB.SaveItemAsync(q5).Result;

                AssessmentQuestion aq5 = new AssessmentQuestion();
                aq5.AssessmentId = assessId;
                aq5.QuestionId = id;
                aq5.OrderNum = 5;
                App.AssesmentQuestionDB.SaveItemAsync(aq5);

                Question q6 = new Question();
                q6.DisplayText = EnumHatersGonnaVerify.DisplayText_DoYouFeelSaveWhenYouAreAtHome;
                q6.Qtype = EnumHatersGonnaVerify.QType_3WayMultipleChoice;
                q6.Option1 = "Yes,No,Kinda";
                id = App.QuestionDB.SaveItemAsync(q6).Result;

                AssessmentQuestion aq6 = new AssessmentQuestion();
                aq6.AssessmentId = assessId;
                aq6.QuestionId = id;
                aq6.OrderNum = 6;
                App.AssesmentQuestionDB.SaveItemAsync(aq6);

                Question q7 = new Question();
                q7.DisplayText = EnumHatersGonnaVerify.DisplayText_DoYouHaveEnoughFoodAtHome;
                q7.Qtype = EnumHatersGonnaVerify.QType_2WayMultipleChoice;
                q7.Option1 = "Yes,No";
                id = App.QuestionDB.SaveItemAsync(q7).Result;

                AssessmentQuestion aq7 = new AssessmentQuestion();
                aq7.AssessmentId = assessId;
                aq7.QuestionId = id;
                aq7.OrderNum = 7;
                App.AssesmentQuestionDB.SaveItemAsync(aq7);

                Question q8 = new Question();
                q8.DisplayText = EnumHatersGonnaVerify.DisplayText_WhatAreYourThreeBigWishes;
                q8.Qtype = EnumHatersGonnaVerify.QType_TripleTextResponse;
                id = App.QuestionDB.SaveItemAsync(q8).Result;

                AssessmentQuestion aq8 = new AssessmentQuestion();
                aq8.AssessmentId = assessId;
                aq8.QuestionId = id;
                aq8.OrderNum = 8;
                App.AssesmentQuestionDB.SaveItemAsync(aq8);

                Question q9 = new Question();
                q9.DisplayText = EnumHatersGonnaVerify.DisplayText_HowDoYouGetReadyForBed;
                q9.Qtype = EnumHatersGonnaVerify.QType_SingleTextResponse;
                id = App.QuestionDB.SaveItemAsync(q9).Result;

                AssessmentQuestion aq9 = new AssessmentQuestion();
                aq9.AssessmentId = assessId;
                aq9.QuestionId = id;
                aq9.OrderNum = 9;
                App.AssesmentQuestionDB.SaveItemAsync(aq9);
            }
        }      
    }
}
