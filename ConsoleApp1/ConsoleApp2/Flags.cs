﻿using System;

public class Account
{
    [Flags]
    public enum Access
    {
        Delete,
        Publish,
        Submit,
        Comment,
        Modify
    }

    enum Writer : Boolean
    {

    };

    public static void Main(string[] args)
    {
        //Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }
}