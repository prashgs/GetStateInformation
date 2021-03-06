﻿using GetStateInformation.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetStateInformation
{
    //Add a using directive for System if the directive isn't already present.

    public class MainClass
    {
        public static void Main(string[] args)
        {
            const string url = @"http://services.groupkt.com/state/get/USA/all";
            string inputString = string.Empty;
            do
            {
                Console.WriteLine("Please enter a state or its abbreviation( or Type 'x' to quit): ");
                inputString = Console.ReadLine().Trim();
                switch (inputString)
                {
                    case "X":
                        break;
                    case "x":
                        break;
                    default:
                        StateRequest request = new StateRequest();
                        request.submitRequest(url);
                        request.GetCapitalLargestCity(inputString);
                        break;
                }
            }
            while (string.Compare(inputString, "x", ignoreCase: true)!=0);
        }
    }

    // If 3 is entered on command line, the
    // output reads: The factorial of 3 is 6.
}
