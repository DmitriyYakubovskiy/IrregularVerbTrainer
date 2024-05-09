using IrregularVerbTrainer.DataAccess.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace IrregularVerbTrainer.ViewModels;

public class TestResultViewModel : INotifyPropertyChanged
{
    public string Difficult
    {
        get => difficult;
        set
        {
            difficult = value;
            OnPropertyChanged();
        }
    }
    public int Points
    {
        get => points;
        set
        {
            points = value;
            if (points > 75) Brush = new SolidColorBrush(Colors.Green);
            if (points > 40 && points <= 75) Brush = new SolidColorBrush(Colors.Orange);
            if (points <= 40) Brush = new SolidColorBrush(Colors.Red);
            OnPropertyChanged();
        }
    }
    public SolidColorBrush Brush
    {
        get => brush;
        set
        {
            brush = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private SolidColorBrush brush;
    private readonly Window window;
    private int points;
    private string difficult="Сложность: ";

    public TestResultViewModel(Difficult difficult, int points, Window window)
    {
        if (((int)difficult) == 1)
        {
            this.difficult += "Легкая";
        }
        else if (((int)difficult) == 2)
        {
            this.difficult += "Средняя";
        }
        else
        {
            this.difficult += "Сложная";
        }
        Points = points;
        this.window = window;
        window.Closing += OnWindowClosing;
    }

    public void OnWindowClosing(object sender, CancelEventArgs e)
    {
        window.DialogResult = true;
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
