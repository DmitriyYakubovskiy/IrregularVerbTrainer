using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace IrregularVerbTrainer.DataAccess.Models;

public class IrregularVerb : INotifyPropertyChanged, ICloneable
{
    public string Translation
    {
        get => translation;
        set
        {
            translation = value;
            OnPropertyChanged();
        }
    }
    public string FirstForm
    {
        get => firstForm;
        set
        {
            firstForm = value;
            OnPropertyChanged();
        }
    }
    public string SecondForm
    {
        get => secondForm;
        set
        {
            secondForm = value;
            OnPropertyChanged();
        }
    }
    public string ThirdForm
    {
        get => thirdForm;
        set
        {
            thirdForm = value;
            OnPropertyChanged();
        }
    }
    public int Points
    {
        get => points;
        set
        {
            points = value;
            if (points > 75) Brush = new SolidColorBrush(Colors.LightGreen);
            if (points > 40 && points <= 75) Brush = new SolidColorBrush(Colors.LightYellow);
            if (points <= 40) Brush = new SolidColorBrush(Colors.LightSalmon);
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
    private string translation;
    private string firstForm;
    private string secondForm;
    private string thirdForm;
    private int points;

    public IrregularVerb(string translation, string firstForm, string secondForm, string thirdForm, int points)
    {
        Translation = translation;
        FirstForm = firstForm;
        SecondForm = secondForm;
        ThirdForm = thirdForm;
        Points = points;
    }

    public IrregularVerb() { }

    public object Clone()
    {
        return new IrregularVerb
        {
            Translation = translation,
            FirstForm = firstForm,
            SecondForm = secondForm,
            ThirdForm = thirdForm,
            Points = points
        };
    }

    public override string ToString()
    {
        return $"{translation}\t{firstForm}\t{secondForm}\t{thirdForm}";
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
