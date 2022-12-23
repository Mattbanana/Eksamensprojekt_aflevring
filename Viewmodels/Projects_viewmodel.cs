using Eksamensprojekt_2nd.Models;
using Eksamensprojekt_2nd.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_2nd.Viewmodels
{
    public class Projects_viewmodel
    {
        
        private Project project_VM;

        public string Name
        {
            get { return project_VM.Project_name; }
            set
            {
                project_VM.Project_name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Number
        {
            get { return project_VM.Project_number; }
            set
            {
                project_VM.Project_number = value;
                OnPropertyChanged("Number");
            }
        }

        public double Hours_planed
        {
            get { return project_VM.Hours_planed; }
            set
            {
                project_VM.Hours_planed = value;
                OnPropertyChanged("Hours_planed");
            }
        }

        public string Start_date
        {
            get { return project_VM.Start_date; }
            set
            {
                project_VM.Start_date = value;
                OnPropertyChanged("Start_date");
            }
        }

        public string End_date
        {
            get { return project_VM.End_date; }
            set
            {
                project_VM.End_date = value;
                OnPropertyChanged("End_date");
            }
        }

        public string Comment
        {
            get { return project_VM.Comment; }
            set
            {
                project_VM.Comment = value;
                OnPropertyChanged("Comment");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
