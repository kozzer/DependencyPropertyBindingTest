using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DependencyPropertyBindingTest
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private double sliderValue = 3;
        public double SliderValue 
        { 
            get => sliderValue; 
            set
            {
                sliderValue = value;
                onPropertyChanged(nameof(SliderValue));
            }
        }

        private SolidColorBrush circleFill;
        public SolidColorBrush CircleFill
        {
            get => circleFill;
            set
            {
                circleFill = value;
                onPropertyChanged(nameof(CircleFill));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        // INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Change_Color(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var newColor = button.Background;
            CircleFill = (SolidColorBrush)newColor;
        }
    }
}
