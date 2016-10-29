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
        
        double seen;
        string percentageStr;
        
        bool definitionInView = false;

        List<string> keyValues = new List<string>(); //constructs the list that holds the keys of our dictionary
        List<string> values = new List<string>(); // constructs the list that hold the values of our dictionary

        List<string> usedKeys = new List<string>(); //constructs the list that holds used keys
        List<string> usedValues = new List<string>(); // constructs the list that holds used values


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
            flashCards.Add("as", "The as operator is like a cast operation. However, if the conversion isn't possible, as returns null instead of raising an exception.");
            flashCards.Add("bool", "The bool keyword is an alias of System.Boolean. It is used to declare variables to store the Boolean values, true and false.");
            flashCards.Add("break", "The break statement terminates the closest enclosing loop or switch statement in which it appears. Control is passed to the statement that follows the terminated statement, if any.");
            flashCards.Add("byte", "The byte keyword denotes an integral type that stores values as an 8-bit unsigned integer.");
            flashCards.Add("case", "A keyword used in a Switch statement. Each case label specifies a constant value. ");
            flashCards.Add("catch", "A keyword that defines a clause which specifies handlers for different exceptions.");
            flashCards.Add("char", "The char keyword is used to declare an instance of the System.Char structure that the .NET Framework uses to represent a Unicode character. The value of a Char object is a 16-bit numeric (ordinal) value.");
            flashCards.Add("checked", "The checked keyword is used to explicitly enable overflow checking for integral-type arithmetic operations and conversions.");
            flashCards.Add("class", "Classes are declared using the keyword class.");
            flashCards.Add("continue", "The continue statement passes control to the next iteration of the enclosing while, do, for, or foreach statement in which it appears.");
            flashCards.Add("decimal", "The decimal keyword indicates a 128-bit data type. Compared to floating-point types, the decimal type has more precision and a smaller range, which makes it appropriate for financial and monetary calculations. ");
            flashCards.Add("default", "The default keyword can be used in the switch statement or in generic code. When used in a switch statement it specifies the default label. In generic code it specifies the default value of the type parameter.");
            flashCards.Add("delegate", "A delegate is a reference type that can be used to encapsulate a named or an anonymous method.");
            flashCards.Add("do", "The do statement executes a statement or a block of statements repeatedly until a specified expression evaluates to false.");
            flashCards.Add("double", "The double keyword signifies a simple type that stores 64-bit floating-point values.");
            flashCards.Add("enum", "The enum keyword is used to declare an enumeration, a distinct type that consists of a set of named constants called the enumerator list.");
            flashCards.Add("explicit", "The explicit keyword declares a user-defined type conversion operator that must be invoked with a cast. If a conversion operation can cause exceptions or lose information, you should mark it explicit.");
            flashCards.Add("extern", "The extern modifier is used to declare a method that is implemented externally.");
            flashCards.Add("try", "The try block contains guarded code that may cause an exception. ");
            flashCards.Add("finally", "By using a finally block, you can clean up any resources that are allocated in a try block, and you can run code even if an exception occurs in the try block.");
            flashCards.Add("fixed", "The fixed statement prevents the garbage collector from relocating a movable variable. ");
            flashCards.Add("float", "The float keyword signifies a simple type that stores 32-bit floating-point values.");
            flashCards.Add("for", "By using a for loop, you can run a statement or a block of statements repeatedly until a specified expression evaluates to false. ");
            flashCards.Add("foreach", "The foreach statement repeats a group of embedded statements for each element in an array or an object collection that implements the System.Collections.IEnumerable or System.Collections.Generic.IEnumerable<T> interface. ");
            flashCards.Add("goto", "The goto statement transfers the program control directly to a labeled statement. A common use of goto is to transfer control to a specific switch-case label or the default label in a switch statement.");
            flashCards.Add("implicit", "The implicit keyword is used to declare an implicit user-defined type conversion operator. Use it to enable implicit conversions between a user-defined type and another type, if the conversion is guaranteed not to cause a loss of data.");
            flashCards.Add("in (generic modifier)", "For generic type parameters, the in keyword specifies that the type parameter is contravariant. You can use the in keyword in generic interfaces and delegates.");
            flashCards.Add("readonly", "The readonly keyword is a modifier that you can use on fields. When a field declaration includes a readonly modifier, assignments to the fields introduced by the declaration can only occur as part of the declaration or in a constructor in the same class.");
            flashCards.Add("ref", "The ref keyword causes an argument to be passed by reference, not by value.");
            flashCards.Add("return", "The return statement terminates execution of the method in which it appears and returns control to the calling method. It can also return an optional value. If the method is a void type, the return statement can be omitted.");
            flashCards.Add("sbyte", "The sbyte keyword indicates an integral type that stores values that are signed 8-bit integers and are in the range of -128 to 127");
            flashCards.Add("short", "The short keyword denotes an integral data type that stores values that are signed 16-bit integers and are in the range of -32,768 to 32,767");
            flashCards.Add("sizeof", "Used to obtain the size in bytes for an unmanaged type.");
            flashCards.Add("stackalloc", "The stackalloc keyword is used in an unsafe code context to allocate a block of memory on the stack.");
            flashCards.Add("string", "The string type represents a sequence of zero or more Unicode characters. It is a reference type.");
            flashCards.Add("switch", "The switch statement is a control statement that selects a switch section to execute from a list of candidates.");
            flashCards.Add("throw", "The throw statement is used to signal the occurrence of an anomalous situation (exception) during the program execution.");
            flashCards.Add("typeof", "Used to obtain the System.Type object for a type.");
            flashCards.Add("uint", "The uint keyword signifies an integral type that stores values that are Unsigned 32 bit integers and that are in the range of 0 to 4,294,967,295.");
            flashCards.Add("ulong", "The ulong keyword denotes an integral type that stores values that are Unsigned 64 bit integers and that are in the range of 0 to 18,446,744,073,709,551,615.");
            flashCards.Add("unchecked", "The unchecked keyword is used to suppress overflow-checking for integral-type arithmetic operations and conversions.");
            flashCards.Add("unsafe", "The unsafe keyword denotes an unsafe context, which is required for any operation involving pointers.");
            flashCards.Add("ushort", "The ushort keyword indicates an integral data type that stores values that are Unsigned 16 bit integers that are in the range of 0 to 65,535.");
            flashCards.Add("using", "The using keyword has two major uses: As a directive (when it is used to create an alias for a namespace or to import types defined in other namespaces) and as a statement (when it defines a scope at the end of which an object will be disposed).");
            flashCards.Add("void", "When used as the return type for a method, void specifies that the method doesn't return a value.");
            flashCards.Add("volatile", "The volatile keyword indicates that a field might be modified by multiple threads that are executing at the same time. Fields that are declared volatile are not subject to compiler optimizations that assume access by a single thread.");
            flashCards.Add("while", "The while statement executes a statement or a block of statements until a specified expression evaluates to false.");

            //these are contextual keywords
            flashCards.Add("add", "The add contextual keyword is used to define a custom event accessor that is invoked when client code subscribes to your event.");
            flashCards.Add("alias", "By using an external assembly alias, the namespaces from each assembly can be wrapped inside root-level namespaces named by the alias, which enables them to be used in the same file.");
            flashCards.Add("ascending", "The ascending contextual keyword is used in the orderby clause in query expressions to specify that the sort order is from smallest to largest. ");
            flashCards.Add("await", "The await operator is applied to a task in an asynchronous method to suspend the execution of the method until the awaited task completes.");
            flashCards.Add("descending", "The descending contextual keyword is used in the orderby clause in query expressions to specify that the sort order is from largest to smallest.");
            flashCards.Add("dynamic", "The dynamic type enables the operations in which it occurs to bypass compile-time type checking.");
            flashCards.Add("from", "The from clause specifies the following: The data source on which the query or sub - query will be run and a local range variable that represents each element in the source sequence.");
            flashCards.Add("get", "The get keyword defines an accessor method in a property or indexer that retrieves the value of the property or the indexer element. ");
            flashCards.Add("global", "The global contextual keyword, when it comes before the '::' operator, refers to the global namespace, which is the default namespace for any C# program and is otherwise unnamed.");
            flashCards.Add("group", "The group clause returns a sequence of IGrouping<TKey, TElement> objects that contain zero or more items that match the key value for the group. ");
            flashCards.Add("into", "The into contextual keyword can be used to create a temporary identifier to store the results of a group, join or select clause into a new identifier. ");
            flashCards.Add("join", "The join clause is useful for associating elements from different source sequences that have no direct relationship in the object model. ");
            flashCards.Add("let", "In a query expression, it is sometimes useful to store the result of a sub-expression in order to use it in subsequent clauses. You can do this with the let keyword, which creates a new range variable and initializes it with the result of the expression you supply.");
            flashCards.Add("orderby", "In a query expression, the orderby clause causes the returned sequence or subsequence (group) to be sorted in either ascending or descending order.");
            flashCards.Add("partial (type)", "Partial type definitions allow for the definition of a class, struct, or interface to be split into multiple files.");
            flashCards.Add("partial (method)", "A partial method has its signature defined in one part of a partial type, and its implementation defined in another part of the type.");
            flashCards.Add("remove", "The remove contextual keyword is used to define a custom event accessor that is invoked when client code unsubscribes from your event.");
            flashCards.Add("select", "In a query expression, the select clause specifies the type of values that will be produced when the query is executed.");
            flashCards.Add("set", "The set keyword defines an accessor method in a property or indexer that assigns the value of the property or the indexer element. ");
            flashCards.Add("value", "The contextual keyword value is used in the set accessor in ordinary property declarations. It is similar to an input parameter on a method. The word value references the value that client code is attempting to assign to the property.");
            flashCards.Add("var", "Variables that are declared at method scope can have an implicit type var. An implicitly typed local variable is strongly typed just as if you had declared the type yourself, but the compiler determines the type. ");
            flashCards.Add("yield", "When you use the yield keyword in a statement, you indicate that the method, operator, or get accessor in which it appears is an iterator.");
            flashCards.Add("where (type constraint)", "In a generic type definition, the where clause is used to specify constraints on the types that can be used as arguments for a type parameter defined in a generic declaration.");
            flashCards.Add("where (query)", "The where clause is used in a query expression to specify which elements from the data source will be returned in the query expression. ");


            //populates all the keys into a collection
            ICollection keyCollection = flashCards.Keys;
            ICollection valueCollection = flashCards.Values;

            //iterates through the key collection and populates the key List
            foreach (object o in keyCollection)
            {
                this.keyValues.Add(o.ToString());
            }

            //iterates through the value collection and populates the value list
            foreach (object o in valueCollection) 
            {
                this.values.Add(o.ToString());
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
            //checks to see if unused list is populated
            if (keyValues.Count < 1)
            {
                string hailTabor = "End of List. Hail Tabor!";
                this.keywordTextBlock.Text = hailTabor;

                string alert = "Click random keyword below to begin again.";
                this.textBlock.Text = alert;

                //resets these varibles to initial values in order to restart
                seen = 0.00;
                percentageStr = "";

                // deep copies used key list to unused key list and empties used key list
                keyValues.AddRange(usedKeys);
                for (int i = 0; i < usedKeys.Count; i++)
                {
                    usedKeys.Remove(usedKeys[i]);
                }

                //deep copies used value list to value list and empties used value list
                values.AddRange(usedValues);
                for (int i = 0; i < usedValues.Count; i++)
                {
                    usedValues.Remove(usedValues[i]);
                }
            }

            else
            {

                randomIndex = RandomNumberMaker(); //creates a random index
                this.randomKey = keyValues[randomIndex].ToString(); //assigns a random key to the randomKey variable 
                this.randomValue = values[randomIndex].ToString(); //assigns a random value to the randomValue variable

                this.textBlock.Text = randomValue; //assigns the randomValue to the value textblock
                usedValues.Add(randomValue); //add used value to the usedValues list
                values.Remove(randomValue); //removes values from the unused value list

                this.keywordTextBlock.Text = randomKey; //assigns the randomKey to the keyword textblock
                usedKeys.Add(randomKey); //add used key to the usedKeys list
                keyValues.Remove(randomKey); //removes values from the unused key list

                //shows user percentage of keywords complete
                seen += 1.00;
                double percentage = (seen / flashCards.Count) * 100.00;
                percentageStr = string.Format("{0}%", Math.Round(percentage));
                percentageCorrectBlock.Text = percentageStr;
                

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





