using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Permissions;

public class Watcher
{
    public static void Main()
    {
        //Run();
        //PleaseHold();
        PleaseAdviseandCompare();
    }

    private static void PleaseAdviseandCompare()
    {
        var listofjobbies = new List<int>() { 2420242, 2423706, 2444706, 2486103, 2486104, 2486122, 2493531, 2493532, 2493533, 2493534, 2493535, 2493536, 2493537, 2493538, 2493539, 2493541, 2499362, 2507786, 2507994, 2516791, 2519997, 2522362, 2524339, 2541458, 2541525, 2542623, 2543774, 2552525, 2557033, 2565684, 2569542, 2554921, 2575692, 2585621, 2572371, 2597652, 2600501, 2604195, 2613933, 2618573, 2634635, 2641099, 2656763, 2658880, 2666959, 2667170, 2672833, 2695819, 2696796, 2697674, 2713144, 2706760, 2703687, 2709592, 2709820, 2711837, 2712859, 2715794, 2718092, 2718239, 2719287, 2719290, 2719383, 2719384, 2719386, 2719387, 2719388, 2719390, 2719392, 2719393, 2719394, 2719397, 2719400, 2719403, 2719740, 2719753, 2719954, 2719967, 2720120, 2720450, 2722493, 2726111, 2726159, 2731160, 2733607, 2733953, 2735065, 2738874, 2741481, 2741435 };
        var listofduffjobbies = new List<int>() { 2420242, 2423706, 2444706, 2486103, 2486104, 2486122, 2493531, 2493532, 2493533, 2493534, 2493535, 2493536, 2493537, 2493538, 2493539, 2493541, 2499362, 2507786, 2507994, 2516791, 2519997, 2522362, 2524339, 2541458, 2541525, 2542623, 2543774, 2552525, 2557033, 2565684, 2569542, 2554921, 2575692, 2585621, 2572371, 2597652, 2600501, 2604195, 2613933, 2618573, 2634635, 2641099, 2656763, 2658880, 2666959, 2667170, 2672833, 2695819, 2696796, 2697674, 2713144, 2706760, 2703687, 2709592, 2709820, 2711837, 2712859, 2715794, 2718092, 2718239, 2719287, 2719290, 2719383, 2719384, 2719386, 2719387, 2719388, 2719390, 2719392, 2719393, 2719394, 2719397, 2719400, 2719403, 2719740, 2719753, 2719954, 2719967, 2720120, 2720450, 2722493, 2723138, 2726111, 2726159, 2731160, 2728204, 2728195, 2728191, 2727591, 2727587, 2727568, 2727500, 2728164, 2727617, 2728156, 2726614, 2725587, 2725585, 2725581, 2725567, 2725562, 2725560, 2725555, 2727472, 2725547, 2725534, 2725504, 2727552, 2728174, 2727550, 2728182, 2723138, 2727563, 2728186, 2728192, 2727498, 2727490, 2728178, 2728180, 2728179, 2728181, 2728200, 2728199, 2728189, 2728171, 2733607, 2733953, 2735065, 2738874, 2741481, 2741435 };

        var badjobs = new List<int>();

        foreach (var job in listofduffjobbies)
        {
            if (!listofjobbies.Contains(job))
            {
                badjobs.Add(job);
                Console.WriteLine(job);
            } 
        }


        Console.ReadLine();

    }

    private static void PleaseHold()
    {
        try
        {
            Console.WriteLine("{0}", DateTime.Parse("29/07/2019 12:00:00"));
            Console.ReadLine();

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);

        }
    }


    private static void Run()
    {
        string[] args = Environment.GetCommandLineArgs();

        // If a directory is not specified, exit program.
        if (args.Length != 2)
        {
            // Display the proper way to call the program.
            Console.WriteLine("Usage: Watcher.exe (directory)");
            return;
        }

        // Create a new FileSystemWatcher and set its properties.
        using (FileSystemWatcher watcher = new FileSystemWatcher())
        {
            watcher.Path = args[1];

            // Watch for changes in LastAccess and LastWrite times, and
            // the renaming of files or directories.
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            // Only watch text files.
            watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;

            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Press 'q' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
    }

    // Define the event handlers.
    private static void OnChanged(object source, FileSystemEventArgs e) =>
        // Specify what is done when a file is changed, created, or deleted.
        Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");

    private static void OnRenamed(object source, RenamedEventArgs e) =>
        // Specify what is done when a file is renamed.
        Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
}