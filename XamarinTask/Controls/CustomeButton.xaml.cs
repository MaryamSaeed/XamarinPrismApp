using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTask.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomeButton : ContentView
    {
        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create(
            "ButtonText",       
            typeof(string),   
            typeof(CustomeButton),
            string.Empty); 
        public static readonly BindableProperty ButtonImageSourceProperty = BindableProperty.Create(
            "ButtonImageSource",
            typeof(string),
            typeof(CustomeButton),
            string.Empty);
        public static readonly BindableProperty ButtonCommandNameProperty = BindableProperty.Create(
          "ButtonCommand",
          typeof(ICommand),
          typeof(CustomeButton));
        public string ButtonText
        {
            get => (string)GetValue(CustomeButton.ButtonTextProperty);
            set => SetValue(CustomeButton.ButtonTextProperty, value);
        }
        public string ButtonImageSource
        {
            get => (string)GetValue(CustomeButton.ButtonImageSourceProperty);
            set => SetValue(CustomeButton.ButtonImageSourceProperty, value);
        }
        public ICommand ButtonCommand
        {
            get => (ICommand)GetValue(CustomeButton.ButtonCommandNameProperty);
            set => SetValue(CustomeButton.ButtonCommandNameProperty, value);
        }
        public CustomeButton()
        {
            InitializeComponent();
        }
    }
}