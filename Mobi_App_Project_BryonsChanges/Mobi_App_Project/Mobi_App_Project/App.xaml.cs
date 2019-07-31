using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobi_App_Project.Views;
using Mobi_App_Project.DB;
using System.IO;
using Mobi_App_Project.Models;

using Mobi_App_Project.Services;
using System.Collections.Generic;
using Mobi_App_Project.ViewModels;
using Mobi_App_Project.Helpers;
using System.Threading.Tasks;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Mobi_App_Project
{
    public partial class App : Application
    {
        //UserDatabase
        private static UserDatabase userDatabase;
        private static string appDBName = "AssessAppDB.db";
        private static AppDatabase appDatabase;
        private static AssesmentDB assesmentDB;
        private static AdminUserDB adminUserDB;
        private static AssesmentQuestionDB assesmentQuestionDB;
        private static AssesmentSessionDB assesmentSessionDB;
        private static GroupDB groupDB;
        private static QuestionDB questionDB;
        private static ResultDB resultDB;
        private static StudentDB studentDB;
        private static StudentGroupDB studentGroupDB;

        public static AdminUser AdminUser { get; set; }
        public static Assessment Assessment { get; set; }
        public static Student Student { get; set; }
        public static AssessmentSession AssessmentSession { get; set; }
        //public static Group Group { get; set; }

        public static List<AssessmentQuestion> CurrentAssessmentQuestions { get; set; }
        public static List<Question> CurrentQuestions { get; set; }
        public static int CurrentAssessmentSessionId { get; set; }
        public static bool IsGroup { get; set; }
        public static int CurrentQuestionId { get; set; }
        public static int CurrentAssessmentQuestionId { get; set; }


        public static List<AdminUser> AdminUsers;

        public App()
        {
            InitializeComponent();


            AdminUser user = new AdminUser();
            user.UserName = "a";
            user.PasswordHash = "b";
            user.UserName = "testUser";
            user.DBName = "testUserDb";

            AdminUser = user;
            LoginViewModel lvm = new LoginViewModel();

            DatabaseInit dbInit = new DatabaseInit();

            Student = null;
            Assessment = null;
            AssessmentSession = null;
            CurrentAssessmentSessionId = 0;
            IsGroup = false;
            CurrentQuestionId = 0;

            CurrentAssessmentQuestions = new List<AssessmentQuestion>();
            CurrentQuestions = new List<Question>();

            MainPage = new NavigationPage(new AdminHome());
            //MainPage = new SingleTextTemplate(new SingleTextTemplateViewModel(nextQuestion, nextAssessmentQuestion));
        }
        public static AssesmentDB AssesmentDB
        {
            get
            {
                if (assesmentDB == null)
                {
                    assesmentDB = new AssesmentDB(UserDatabase.GetConnection()); // (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return assesmentDB;
            }
        }

        public static AssesmentQuestionDB AssesmentQuestionDB
        {
            get
            {
                if (assesmentQuestionDB == null)
                {
                    assesmentQuestionDB = new AssesmentQuestionDB(UserDatabase.GetConnection()); // (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return assesmentQuestionDB;
            }
        }

        public static AssesmentSessionDB AssesmentSessionDB
        {
            get
            {
                if (assesmentSessionDB == null)
                {
                    assesmentSessionDB = new AssesmentSessionDB(UserDatabase.GetConnection()); // (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return assesmentSessionDB;
            }
        }

        public static GroupDB GroupDB
        {
            get
            {
                if (groupDB == null)
                {
                    groupDB = new GroupDB(UserDatabase.GetConnection()); // (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return groupDB;
            }
        }

        public static QuestionDB QuestionDB
        {
            get
            {
                if (questionDB == null)
                {
                    questionDB = new QuestionDB(UserDatabase.GetConnection()); // (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return questionDB;
            }
        }

        public static ResultDB ResultDB
        {
            get
            {
                if (resultDB == null)
                {
                    resultDB = new ResultDB(UserDatabase.GetConnection()); // (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return resultDB;
            }
        }

        public static StudentDB StudentDB
        {
            get
            {
                if (studentDB == null)
                {
                    studentDB = new StudentDB(UserDatabase.GetConnection()); // (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return studentDB;
            }
        }

        public static StudentGroupDB StudentGroupDB
        {
            get
            {
                if (studentGroupDB == null)
                {
                    studentGroupDB = new StudentGroupDB(UserDatabase.GetConnection()); // (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return studentGroupDB;
            }
        }

        

        public static AdminUserDB AdminUserDB
        {
            get
            {
                if (adminUserDB == null)
                {
                    adminUserDB = new AdminUserDB(AppDatabase.GetConnection()); // (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return adminUserDB;
            }
        }

        public static AppDatabase AppDatabase
        {
            get
            {
                if (appDatabase == null)
                {
                    appDatabase = new AppDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return appDatabase;
            }
        }
        public static UserDatabase UserDatabase
        {
            get
            {
                //cannot get user database until the user has logged in
                if (userDatabase == null && adminUserDB != null)
                {
                    userDatabase = new UserDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), adminUserDB.DBName)); //"TodoSQLite.db3"
                }
                return userDatabase;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
