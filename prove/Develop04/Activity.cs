using System;
using System.Reflection.Metadata;

class Activity
{
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

}