using DoubleList;

var list = new DoublyLinkedList<string>();
var answer = "1";

while (answer != "0")
{
    Console.WriteLine("\n=== Color List Menu ===");
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show backward");
    Console.WriteLine("4. Sort descending");
    Console.WriteLine("5. Show mode(s)");
    Console.WriteLine("6. Show chart");
    Console.WriteLine("7. Exists");
    Console.WriteLine("8. Remove first occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    answer = Console.ReadLine() ?? "0";

    switch (answer)
    {
        case "1":
            Console.Write("Enter a color: ");
            var color = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(color))
            {
                list.Add(color);
                Console.WriteLine($"'{color}' added.");
            }
            break;
        case "2":
            Console.Write("Forward: ");
            list.ShowForward();
            break;
        case "3":
            Console.Write("Backward: ");
            list.ShowBackward();
            break;
        case "4":
            list.SortDescending();
            Console.WriteLine("List sorted descending.");
            list.ShowForward();
            break;
        case "5":
            list.ShowModes();
            break;
        case "6":
            list.ShowChart();
            break;
        case "7":
            Console.Write("Enter a color to search: ");
            var search = Console.ReadLine() ?? string.Empty;
            Console.WriteLine(list.Exists(search) ? $"'{search}' exists." : $"'{search}' does not exist.");
            break;
        case "8":
            Console.Write("Enter a color to remove (first occurrence): ");
            var rem1 = Console.ReadLine() ?? string.Empty;
            list.RemoveFirst(rem1);
            break;
        case "9":
            Console.Write("Enter a color to remove (all occurrences): ");
            var remAll = Console.ReadLine() ?? string.Empty;
            list.RemoveAll(remAll);
            break;
        case "0":
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}