// See https://aka.ms/new-console-template for more information

using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Welcome to the To Do List Program!");

//Creating list to store tasks
List<string> taskList = new List<string>();

//Initialising variable before getting the user's input
string option = "";

//The program should loop until the exit option is selected
while (option != "e")
{

    //Displaying the Options Selection Menu for the user to choose. 
    options: //This is a label. It is necessary to bring the user back to Selection Menu if the task list is empty.
    Console.WriteLine("\nWhat would you like to do?");
    Console.WriteLine("Enter 1 to add a task to the list.");
    Console.WriteLine("Enter 2 to remove a task from the list.");
    Console.WriteLine("Enter 3 to view the list.");
    Console.WriteLine("Enter e to exit the program.\n");

    //Input from the user
    option = Console.ReadLine();


    if (option == "1") // Add item
    {
        Console.WriteLine("Enter the name of the task to be added to the list.");
        
        emptyOrNullCheck://This is a label. It is necessary to make the user enter a value without leaving it blank.
        string task = Console.ReadLine(); //Input from user
        
        if(string.IsNullOrEmpty(task))
        {
            Console.WriteLine("Kindly Enter your task.");
            goto emptyOrNullCheck; // This goto option is used to take the user back to enter the String
        }
        taskList.Add(task);
        Console.WriteLine("Task added to list.");
    }


    else if (option == "2") // Remove item
    {
        if (taskList.Count == 0) // condition to check if TaskList is empty 
        {
            Console.WriteLine("Task List is empty, try adding some tasks");
            goto options; // This goto option is used to take the user back to the option selection menu

         } else { 
            for (int i = 0; i < taskList.Count; i++)
            {
                Console.WriteLine(i + " : " + taskList[i]);
            }
            Console.WriteLine("Please enter the number of the task to remove.");
        }

        
            
        int rangeCheck = 0; // This value will make sure that the below while loop will continue to work until the correct value
        //is entered

        //Once the condition above is passed then the while loop should start 
        while (rangeCheck != 1)
        {
            int taskNumber = Convert.ToInt32(Console.ReadLine()); //All inputs are strings, so the string is converted to number here
            
            //If the task number is above or below the number of tasks, then the user should be prompted to enter the suitable number
            if (taskNumber > taskList.Count-1 || taskNumber < 0)
            {
                Console.WriteLine("Task number out of range, please try again");
                rangeCheck = 0;
            }
            else
            {
                taskList.RemoveAt(taskNumber);
                Console.WriteLine("Task Is Removed from the List");
                rangeCheck = 1;
            }
        }

        //taskList.RemoveAt(taskNumber);

    }
    else if (option == "3") // View the list of tasks
    {
        Console.WriteLine("The tasks in the to do list : ");

        for (int i = 0; i < taskList.Count; i++)
        {
            Console.WriteLine(taskList[i]);
        }
    }

    else if (option == "e") // Exit
    {
        Console.WriteLine("Thank you for using the To Do List program.");
        Environment.Exit(-1); // To close console application
    }
    else // Incorrect input
    {
        Console.WriteLine("Invalid option, please try again.");
    }
}

