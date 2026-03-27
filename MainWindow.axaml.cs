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
        var rowCelsius = Grid.GetRow(Celsius);
        var rawDegrees = "";
        TextBox targetTextBox;

        if (rowCelsius == 0)
        {
            rawDegrees = Celsius.Text;

            targetTextBox = Fahrenheit;
        }
        else
        {
            rawDegrees = Fahrenheit.Text;

            targetTextBox = Celsius;
        }

        if (double.TryParse(rawDegrees, out double raw))
        {
            var translated = rowCelsius == 0
                ? raw * (9d / 5d) + 32d
                : (raw - 32d) * 5d / 9d;

            targetTextBox.Text = translated.ToString("0.0");
        }
        else
        {
            Celsius.Text = "";
            Fahrenheit.Text = "";
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