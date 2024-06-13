using System;
using System.Diagnostics;

class BreathingActivity : Activity {
    public BreathingActivity(string welcome, string description, string congrats)
        : base(welcome, description, congrats) { 
    }

    public void GuideBreathing() {
        GetReady(); // Preparation phase
        var startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration) {
            Console.Write("Breathe in...");
            DisplayAnimation(); // Animation for breathing in
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b"); // Erase the last line
            Console.Write("Breathe out...");
            DisplayAnimation(); // Animation for breathing out
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"); // Erase the last line
        }
    }
}


// Copy of original code
/*
public BreathingActivity(string titleParam, string welcomeParam, string descParam, int durParam, string congratsParam) : 
    base(titleParam,welcomeParam,descParam,durParam,congratsParam)
    {
        
    } */