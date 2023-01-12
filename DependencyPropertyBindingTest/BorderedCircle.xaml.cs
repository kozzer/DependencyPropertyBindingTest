using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DependencyPropertyBindingTest
{
    /// <summary>
    /// Interaction logic for BorderedCircle.xaml
    /// </summary>
    public partial class BorderedCircle : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register(nameof(FillColor), typeof(SolidColorBrush), typeof(BorderedCircle), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));                                                                                          
        public SolidColorBrush FillColor
        {
            get => (SolidColorBrush)GetValue(FillColorProperty); 
            set { SetValue(FillColorProperty, value); onPropertyChanged(nameof(FillColor));  }
        }


        public static readonly DependencyProperty BorderSizeProperty = DependencyProperty.Register(nameof(BorderSize), typeof(double), typeof(BorderedCircle), new PropertyMetadata(1.0));


        public double BorderSize
        {
            get => (double)GetValue(BorderSizeProperty);
            set  { SetValue(BorderSizeProperty, value); onPropertyChanged(nameof(BorderSize)); }
        }

        public BorderedCircle()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
