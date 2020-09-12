using MeloMan.Visualizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Globalization;

namespace MeloMan
{
    /// <summary>
    /// Логика взаимодействия для ViewSettingsForm.xaml
    /// </summary>
    public partial class ViewSettingsForm : Window
    {
        private SpectrogramRenderer renderer;

        private TextBox intensity;
        private TextBox limit;

        public ViewSettingsForm(SpectrogramRenderer specRenderer)
        {
            InitializeComponent();
            renderer = specRenderer;
            intensity = (TextBox)FindName("IntensityPowerInput");
            SetIntensityText(renderer.IntensityPower);
            limit = (TextBox)FindName("FilterLimitInput");
            limit.Text = renderer.FilterLimit.ToString();
        }

        private void SetIntensityText(double value)
        {
            intensity.Text = value.ToString();
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            if (AcceptChanges())
            {
               // try
                //{
                    renderer.UpdateSpectrogram();
                //}
                /*catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }*/
                Close();
            }
        }

        public bool AcceptChanges()
        {
            try
            {
                renderer.IntensityPower = Double.Parse(intensity.Text, CultureInfo.CurrentCulture.NumberFormat);
                renderer.FilterLimit = Int32.Parse(limit.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }

            return true;
        }
    }
}
