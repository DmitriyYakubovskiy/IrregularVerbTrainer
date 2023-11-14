using System.Windows;
using IrregularVerbTrainer.Models;
using IrregularVerbTrainer.ViewModels;
using System.IO;

namespace IrregularVerbTrainer.Views;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    public static string path = @"..\..\..\Saves\irregularVerbs.xml";
    
    public App()
    {
        ShutdownMode = ShutdownMode.OnMainWindowClose;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        
        IrregularVerbCollection verbsCollection = new IrregularVerbCollection();

        if(File.Exists(path))
        {
            verbsCollection.ReadFile(path);
        }
        else
        {
            File.Create(path).Close();
            addVerbs(verbsCollection);
            verbsCollection.ToFile(path);
        }

        var mainWindow = new MainWindow();
        mainWindow.DataContext = new MainWindowViewModel(verbsCollection,mainWindow);
        mainWindow.Show();
    }

    private void addVerbs(IrregularVerbCollection verbsCollection)
    {
        verbsCollection.Add(new IrregularVerb("Быть", "Be", "Was, Were", "Been", 0));
        verbsCollection.Add(new IrregularVerb("Становиться", "Become", "Became", "Become", 0));
        verbsCollection.Add(new IrregularVerb("Бить", "Beat", "Beat", "Beaten", 0));
        verbsCollection.Add(new IrregularVerb("Начинать", "Begin", "Began", "Begun", 0));
        verbsCollection.Add(new IrregularVerb("Гнуть", "Bend", "Bent", "Bent", 0));
        verbsCollection.Add(new IrregularVerb("Держать пари", "Bet", "Bet", "Bet", 0));
        verbsCollection.Add(new IrregularVerb("Кусать", "Bite", "Bit", "Bitten", 0));
        verbsCollection.Add(new IrregularVerb("Дуть", "Blow", "Blew", "Blown", 0));
        verbsCollection.Add(new IrregularVerb("Ломать", "Break", "Broke", "Broken", 0));
        verbsCollection.Add(new IrregularVerb("Приносить", "Bring", "Brought", "Brought", 0));
        verbsCollection.Add(new IrregularVerb("Транслировать", "Broadcast", "Broadcast", "Broadcast", 0));
        verbsCollection.Add(new IrregularVerb("Строить", "Build", "Built", "Built", 0));
        verbsCollection.Add(new IrregularVerb("Разразиться", "Burst", "Burst", "Burst", 0));
        verbsCollection.Add(new IrregularVerb("Покупать", "Buy", "Bought", "Bought", 0));
        verbsCollection.Add(new IrregularVerb("Ловить", "Catch", "Caught", "Caught", 0));
        verbsCollection.Add(new IrregularVerb("Выбирать", "Choose", "Chose", "Chosen", 0));
        verbsCollection.Add(new IrregularVerb("Приходить", "Come", "Came", "Come", 0));
        verbsCollection.Add(new IrregularVerb("Стоить", "Cost", "Cost", "Cost", 0));
        verbsCollection.Add(new IrregularVerb("Ползать", "Creep", "Crept", "Crept", 0));
        verbsCollection.Add(new IrregularVerb("Резать", "Cut", "Cut", "Cut", 0));
        verbsCollection.Add(new IrregularVerb("Договориться", "Deal", "Dealt", "Dealt", 0));
        verbsCollection.Add(new IrregularVerb("Копать", "Dig", "Dug", "Dug", 0));
        verbsCollection.Add(new IrregularVerb("Делать", "Do", "Did", "Done", 0));
        verbsCollection.Add(new IrregularVerb("Рисовать", "Draw", "Drew", "Drawn", 0));
        verbsCollection.Add(new IrregularVerb("Пить", "Drink", "Drank", "Drunk", 0));
        verbsCollection.Add(new IrregularVerb("Управлять", "Drive", "Drove", "Driven", 0));
        verbsCollection.Add(new IrregularVerb("Есть", "Eat", "Ate", "Eaten", 0));
        verbsCollection.Add(new IrregularVerb("Падать", "Fall", "Fell", "Fallen", 0));
        verbsCollection.Add(new IrregularVerb("Кормить", "Feed", "Fed", "Fed", 0));
        verbsCollection.Add(new IrregularVerb("Чувствовать", "Feel", "Felt", "Felt", 0));
        verbsCollection.Add(new IrregularVerb("Сражаться", "Fight", "Fought", "Fought", 0));
        verbsCollection.Add(new IrregularVerb("Находить", "Find", "Found", "Found", 0));
        verbsCollection.Add(new IrregularVerb("Убежать", "Flee", "Fled", "Fled", 0));
        verbsCollection.Add(new IrregularVerb("Летать", "Fly", "Flew", "Flown", 0));
        verbsCollection.Add(new IrregularVerb("Запрещать", "Forbid", "Forbade", "Forbidden", 0));
        verbsCollection.Add(new IrregularVerb("Забывать", "Forget", "Forgot", "Forgotten", 0));
        verbsCollection.Add(new IrregularVerb("Прощать", "Forgive", "Forgave", "Forgiven", 0));
        verbsCollection.Add(new IrregularVerb("Морозить", "Freeze", "Froze", "Frozen", 0));
        verbsCollection.Add(new IrregularVerb("Достать", "Get", "Got", "Got", 0));
        verbsCollection.Add(new IrregularVerb("Давать", "Give", "Gave", "Given", 0));
        verbsCollection.Add(new IrregularVerb("Идти", "Go", "Went", "Gone", 0));
        verbsCollection.Add(new IrregularVerb("Расти", "Grow", "Grew", "Grown", 0));
        verbsCollection.Add(new IrregularVerb("Повесить", "Hang", "Hung", "Hung", 0));
        verbsCollection.Add(new IrregularVerb("Иметь", "Have", "Had", "Had", 0));
        verbsCollection.Add(new IrregularVerb("Слышать", "Hear", "Heard", "Heard", 0));
        verbsCollection.Add(new IrregularVerb("Прятать", "Hide", "Hid", "Hidden", 0));
        verbsCollection.Add(new IrregularVerb("Ударить", "Hit", "Hit", "Hit", 0));
        verbsCollection.Add(new IrregularVerb("Держать", "Hold", "Held", "Held", 0));
        verbsCollection.Add(new IrregularVerb("Ранить", "Hurt", "Hurt", "Hurt", 0));
        verbsCollection.Add(new IrregularVerb("Соблюдать", "Keep", "Kept", "Kept", 0));
        verbsCollection.Add(new IrregularVerb("Кланяться", "Kneel", "Knelt", "Knelt", 0));
        verbsCollection.Add(new IrregularVerb("Знать", "Know", "Knew", "Known", 0));
        verbsCollection.Add(new IrregularVerb("Лежать", "Lay", "Laid", "Laid", 0));
        verbsCollection.Add(new IrregularVerb("Вести", "Lead", "Led", "Led", 0));
        verbsCollection.Add(new IrregularVerb("Покидать","Leave", "Left", "Left", 0));
        verbsCollection.Add(new IrregularVerb("Одолжить", "Lend", "Lent", "Lent", 0));
        verbsCollection.Add(new IrregularVerb("Разрешить", "Let", "Let", "Let", 0));
        verbsCollection.Add(new IrregularVerb("Лгать", "Lie", "Lie", "Lie", 0));
        verbsCollection.Add(new IrregularVerb("Светить", "Light", "Lit", "Lit", 0));
        verbsCollection.Add(new IrregularVerb("Терять", "Lose", "Lost", "Lost", 0));
        verbsCollection.Add(new IrregularVerb("Изготовлять", "Make", "Made", "Made", 0));
        verbsCollection.Add(new IrregularVerb("Значить", "Mean", "Meant", "Meant", 0));
        verbsCollection.Add(new IrregularVerb("Встретить", "Meet", "Met", "Met", 0));
        verbsCollection.Add(new IrregularVerb("Платить", "Pay", "Paid", "Paid", 0));
        verbsCollection.Add(new IrregularVerb("Класть", "Put", "Put", "Put", 0));
        verbsCollection.Add(new IrregularVerb("Читать", "Read", "Read", "Read", 0));
        verbsCollection.Add(new IrregularVerb("Ехать Верхом", "Ride", "Rode", "Ridden", 0));
        verbsCollection.Add(new IrregularVerb("Звонить", "Ring", "Rang", "Rung", 0));
        verbsCollection.Add(new IrregularVerb("Подниматься", "Rise", "Rose", "Risen", 0));
        verbsCollection.Add(new IrregularVerb("Бежать", "Run", "Ran", "Run", 0));
        verbsCollection.Add(new IrregularVerb("Говорить", "Say", "Said", "Said", 0));
        verbsCollection.Add(new IrregularVerb("Видеть", "See", "Saw", "Seen", 0));
        verbsCollection.Add(new IrregularVerb("Болеть", "Seek", "Sought", "Sought", 0));
        verbsCollection.Add(new IrregularVerb("Продавать", "Sell", "Sold", "Sold", 0));
        verbsCollection.Add(new IrregularVerb("Посылать", "Send", "Sent", "Sent", 0));
        verbsCollection.Add(new IrregularVerb("Устанавливать", "Set", "Set", "Set", 0));
        verbsCollection.Add(new IrregularVerb("Шить", "Sew", "Sewed", "Sewn", 0));
        verbsCollection.Add(new IrregularVerb("Трятси", "Shake", "Shook", "Shaken", 0));
        verbsCollection.Add(new IrregularVerb("Блестеть", "Shine", "Shone", "Shone", 0));
        verbsCollection.Add(new IrregularVerb("Стрелять", "Shoot", "Shot", "Shot", 0));
        verbsCollection.Add(new IrregularVerb("Показывать", "Show", "Showed", "Shown", 0));
        verbsCollection.Add(new IrregularVerb("Сжиматься", "Shrink", "Shrank", "Shrunk", 0));
        verbsCollection.Add(new IrregularVerb("Захлопнуть", "Shut", "Shut", "Shut", 0));
        verbsCollection.Add(new IrregularVerb("Петь", "Sing", "Sang", "Sung", 0));
        verbsCollection.Add(new IrregularVerb("Затонуть", "Sink", "Sank", "Sunk", 0));
        verbsCollection.Add(new IrregularVerb("Сидеть", "Sit", "Sat", "Sat", 0));
        verbsCollection.Add(new IrregularVerb("Спать", "Sleep", "Slept", "Slept", 0));
        verbsCollection.Add(new IrregularVerb("Скользить", "Slide", "Slid", "Slid", 0));
        verbsCollection.Add(new IrregularVerb("Беседовать", "Speak", "Spoke", "Spoken", 0));
        verbsCollection.Add(new IrregularVerb("Проводить", "Spend", "Spent", "Spent", 0)); 
        verbsCollection.Add(new IrregularVerb("Плевать", "Spit", "Spat", "Spat", 0));
        verbsCollection.Add(new IrregularVerb("Трескаться", "Split", "Split", "Split", 0));
        verbsCollection.Add(new IrregularVerb("Распространяться", "Spread", "Spread", "Spread", 0));
        verbsCollection.Add(new IrregularVerb("Прыгать", "Spring", "Sprang", "Sprung", 0));
        verbsCollection.Add(new IrregularVerb("Стоять", "Stand", "Stood", "Stood", 0));
        verbsCollection.Add(new IrregularVerb("Красить", "Steal", "Stole", "Stolen", 0));
        verbsCollection.Add(new IrregularVerb("Клеить", "Stick", "Stuck", "Stuck", 0));
        verbsCollection.Add(new IrregularVerb("Ужалить", "Sting", "Stung", "Stung", 0));
        verbsCollection.Add(new IrregularVerb("Вонять", "Stinck", "Stank", "Stunk", 0));
        verbsCollection.Add(new IrregularVerb("Ударять", "Strike", "Stroke", "Struck", 0));
        verbsCollection.Add(new IrregularVerb("Клясться", "Swear", "Swore", "Sworn", 0));
        verbsCollection.Add(new IrregularVerb("Подметать", "Sweep", "Swept", "Swept", 0));
        verbsCollection.Add(new IrregularVerb("Плыть", "Swim", "Swam", "Swum", 0));
        verbsCollection.Add(new IrregularVerb("Качаться", "Swing", "Swung", "Swung", 0));
        verbsCollection.Add(new IrregularVerb("Брать", "Take", "Took", "Taken", 0));
        verbsCollection.Add(new IrregularVerb("Учить", "Teach", "Taught", "Taught", 0));
        verbsCollection.Add(new IrregularVerb("Рвать", "Tear", "Tore", "Torn", 0));
        verbsCollection.Add(new IrregularVerb("Говорить", "Tell", "Told", "Told", 0));
        verbsCollection.Add(new IrregularVerb("Думать", "Think", "Thought", "Thought", 0));
        verbsCollection.Add(new IrregularVerb("Кидать", "Throw", "Threw", "Thrown", 0));
        verbsCollection.Add(new IrregularVerb("Понимать", "Understand", "Understood", "Understood", 0));
        verbsCollection.Add(new IrregularVerb("Просыпаться", "Wake", "Woke", "Woken", 0));
        verbsCollection.Add(new IrregularVerb("Носить", "Wear", "Wore", "Worn", 0));
        verbsCollection.Add(new IrregularVerb("Плакать", "Weep", "Wept", "Wept", 0));
        verbsCollection.Add(new IrregularVerb("Выигрывать", "Win", "Won", "Won", 0));
        verbsCollection.Add(new IrregularVerb("Писать", "Write", "Wrote", "Written", 0));
    }
}
