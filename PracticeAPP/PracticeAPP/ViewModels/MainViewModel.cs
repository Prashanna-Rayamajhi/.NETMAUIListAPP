using PracticeAPP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticeAPP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        ObservableCollection<string> _items; //private fields of VeiwModels
        string _text;
        ICommand _addCommand;
        ICommand _removeCommand;
        ICommand _tap;
        IConnectivity connectivity;

        //public properties of ViewModels
        public ObservableCollection<string> Items { 
            get { return _items; }
            set { 
                _items = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value; OnPropertyChanged();
            }
        }

        //public Command Properties of View Models 
        public ICommand AddCommand {
            get
            {
                return _addCommand ?? (_addCommand = new Command(this.ExecuteAddCommand));
            } 
        }
        
        public ICommand RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new Command(this.ExecuteRemoveCommand));
            }
        }

        public ICommand TapCommand
        {
            get
            {
                return _tap ?? (_tap = new Command(this.ExecuteTapCommand));
            }
        }

        //Constructor
        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            this.connectivity = connectivity;
        }

        //methods associated with commands in from of System.Action<object>
        async void ExecuteAddCommand()
        {

            if(String.IsNullOrWhiteSpace(Text))
            {
                return;
            }
            if(this.connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("No Internet!!", "Please Check the Internet Connection!!!", "Ok");
            }

            this.Items.Add(Text);
            this.Text = string.Empty;
        }

        void ExecuteRemoveCommand(object text)
        {
            if(text.ToString() != null)
            {
                if (Items.Contains(text.ToString()))
                {
                    Items.Remove(text.ToString());
                }
            }
            
        }
        async void ExecuteTapCommand(object text)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Text={text.ToString()}");

        }

    }


}
