using Mobi_App_Project.Models;
using Mobi_App_Project.ViewModels;
using Mobi_App_Project.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Mobi_App_Project.Helpers
{
    public class TemplateNavigation
    {
        public NavigationProxy Navigation { get; set; }

        public TemplateNavigation()
        {
            Navigation = new NavigationProxy();
            
        }

        public async void NavigateToNextQuestionViewAsync(Question question, AssessmentQuestion assessmentQuestion)
        {
            /*
            "5WayMC"
            "3WayMC"
            "2WayMC"
            "SingleText"
            "TripleText"
            */
            switch(question.Qtype)
            {
                case "5WayMC":
                    await Navigation.PushAsync(new FiveWayMCTemplate(new FiveWayMCTemplateViewModel(question, assessmentQuestion)));
                    break;
                case "3WayMC":
                    // TODO
                    break;
                case "2WayMC":
                    // TODO
                    break;
                case "SingleText":
                    await Navigation.PushAsync(new SingleTextTemplate(new SingleTextTemplateViewModel(question,assessmentQuestion)));
                    break;

                default:
                    await Navigation.PushModalAsync(new AssessmentHome());
                    break;

            }
        }

       
    }
}
