using Avalonia.Controls;
using Avalonia.Interactivity;

namespace tutorial;

public partial class MainWindow : Window
{
    private const double FreezingTempF = 32d;
    private const double ReverseConversionRatio = (5d/9d);
    private const double ForwardConversionRation = (9d/5d);
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        GetConversionOrder(
            out var rawDegrees,
            out var targetTextBox
        );

        if (double.TryParse(rawDegrees, out var numDegrees))
        {
            var translated = targetTextBox == Fahrenheit 
                ? ConvertCToF(numDegrees)
                : ConvertFToC(numDegrees);

            targetTextBox.Text = translated.ToString("0.0");
        }
        else
        {
            Celsius.Text = string.Empty;
            Fahrenheit.Text = string.Empty;
        }
    }

    private void GetConversionOrder(out string degrees, out TextBox target)
    {
        var rowCelsius = Grid.GetRow(Celsius);

        if (rowCelsius == 0)
        {
            degrees = Celsius.Text ?? string.Empty;

            target = Fahrenheit;
        }
        else
        {
            degrees = Fahrenheit.Text ?? string.Empty;

            target = Celsius;
        }
    }

    private static double ConvertCToF(double degrees)
    {
        var translated = degrees * ForwardConversionRation + FreezingTempF;

        return translated;
    }

    private static double ConvertFToC(double degrees)
    {
        var translated = (degrees - FreezingTempF) * ReverseConversionRatio;

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

    private static void SetBlockRow((TextBox box, TextBlock block) block, int row)
    {
        Grid.SetRow(block.box, row);
        Grid.SetRow(block.block, row);
        block.box.IsReadOnly = !block.box.IsReadOnly;
    }
}