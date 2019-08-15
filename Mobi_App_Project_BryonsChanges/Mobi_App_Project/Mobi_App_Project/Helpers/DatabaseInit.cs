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
            LoadData();
        }

        public List<Question> GetAssessmentQuetions()
        {
            List<Question> questions = new List<Question>();
            List<AssessmentQuestion> assessmentQuestions = new List<AssessmentQuestion>();

            int assessmentId = App.Assessment.AssessmentId;

            assessmentQuestions = App.AssesmentQuestionDB.GetAssessmentQuestionsByAssessmentId(assessmentId).Result;

            foreach(AssessmentQuestion assessmentQuestion in assessmentQuestions)
            {

            }

            return questions;
        }

        private void LoadData()
        {
           
            //--------------------------------------------------------------------------------------------------------------
          
            int assessId = 0;

            Assessment assessment = App.AssesmentDB.GetAssessmentByAssessNameAsync(EnumHatersGonnaVerify.AssessName_FeelingsCheckIn).Result;

            if (assessment == null)
            {
                Assessment assess1 = new Assessment();
                assess1.AssessName = EnumHatersGonnaVerify.AssessName_FeelingsCheckIn;
                assessId = App.AssesmentDB.SaveItemAsync(assess1).Result;
            }
            else
            {
                assessId = assessment.AssessmentId;
            }


            //--------------------------------------------------------------------------------------------------------------

          
            Student s1 = new Student();
            s1.FirstName = "James";
            s1.MiddleName = "Spencer";
            s1.LastName = "Bell";
            s1.Grade = "K";
            s1.Age = 5;

            Student s1Verify = App.StudentDB.GetStudentByName(s1.FirstName, s1.MiddleName, s1.LastName).Result;

            if(s1Verify == null)
            {
                App.StudentDB.SaveItemAsync(s1);
            }
            
            Student s2 = new Student();
            s2.FirstName = "Garret";
            s2.MiddleName = "Danger";
            s2.LastName = "Allen";
            s2.Grade = "1";
            s2.Age = 6;

            Student s2Verify = App.StudentDB.GetStudentByName(s2.FirstName, s2.MiddleName, s2.LastName).Result;

            if (s2Verify == null)
            {
                App.StudentDB.SaveItemAsync(s2);
            }

            Student s3 = new Student();
            s3.FirstName = "Bryon";
            s3.MiddleName = "Byron";
            s3.LastName = "Steinwand";
            s3.Grade = "2";
            s3.Age = 7;

            Student s3Verify = App.StudentDB.GetStudentByName(s3.FirstName, s3.MiddleName, s3.LastName).Result;

            if (s3Verify == null)
            {
                App.StudentDB.SaveItemAsync(s3);
            }

            //--------------------------------------------------------------------------------------------------------------

            List<AssessmentQuestion> assessmentQuestions = App.AssesmentQuestionDB.GetItemsAsync().Result;
            List<Question> questions = App.QuestionDB.GetItemsAsync().Result;

            if (assessmentQuestions.Count > 0)
            {
                foreach (AssessmentQuestion assessmentQuestion in assessmentQuestions)
                {
                    App.AssesmentQuestionDB.DeleteItemAsync(assessmentQuestion);
                }
            }
            if (questions.Count > 0)
            {
                foreach (Question question in questions)
                {
                    App.QuestionDB.DeleteItemAsync(question);
                }
            }

            //--------------------------------------------------------------------------------------------------------------

            int success = 0;

            Question q1 = new Question();           
            q1.DisplayText = EnumHatersGonnaVerify.DisplayText_HowDoYouFeelRightNow;
            q1.Qtype = EnumHatersGonnaVerify.QType_5WayMultipleChoice;
            q1.Option1 = EnumHatersGonnaVerify.OptionText_HappySadExcitedMadScared;
            success = App.QuestionDB.SaveItemAsync(q1).Result;

            AssessmentQuestion aq1 = new AssessmentQuestion();
            aq1.AssessmentId = assessId;
            aq1.QuestionId = q1.QuestionId;
            aq1.OrderNum = 1;
            App.AssesmentQuestionDB.SaveItemAsync(aq1);
            
           
//--------------------------------------------------------------------------------------------------------------


            Question q2 = new Question();          
            q2.DisplayText = EnumHatersGonnaVerify.DisplayText_WhereDoYouLive;
            q2.Qtype = EnumHatersGonnaVerify.QType_SingleTextResponse;
            success = App.QuestionDB.SaveItemAsync(q2).Result;

            AssessmentQuestion aq2 = new AssessmentQuestion();           
            aq2.AssessmentId = assessId;
            aq2.QuestionId = q2.QuestionId; 
            aq2.OrderNum = 2;
            App.AssesmentQuestionDB.SaveItemAsync(aq2);

//--------------------------------------------------------------------------------------------------------------

            Question q3 = new Question();
            q3.DisplayText = EnumHatersGonnaVerify.DisplayText_WhoDoYouLiveWith;
            q3.Qtype = EnumHatersGonnaVerify.QType_SingleTextResponse;
            success = App.QuestionDB.SaveItemAsync(q3).Result;

            AssessmentQuestion aq3 = new AssessmentQuestion();
            aq3.AssessmentId = assessId;
            aq3.QuestionId = q3.QuestionId; 
            aq3.OrderNum = 3;
            App.AssesmentQuestionDB.SaveItemAsync(aq3);

//--------------------------------------------------------------------------------------------------------------          

            Question q4 = new Question();
            q4.DisplayText = EnumHatersGonnaVerify.DisplayText_DoYouHaveFriends;
            q4.Qtype = EnumHatersGonnaVerify.QType_2WayMultipleChoice;
            q4.Option1 = EnumHatersGonnaVerify.OptionText_YesNo;
            success = App.QuestionDB.SaveItemAsync(q4).Result;

            AssessmentQuestion aq4 = new AssessmentQuestion();
            aq4.AssessmentId = assessId;
            aq4.QuestionId = q4.QuestionId;
            aq4.OrderNum = 4;
            App.AssesmentQuestionDB.SaveItemAsync(aq4);

//--------------------------------------------------------------------------------------------------------------

            Question q5 = new Question();
            q5.DisplayText = EnumHatersGonnaVerify.DisplayText_WhoAreThePeopleThatLoveYouAndMakeYouFeelSafe;
            q5.Qtype = EnumHatersGonnaVerify.QType_SingleTextResponse;
            success = App.QuestionDB.SaveItemAsync(q5).Result;

            AssessmentQuestion aq5 = new AssessmentQuestion();
            aq5.AssessmentId = assessId;
            aq5.QuestionId = q5.QuestionId; 
            aq5.OrderNum = 5;
            App.AssesmentQuestionDB.SaveItemAsync(aq5);
            
//--------------------------------------------------------------------------------------------------------------

            Question q6 = new Question();
            q6.DisplayText = EnumHatersGonnaVerify.DisplayText_DoYouFeelSaveWhenYouAreAtHome;
            q6.Qtype = EnumHatersGonnaVerify.QType_3WayMultipleChoice;
            q6.Option1 = EnumHatersGonnaVerify.OptionText_YesNoKinda;
            success = App.QuestionDB.SaveItemAsync(q6).Result;

            AssessmentQuestion aq6 = new AssessmentQuestion();
            aq6.AssessmentId = assessId;
            aq6.QuestionId = q6.QuestionId; 
            aq6.OrderNum = 6;
            App.AssesmentQuestionDB.SaveItemAsync(aq6);

//--------------------------------------------------------------------------------------------------------------

            Question q7 = new Question();
            q7.DisplayText = EnumHatersGonnaVerify.DisplayText_DoYouHaveEnoughFoodAtHome;
            q7.Qtype = EnumHatersGonnaVerify.QType_2WayMultipleChoice;
            q7.Option1 = EnumHatersGonnaVerify.OptionText_YesNo;
            success = App.QuestionDB.SaveItemAsync(q7).Result;

            AssessmentQuestion aq7 = new AssessmentQuestion();
            aq7.AssessmentId = assessId;
            aq7.QuestionId = q7.QuestionId;
            aq7.OrderNum = 7;
            App.AssesmentQuestionDB.SaveItemAsync(aq7);

//--------------------------------------------------------------------------------------------------------------

            Question q8 = new Question();
            q8.DisplayText = EnumHatersGonnaVerify.DisplayText_WhatAreYourThreeBigWishes;
            q8.Qtype = EnumHatersGonnaVerify.QType_TripleTextResponse;
            success = App.QuestionDB.SaveItemAsync(q8).Result;

            AssessmentQuestion aq8 = new AssessmentQuestion();
            aq8.AssessmentId = assessId;
            aq8.QuestionId = q8.QuestionId;
            aq8.OrderNum = 8;
            App.AssesmentQuestionDB.SaveItemAsync(aq8);

//--------------------------------------------------------------------------------------------------------------

            Question q9 = new Question();
            q9.DisplayText = EnumHatersGonnaVerify.DisplayText_HowDoYouGetReadyForBed;
            q9.Qtype = EnumHatersGonnaVerify.QType_SingleTextResponse;
            success = App.QuestionDB.SaveItemAsync(q9).Result;

            AssessmentQuestion aq9 = new AssessmentQuestion();
            aq9.AssessmentId = assessId;
            aq9.QuestionId = q9.QuestionId;
            aq9.OrderNum = 9;
            App.AssesmentQuestionDB.SaveItemAsync(aq9);

            //--------------------------------------------------------------------------------------------------------------

            List<AssessmentSession> assessmentSessions = new List<AssessmentSession>();

            assessmentSessions = App.AssesmentSessionDB.GetItemsAsync().Result;

            if(assessmentSessions.Count > 0)
            {
                foreach(AssessmentSession assessmentSession in assessmentSessions)
                {
                    App.AssesmentSessionDB.DeleteItemAsync(assessmentSession);
                }
            }

            AssessmentSession as1 = new AssessmentSession();
            as1.AssessmentId = App.AssesmentDB.GetAssessmentByAssessNameAsync(EnumHatersGonnaVerify.AssessName_FeelingsCheckIn).Result.AssessmentId;
            as1.SessionDate = JulianDateParser.ConverToJD(DateTime.Now);
            as1.StudentId = App.StudentDB.GetStudentByName("James","Bell").Result.StudentId;
            App.AssesmentSessionDB.SaveItemAsync(as1);

            //--------------------------------------------------------------------------------------------------------------

            List<Result> results;

            results = App.ResultDB.GetItemsAsync().Result;
            Result re1 = App.ResultDB.GetItemAsync(1).Result;

            if(results.Count > 0 )
            {
                foreach(Result result in results)
                {
                    App.ResultDB.DeleteItemAsync(result);
                }
            }

            Result r1 = new Result();
            r1.AssesmentQuestionId = aq1.AssessmentQuestionId;
            r1.AssessmentSessionId = as1.SessionId;
            r1.QuestionId = q1.QuestionId;
            r1.TextResults = "Happy";
            r1.AssessmentQuestionInstructorNotes = "Kid Seems Happy";
            App.ResultDB.SaveItemAsync(r1);

            Result r2 = new Result();
            r2.AssesmentQuestionId = aq2.AssessmentQuestionId;
            r2.AssessmentSessionId = as1.SessionId;
            r2.QuestionId = q2.QuestionId;
            r2.TextResults = "In my happy house";
            r2.AssessmentQuestionInstructorNotes = "Kid Seems to have a good home life";
            App.ResultDB.SaveItemAsync(r2);

            Result r3 = new Result();
            r3.AssesmentQuestionId = aq3.AssessmentQuestionId;
            r3.AssessmentSessionId = as1.SessionId;
            r3.QuestionId = q3.QuestionId;
            r3.TextResults = "My happy mom and dad";
            r3.AssessmentQuestionInstructorNotes = "Kid Seems has happy parents";
            App.ResultDB.SaveItemAsync(r3);

            Result r4 = new Result();
            r4.AssesmentQuestionId = aq4.AssessmentQuestionId;
            r4.AssessmentSessionId = as1.SessionId;
            r4.QuestionId = q4.QuestionId;
            r4.TextResults = "Yes";
            r4.AssessmentQuestionInstructorNotes = "Kid has friends";
            App.ResultDB.SaveItemAsync(r4);

            Result r5 = new Result();
            r5.AssesmentQuestionId = aq5.AssessmentQuestionId;
            r5.AssessmentSessionId = as1.SessionId;
            r5.QuestionId = q5.QuestionId;
            r5.TextResults = "Mom and Dad";
            r5.AssessmentQuestionInstructorNotes = "His mom and dad";
            App.ResultDB.SaveItemAsync(r5);

            Result r6 = new Result();
            r6.AssesmentQuestionId = aq6.AssessmentQuestionId;
            r6.AssessmentSessionId = as1.SessionId;
            r6.QuestionId = q6.QuestionId;
            r6.TextResults = "Yes";
            r6.AssessmentQuestionInstructorNotes = "Kid feels safe";
            App.ResultDB.SaveItemAsync(r6);

            Result r7 = new Result();
            r7.AssesmentQuestionId = aq7.AssessmentQuestionId;
            r7.AssessmentSessionId = as1.SessionId;
            r7.QuestionId = q7.QuestionId;
            r7.TextResults = "Yes";
            r7.AssessmentQuestionInstructorNotes = "Kid is always full";
            App.ResultDB.SaveItemAsync(r7);

            Result r8 = new Result();
            r8.AssesmentQuestionId = aq8.AssessmentQuestionId;
            r8.AssessmentSessionId = as1.SessionId;
            r8.QuestionId = q8.QuestionId;
            r8.TextResults = "Go to space :FULLSTOP: Be an astronaut :FULLSTOP: Ride a rocket";
            r8.AssessmentQuestionInstructorNotes = "Kid is an adrenaline junky";
            App.ResultDB.SaveItemAsync(r8);

            Result r9 = new Result();
            r9.AssesmentQuestionId = aq9.AssessmentQuestionId;
            r9.AssessmentSessionId = as1.SessionId;
            r9.QuestionId = q9.QuestionId;
            r9.TextResults = "Brush";
            r9.AssessmentQuestionInstructorNotes = "Kid has clean teeth";
            App.ResultDB.SaveItemAsync(r9);
        }
    }
}
