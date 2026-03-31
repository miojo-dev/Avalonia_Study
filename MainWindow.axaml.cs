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
        GetConversionOrder(
            out string rawDegrees,
            out TextBox targetTextBox
        );

        if (double.TryParse(rawDegrees, out double numDegrees))
        {
            double translated = targetTextBox == Fahrenheit 
                ? ConvertCToF(numDegrees)
                : ConvertFToC(numDegrees);

            targetTextBox.Text = translated.ToString("0.0");
        }
        else
        {
            Celsius.Text = "";
            Fahrenheit.Text = "";
        }
    }

    private void GetConversionOrder(out string degrees, out TextBox target)
    {
        var rowCelsius = Grid.GetRow(Celsius);

        if (rowCelsius == 0)
        {
            degrees = Celsius.Text ?? "";

            target = Fahrenheit;
        }
        else
        {
            degrees = Fahrenheit.Text ?? "";

            target = Celsius;
        }
    }

    private double ConvertCToF(double degrees)
    {
        double translated = degrees * (9d / 5d) + 32d;

        return translated;
    }

    private double ConvertFToC(double degrees)
    {
        double translated = (degrees - 32d) * 5d / 9d;

        return translated;
    }

    private void Switch_Sort(object? sender, RoutedEventArgs e)
    {
        var rowCelsius = Grid.GetRow(Celsius);

        var celsius = (
            Celsius,
            CelsiusText
        );
        var fahrenheit = (
            Fahrenheit,
            FahrenheitText
        );

        if (rowCelsius == 0)
        {
            SetBlockRow(celsius, 1);

            SetBlockRow(fahrenheit, 0);
        }
        else
        {
            SetBlockRow(celsius, 0);

            SetBlockRow(fahrenheit, 1);
        }
    }

    private void SetBlockRow((TextBox box, TextBlock block) block, int row)
    {
        Grid.SetRow(block.box, row);
        Grid.SetRow(block.block, row);
        block.box.IsReadOnly = !block.box.IsReadOnly;
    }
}