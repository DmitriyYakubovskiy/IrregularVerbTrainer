using IrregularVerbTrainer.Commands;
using IrregularVerbTrainer.DataAccess.Models;
using IrregularVerbTrainer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace IrregularVerbTrainer.ViewModels;

public class TestViewModel : INotifyPropertyChanged
{
    public IrregularVerb CurrentVerb
    {
        get => currentVerb;
        set
        {
            if (!(!currentVerb?.Equals(value) ?? value != null)) return;
            currentVerb = value;
            OnPropertyChanged();
        }
    }
    public string ContentNextButton
    {
        get => contentNextButton;
        set
        {
            contentNextButton = value;
            OnPropertyChanged();
        }        
    }
    public string NumberOfVerb
    {
        get => numberOfVerb;
        set
        {
            numberOfVerb = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public ICommand NextCommand => nextCommand;
    public ICommand BackCommand => backCommand;
    public ICommand FinishCommand => finishCommand;
    public List<IrregularVerb> ListVerbsForTest { get=> listVerbsForTest; set=> listVerbsForTest=value; }

    private Difficult difficult;
    private List<IrregularVerb> listVerbsForTest;
    private IrregularVerb currentVerb;
    private readonly IrregularVerbCollection verbsCollection;
    private readonly Command nextCommand;
    private readonly Command backCommand;
    private readonly Command finishCommand;
    private readonly Window window;
    private const int maxCountOfVerbs = 10;
    private int currentIndex = -1;
    private float progress = 0;
    private string contentNextButton = "Далее";
    private string numberOfVerb;
     
    public TestViewModel(IrregularVerbCollection verbsCollection, Difficult difficult, Window window)
    {
        this.difficult = difficult;
        this.verbsCollection = verbsCollection;
        this.window = window;   

        nextCommand = new DelegateCommand(_=>Next(), _ => CanNext());
        backCommand=new DelegateCommand(_=>Back(), _ => CanBack());
        finishCommand = new DelegateCommand(_ => FinishTest());

        ListVerbsForTest = new List<IrregularVerb>();
        GenerateVerbsForText();

        if (currentIndex == -1)
        {
            LoadVerb(0);
        }
    }

    private void Next()
    {
        ContentNextButton = "Далее";
        LoadVerb(currentIndex + 1);
    }

    private void FinishTest()
    {
        var form = new TestResultView(window);
        CheckAnswers();
        var testResultViewModel = new TestResultViewModel(difficult, (int)(progress*100), form);
        form.DataContext = testResultViewModel;
        if (form.ShowDialog() != true) return;
        window.DialogResult = true;
        window.Close();
    }

    private void Back()
    {
        LoadVerb(currentIndex -1);
    }

    private bool CanNext()
    {
        return currentIndex < ListVerbsForTest.Count-1;
    }

    private bool CanBack()
    {
        return currentIndex > 0;
    }

    private void LoadVerb(int index)
    {
        currentIndex = index;
        NumberOfVerb = $"{index + 1}/{maxCountOfVerbs}";
        CurrentVerb = ListVerbsForTest.ElementAt(index);
    }

    private void CheckAnswers()
    {
        for (int i = 0; i < listVerbsForTest.Count; i++)
        {
            IrregularVerb irregularVerb = verbsCollection.ListIrregularVerbs.Where(verb => verb.Translation == listVerbsForTest[i].Translation).FirstOrDefault();
            if (irregularVerb != null)
            {
                int count = 0;
                if (irregularVerb.FirstForm.ToLower() == listVerbsForTest[i].FirstForm.ToLower()) count++;
                if (irregularVerb.SecondForm.ToLower() == listVerbsForTest[i].SecondForm.ToLower()) count++;
                if (irregularVerb.ThirdForm.ToLower() == listVerbsForTest[i].ThirdForm.ToLower()) count++;

                count -= Enum.GetNames(typeof(Difficult)).Length - (int)difficult;
                for (int j = 0; j < (int)difficult; j++)
                {
                    if (count > 0)
                    {
                        listVerbsForTest[i].Points += 10;
                        progress += 1 / (float)((int)difficult * maxCountOfVerbs);
                    }
                    else
                    {
                        listVerbsForTest[i].Points -= 10;
                    }
                    count--;
                }

                if (listVerbsForTest[i].Points>100) listVerbsForTest[i].Points = 100;
                if (listVerbsForTest[i].Points < 0) listVerbsForTest[i].Points = 0;
            }
        }
    }

    private void GenerateVerbsForText()
    {
        Random random = new Random();
        for(int i=0;i<maxCountOfVerbs;i++)
        {
            int count = 0;
            while (true)
            {
                int randomIndex=random.Next(0,verbsCollection.ListIrregularVerbs.Count);
                if(ListVerbsForTest.Where(i => i.Translation == verbsCollection.ListIrregularVerbs[randomIndex].Translation).FirstOrDefault() ==null || count==verbsCollection.ListIrregularVerbs.Count)
                {
                    ListVerbsForTest.Add(verbsCollection.ListIrregularVerbs[randomIndex].Clone() as IrregularVerb);

                    List<int> indexes = new List<int>();
                    int value = random.Next(0, 3);
                    if (value == 0)ListVerbsForTest[i].FirstForm = "";
                    if (value == 1) ListVerbsForTest[i].SecondForm = "";
                    if (value == 2) ListVerbsForTest[i].ThirdForm = "";

                    for (int j = 0; j < (int)difficult-1; j++)
                    {
                        value = (value + 1) % 3;
                        if (value == 0) ListVerbsForTest[i].FirstForm = "";
                        if (value == 1) ListVerbsForTest[i].SecondForm = "";
                        if (value == 2) ListVerbsForTest[i].ThirdForm = "";
                    }
                    break;
                }
                count++;
            }
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
