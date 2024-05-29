using IrregularVerbTrainer.Commands;
using IrregularVerbTrainer.DataAccess.Enums;
using IrregularVerbTrainer.DataAccess.Models;
using IrregularVerbTrainer.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace IrregularVerbTrainer.ViewModels;

public class MainWindowViewModel:INotifyPropertyChanged
{
    public ICommand OutCommand => outCommand;
    public ICommand OpenListCommand => openListCommand;
    public ICommand OpenTestCommand => openTestCommand;
    public ICommand SetEasyCommand => setEasyCommand;
    public ICommand SetMediumCommand => setMediumCommand;
    public ICommand SetHardCommand => setHardCommand;
    public string StringDifficult
    {
        get => stringDifficult;
        set
        {
            stringDifficult= value;
            OnPropertyChanged();
        }
    }
    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private Difficult difficult;
    private readonly IrregularVerbCollection verbsCollection;
    private readonly Window window;
    private readonly Command outCommand;
    private readonly Command openListCommand;
    private readonly Command openTestCommand;
    private readonly Command setEasyCommand;
    private readonly Command setMediumCommand;
    private readonly Command setHardCommand;
    private string stringDifficult;
    private string name;

    public MainWindowViewModel(IrregularVerbCollection verbsCollection, Window window, string name)
    {
        this.verbsCollection = verbsCollection;
        this.window = window;
        this.name = $"Имя: {name}";
        outCommand = new DelegateCommand(_ => Out());
        openListCommand = new DelegateCommand(_ => OpenListIrregularVerbs());
        openTestCommand = new DelegateCommand(_ => OpenTest());
        setEasyCommand = new DelegateCommand(_ => SetEasy(),_=>CanSetEasy());
        setMediumCommand = new DelegateCommand(_ => SetMedium(), _ => CanSetMedium());
        setHardCommand = new DelegateCommand(_ => SetHard(), _ => CanSetHard());
        difficult = Difficult.Easy;
        StringDifficult = "Сложность: Легкая";
        window.Closing += OnWindowClosing;
    }

    public void OnWindowClosing(object sender, CancelEventArgs e)
    {
        verbsCollection.ToFile(App.currentPath);
    }
    
    private void SetEasy()
    {
        difficult = Difficult.Easy;
        StringDifficult = "Сложность: Легкая";
    }

    private void SetMedium()
    {
        difficult = Difficult.Medium;
        StringDifficult = "Сложность: Средняя";
    }

    private void SetHard()
    {
        difficult = Difficult.Hard;
        StringDifficult = "Сложность: Сложная";
    }

    private bool CanSetEasy()
    {
        return difficult!=Difficult.Easy;
    }

    private bool CanSetMedium()
    {
        return difficult != Difficult.Medium;
    }

    private bool CanSetHard()
    {
        return difficult != Difficult.Hard;
    }

    private void Out()
    {
        File.Delete(App.sessionPath);
        var loginWindow = new LoginView();
        loginWindow.DataContext = new LoginViewModel(loginWindow);
        loginWindow.Show();
        window.Close();
    }

    private void OpenListIrregularVerbs()
    {
        var form=new IrregularVerbListView(window);
        var verbListViewModel = new IrregularVerbListViewModel(verbsCollection);
        form.DataContext = verbListViewModel;
        form.ShowDialog();
    }

    private void OpenTest()
    {
        var form = new TestView(window);
        var testViewModel = new TestViewModel(verbsCollection,difficult,form);
        form.DataContext = testViewModel;
        if (form.ShowDialog() != true) return;
        UpdateList(testViewModel.ListVerbsForTest);
    }

    private void UpdateList(List<IrregularVerb> verbs)
    {
        for (int i = 0; i < verbs.Count; i++)
        {
            IrregularVerb irregularVerb = verbsCollection.ListIrregularVerbs.Where(verb => verb.Translation == verbs[i].Translation).FirstOrDefault();
            if(irregularVerb != null)
            {
                irregularVerb.Points = verbs[i].Points;    
            }
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
