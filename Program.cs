// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection;

List<string> ToDoList = new List<string>();
string[] optionsAvailable = new[] { "S", "s", "A", "a", "R", "r", "E", "e" };
showOptions();





string optionSelectedByUser()
{
    return Console.ReadLine();
}
void showOptions()
{
    Console.WriteLine("Hello!");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit!");
    
    string optionSelected = optionSelectedByUser();
    optionsToWorkWith(optionSelected);

    //if (optionsAvailable.Contains(optionSelected))
    //{
    //    optionsToWorkWith(optionSelected);
    //}

    //else
    //{
    //    showOptionsUntilCorrectChoiceSelected(optionSelected);

    //}

}

void optionsToWorkWith(string optionSelected)
{
    switch (optionSelected)
    {
        case "S":
            showToDosList();
            break;
        case "s":
            showToDosList();
            break;
        case "A":
            Console.WriteLine("Enter a ToDo description:");
            string ToDo = Console.ReadLine();
            checkToDoIsEmpty(ToDo);
            break;
        case "a":
            Console.WriteLine("Enter a ToDo description:");
            ToDo = Console.ReadLine();
            checkToDoIsEmpty(ToDo);
            break;
        case "R":
            checkToDoListIsEmpty();
            break;
        case "r":
            checkToDoListIsEmpty();
            break;
        case "E":
            Environment.Exit(0);
            break;
        case "e":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Incorrect input.");
            showOptions();
            break;
    }
}
//void showOptionsUntilCorrectChoiceSelected(string optionSelected)
//{
//    while (!optionsAvailable.Contains(optionSelected))
//    {
//        Console.WriteLine("Incorrect input.");
//        showOptions();
    
//    }
    
//}

void showToDosList()
{
    if (ToDoList.Count > 0)
    {
        int bulletPoint = 0;
        foreach (var toDo in ToDoList)
        {
            bulletPoint++;
            Console.WriteLine(bulletPoint + ". " + toDo);
        }
        showOptions();
        
    }
    else
    {
        Console.WriteLine("There are no to DOs.");
        showOptions();
        
    }
}

void checkToDoIsUnique(string ToDo)
{
    if (!ToDoList.Contains(ToDo))
    {
        addAToDo(ToDo);
    }
    else
    {
        while (ToDoList.Contains(ToDo))
        {
            Console.WriteLine("The description must be unique.");
            Console.WriteLine("Enter a ToDo description:");
            ToDo = Console.ReadLine();
        }
        checkToDoIsEmpty(ToDo);
    }

    
}

void checkToDoIsEmpty(string ToDo)
{
    if (ToDo.Length == 0)
    {
        while (ToDo.Length == 0)
        {
            Console.WriteLine("The description cannot be empty");
            Console.WriteLine("Enter a ToDo description:");
            ToDo = Console.ReadLine();
        }
        checkToDoIsUnique(ToDo);
    }
    else
    {

        checkToDoIsUnique(ToDo);


    }
}
void addAToDo(string ToDo)
{
    ToDoList.Add(ToDo);
    Console.WriteLine("ToDo successfully added: " + ToDo);
    showOptions();

}

void checkToDoListIsEmpty()
{
    if (ToDoList.Count == 0)
    {
        Console.WriteLine("There are no to DOs.");
        showOptions();
    }
    else
    {
        int bulletPoint = 0;
        foreach (var toDo in ToDoList)
        {
            bulletPoint++;
            Console.WriteLine(bulletPoint + ". " + toDo);
        }
        Console.WriteLine("Select the index of the ToDo you want to remove");
        string indexString = Console.ReadLine();
        checkIndexIsEmpty(indexString);
    }
}
void checkIndexIsEmpty(string indexString)
{
    if (indexString.Length == 0)
    {
        while (indexString.Length == 0)
        {
            Console.WriteLine("The selected index cannot be empty");
            Console.WriteLine("Select the index of the ToDo you want to remove");
            indexString = Console.ReadLine();
        }
        checkIndexIsValid(indexString);
    }
    else
    {
        checkIndexIsValid(indexString);
    }
    
}
void checkIndexIsValid(string indexString)
{
    
    bool indexIsInt = int.TryParse(indexString, out int index);

    if (indexIsInt)
    {
        removeAToDo(index);
    }
    else
    {
        Console.WriteLine("The given index is not valid.");
        while (!indexIsInt)
        {
            checkToDoListIsEmpty();
            Console.WriteLine("Select the index of the ToDo you want to remove");
            indexString = Console.ReadLine();
            indexIsInt = int.TryParse(indexString, out index);
        }

        checkIndexIsEmpty(indexString);
    }
}

void removeAToDo(int index)
{
    index--;
    if (index < ToDoList.Count)
    {
        string ToDoDescription = ToDoList[index];
        int realIndex = ToDoList.IndexOf(ToDoDescription);

        if (realIndex != -1)
        {
            Console.WriteLine("ToDo removed: " + ToDoDescription);
            ToDoList.RemoveAt(realIndex);
            showOptions();
        }
        else
        {
            Console.WriteLine("The given index does not exist.");
            Console.WriteLine("Select the index of the ToDo you want to remove");
            string nextIndex = Console.ReadLine();
            checkIndexIsEmpty(nextIndex);

        }
    }
    else
    {
        Console.WriteLine("The given index does not exist.");
        Console.WriteLine("Select the index of the ToDo you want to remove");
        string nextIndex = Console.ReadLine();
        checkIndexIsEmpty(nextIndex);
    }


}



