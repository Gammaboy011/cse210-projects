using System;
using System.Reflection.Metadata;
class Activity
{
    protected int _duration;
    protected string _title;
    protected string _desc;

    public Activity(int durParam, string titleParam, string descParam) {
        _duration = durParam;
        _title = titleParam;
        _desc = descParam;
    }

}