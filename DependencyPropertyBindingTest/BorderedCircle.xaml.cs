using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DependencyPropertyBindingTest
{
    public partial class BorderedCircle : UserControl, INotifyPropertyChanged
    {
        // Fill Color
        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register(nameof(FillColor), typeof(SolidColorBrush), typeof(BorderedCircle), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));                                                                                          
        public SolidColorBrush FillColor
        {
            get => (SolidColorBrush)GetValue(FillColorProperty); 
            set { SetValue(FillColorProperty, value); onPropertyChanged(nameof(FillColor));  }
        }

        // Border Size (thickness)
        public static readonly DependencyProperty BorderSizeProperty = DependencyProperty.Register(nameof(BorderSize), typeof(double), typeof(BorderedCircle), new PropertyMetadata(1.0));
        public double BorderSize
        {
            get => (double)GetValue(BorderSizeProperty);
            set  { SetValue(BorderSizeProperty, value); onPropertyChanged(nameof(BorderSize)); }
        }

        // Constructor
        public BorderedCircle()
        {
            InitializeComponent();
        }

        // INotifyPropertyChanged
        private void  onPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public  event PropertyChangedEventHandler PropertyChanged;
    }
}
