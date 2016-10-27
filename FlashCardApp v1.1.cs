using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Specialized;
using System.Collections;


namespace MSSAFlashCardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string randomKey;
        string randomValue;
        int randomIndex;
        bool definitionInView = false;
        List<string> keyValues = new List<string>(); //constructs the list that holds the keys of our dictionary


        //dictionary object that hold keywords and keyword descriptions that will be displayed in card window
        OrderedDictionary flashCards = new OrderedDictionary();


        public MainWindow()
        {
            InitializeComponent();

            //population of Ordered Dictionary containing keywords as Keys and definitions as Values
            //move to new project that solely contains dictionary and then link source code with dictionary
            flashCards.Add("sealed", "When applied to a class, the sealed modifier prevents other classes from inheriting from it. ");
            flashCards.Add("protected (Access Modifier)", "The type or member can be accessed only by code in the same class or struct, or in a class that is derived from that class.");
            flashCards.Add("static", "Use the static modifier to declare a static member, which belongs to the type itself rather than to a specific object. The static modifier can be used with classes, fields, methods, properties, operators, events, and constructors, but it cannot be used with indexers, destructors, or types other than classes.");
            flashCards.Add("internal (Access Modifier)", " Internal types or members are accessible only within files in the same assembly.");
            flashCards.Add("private (Access Modifier)", "Access is limited to the containing type.");
            flashCards.Add("public (Access Modifier)", "Access is not restricted.");
            flashCards.Add("protected internal (Access Modifier)", "Access is limited to the current assembly or types derived from the containing class.");
            flashCards.Add("abstract", "Use the abstract modifier in a class declaration to indicate that a class is intended only to be a base class of other classes. Members marked as abstract, or included in an abstract class, must be implemented by classes that derive from the abstract class.");
            flashCards.Add("async", "Use the async modifier to specify that a method, lambda expression, or anonymous method is asynchronous.");
            flashCards.Add("const", "You use the const keyword to declare a constant field or a constant local.");
            flashCards.Add("event", "The event keyword is used to declare an event in a publisher class.");
            flashCards.Add("override", "The override modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.");
            flashCards.Add("virtual", "The virtual keyword is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class.");
            flashCards.Add("struct", " A value type that is typically used to encapsulate small groups of related variables.");
            flashCards.Add("base", "A keyword that is used to access members of the base class from within a derived class.");
            flashCards.Add("this", "The this keyword refers to the current instance of the class and is also used as a modifier of the first parameter of an extension method.");
            flashCards.Add("params", "By using the params keyword, you can specify a method parameter that takes a variable number of arguments.");
            flashCards.Add("out", "The out keyword causes arguments to be passed by reference. ");

            //populates all the keys into a collection
            ICollection keyCollection = flashCards.Keys;

            //iterates through the key collection and populates the key List
            foreach (object o in keyCollection)
            {
                this.keyValues.Add(o.ToString());
            }
        }

            //method that generates a random number and assigns it to the global variable randomIndex
        private int RandomNumberMaker()
        {
            Random r = new Random();
            randomIndex = r.Next(0, keyValues.Count);
            return randomIndex;
        }

        //handles button click. This handler calls our RandomNumberMaker function and and sets our labels to keys and values from our dictionary
        private void button_Click(object sender, RoutedEventArgs e)
        {
            randomIndex = RandomNumberMaker();
            this.randomKey = keyValues[randomIndex].ToString();
            this.randomValue = flashCards[randomIndex].ToString();
            this.textBlock.Text = randomValue;
            this.keywordTextBlock.Text = randomKey;

            if (!viewDefinitionButton.IsVisible)
            {
                viewDefinitionButton.Visibility = Visibility.Visible;
            }

            if (definitionInView == true)
            {
                this.textBlock.Visibility = Visibility.Hidden;
                definitionInView = false;
            }
        }

        private void viewDefinitionButton_Click(object sender, RoutedEventArgs e)
        {
            if (definitionInView == false)
            {
                definitionInView = true;
                this.textBlock.Visibility = Visibility.Visible;
            }
            

        }
    }
 }





