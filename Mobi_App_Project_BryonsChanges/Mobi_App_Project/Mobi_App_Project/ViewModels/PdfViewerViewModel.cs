using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using Mobi_App_Project.Models;
using Mobi_App_Project.Views;
using Mobi_App_Project.Helpers;
using Mobi_App_Project.Services;


namespace Mobi_App_Project.ViewModels
{
    public class PdfViewerViewModel : BaseViewModel
    {
        private Stream m_pdfDocumentStream;

        //event to detect the change in the value of a property
        public event PropertyChangedEventHandler PropertyChanged;

        public PdfViewerViewModel()
        {
            PdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("Mobi_App_Project.PDF_Succintly.pdf");
        }

        private void NotifiPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // The PDF document stream that is loaded into the instance of the PDF Viewer


        public Stream PdfDocumentStream
        {
            get => m_pdfDocumentStream;
            set
            {
                m_pdfDocumentStream = value;
                INotifyPropertyChanged("PdfDocumentStream");
            }
        }

        private void INotifyPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }
    }
}
