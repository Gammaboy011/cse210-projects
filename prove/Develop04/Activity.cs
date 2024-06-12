using System;
using System.Reflection.Metadata;

class Activity {
    protected string _welcome; // Welcome message
    protected string _description; // Activity description
    protected int _duration; // Duration of the activity
    protected string _namActivity; // Name of the activity
    private bool _spinnerActive = false; // Flag to control spinner animation
    
    public Activity(string welcome, string description, string namActivity) {
        _welcome = welcome;
        _description = description;
        _namActivity = namActivity;
    }

    public void Start() {
        Console.WriteLine(_welcome); // Display welcome message
        Console.WriteLine(_description); // Display activity description
        Console.Write("How long would you like the activity to run (in sec.): ");
        _duration = int.Parse(Console.ReadLine()); // Read duration from user
    }

    private void Timer() {
        var startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration) {
            Thread.Sleep(1000); // Wait for the duration of the activity
        }
    }

    protected void StartSpinner() {
        _spinnerActive = true; // Start the spinner
        Task.Run(() => {
            var spinnerChars = new[] { '/', '|', '\\', '-' };
            int idx = 0;
            while (_spinnerActive) {
                Console.Write(spinnerChars[idx]);
                idx = (idx + 1) % spinnerChars.Length;
                Thread.Sleep(200); // Rotate spinner every 200ms
                Console.Write("\b"); // Erase the last character to portay the spinning illusion
            }
        });
    }

    protected void StopSpinner() {
        _spinnerActive = false; // Stop the spinner
        Console.Write("\b"); // Erase the last character
    }
    
    protected void GetReady() {
        Console.WriteLine("Get Ready...\n");
        StartSpinner(); // Start the spinner animation
        Thread.Sleep(5000); // Wait for 5 seconds
        StopSpinner(); // Stop the spinner animation
        Console.Write(""); // Create space between prep time and the activity once it starts
    }

    protected void DisplayAnimation() {
        for (int i = 7; i > 0; i--) {
            Console.Write(i);
            Thread.Sleep(1000); // Countdown timer
            Console.Write("\b"); // Erase the last character
        }
    }

    public void OnEnd() {
        Console.WriteLine($"Congrats. You practiced another {_duration} seconds of the {_namActivity}!. :)"); // Display end message
        StartSpinner(); // Start the spinner animation
        Thread.Sleep(5000); // Wait for 5 seconds
        StopSpinner(); // Stop the spinner animation
    }
}

// Copy of original code
/*
    protected string _title;
        protected string _welcome;
        protected string _desc;
        protected int _duration;
        protected string _congrats;
        //Timer.perf_counter() void;

        public Activity(string titleParam, string welcomeParam, string descParam, int durParam, string congratsParam) {
            _title = titleParam;
            _welcome = welcomeParam;
            _desc = descParam;
            _duration = durParam;
            _congrats = congratsParam;
        }
*/