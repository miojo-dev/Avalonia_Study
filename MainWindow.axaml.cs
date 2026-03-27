using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace tutorial;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (double.TryParse(Celsius.Text, out double C))
        {
            var F = C * (9d / 5d) + 32;

            Fahrenheit.Text = F.ToString("0.0");
        }
        else
        {
            Celsius.Text = "0";
            Fahrenheit.Text = "0";
        }
    }

    private void Switch_Sort(object? sender, RoutedEventArgs e)
    {
        var rowCelsius = Grid.GetRow(Celsius);

        if (rowCelsius == 0)
        {
            // Celsius
            Grid.SetRow(Celsius, 1);
            Grid.SetRow(CelsiusText, 1);

            //Fahrenheit
            Grid.SetRow(Fahrenheit, 0);
            Grid.SetRow(FahrenheitText, 0);
        }
        else
        {
            // Celsius
            Grid.SetRow(Celsius, 0);
            Grid.SetRow(CelsiusText, 0);

            //Fahrenheit
            Grid.SetRow(Fahrenheit, 1);
            Grid.SetRow(FahrenheitText, 1);
        }
    }
}