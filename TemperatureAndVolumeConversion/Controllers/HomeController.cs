using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TemperatureAndVolumeConversion.Models;

namespace TemperatureAndVolumeConversion.Controllers
{
    public class HomeController : Controller
    {
   
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        List<string> UnitsOfMeasure = new List<string>() { "Kelvin", "Celsius", "Fahrenheit", "Rankine", "liters", "tablespoons", "cubic - inches", "cups", "cubic - feet", "gallons" };       

        public ActionResult Calculate() 
        {
            CheckConversion checkConversion = new CheckConversion();
            ViewBag.UnitsOfMeasure = new SelectList(UnitsOfMeasure);           
            return View(checkConversion);
        }
        [HttpPost]
        public ActionResult Calculate(CheckConversion checkConversion)
        {
            double studentResponse = checkConversion.StudentResponse;
            ViewBag.UnitsOfMeasure = new SelectList(UnitsOfMeasure);
            CheckConversion check = new CheckConversion();
            try
            {
                // TODO: Add update logic here
                if (checkConversion.InputUnitOfMeasure == "Kelvin")
                {
                    check = Kelvin(checkConversion);
                }
                else if (checkConversion.InputUnitOfMeasure == "Celsius")
                {
                    check = Celsius(checkConversion);
                }
                else if (checkConversion.InputUnitOfMeasure == "Fahrenheit")
                {
                    check = Fahrenheit(checkConversion);
                }
                else if (checkConversion.InputUnitOfMeasure == "Rankine")
                {
                    check = Rankine(checkConversion);
                }
                else if (checkConversion.InputUnitOfMeasure == "liters")
                {
                    check = Liters(checkConversion);
                }
                else if (checkConversion.InputUnitOfMeasure == "tablespoons")
                {
                    check = TableSpoons(checkConversion);
                }
                else if (checkConversion.InputUnitOfMeasure == "cubic - inches")
                {
                    check = CubicInches(checkConversion);
                }
                else if (checkConversion.InputUnitOfMeasure == "cups")
                {
                    check = Cups(checkConversion);
                }
                else if (checkConversion.InputUnitOfMeasure == "cubic - feet")
                {
                    check = CubicFeet(checkConversion);
                }
                else if (checkConversion.InputUnitOfMeasure == "gallons")
                {
                    check = Gallons(checkConversion);
                }
                return View(check);
            }
            catch
            {
                return View();
            }
        }

        public CheckConversion Kelvin(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "Kelvin" && checkConversion.TargetUnitOfMeasure == "liters" || checkConversion.TargetUnitOfMeasure == "tablespoons" || checkConversion.TargetUnitOfMeasure == "cubic - inches" || checkConversion.TargetUnitOfMeasure == "cups" || checkConversion.TargetUnitOfMeasure == "cubic - feet" || checkConversion.TargetUnitOfMeasure == "gallons")
            {
                    checkConversion.Output = "invalid";
                    return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "Kelvin" && checkConversion.TargetUnitOfMeasure == "Kelvin")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Kelvin" && checkConversion.TargetUnitOfMeasure == "Celsius")
            {
                double inputNumber = checkConversion.InputNumericalValue - 273.15;
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Kelvin" && checkConversion.TargetUnitOfMeasure == "Fahrenheit")
            {
                double inputNumber = (checkConversion.InputNumericalValue * 1.8) - 459.67;
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Kelvin" && checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                double inputNumber = checkConversion.InputNumericalValue * 1.8;
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            return checkConversion;
        }
        public CheckConversion Celsius(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "Celsius" && checkConversion.TargetUnitOfMeasure == "liters" || checkConversion.TargetUnitOfMeasure == "tablespoons" || checkConversion.TargetUnitOfMeasure == "cubic - inches" || checkConversion.TargetUnitOfMeasure == "cups" || checkConversion.TargetUnitOfMeasure == "cubic - feet" || checkConversion.TargetUnitOfMeasure == "gallons")
            {
                checkConversion.Output = "invalid";
                return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "Celsius" && checkConversion.TargetUnitOfMeasure == "Celsius")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Celsius" && checkConversion.TargetUnitOfMeasure == "Kelvin")
            {
                double inputNumber = checkConversion.InputNumericalValue + 273.15;
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Celsius" && checkConversion.TargetUnitOfMeasure == "Fahrenheit")
            {
                double inputNumber = (checkConversion.InputNumericalValue * 1.8) + 32;
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Celsius" && checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                double inputNumber = (checkConversion.InputNumericalValue + 273.15) * 1.8;
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            return checkConversion;
        }
        public CheckConversion Fahrenheit(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "Fahrenheit" && checkConversion.TargetUnitOfMeasure == "liters" || checkConversion.TargetUnitOfMeasure == "tablespoons" || checkConversion.TargetUnitOfMeasure == "cubic - inches" || checkConversion.TargetUnitOfMeasure == "cups" || checkConversion.TargetUnitOfMeasure == "cubic - feet" || checkConversion.TargetUnitOfMeasure == "gallons")
            {
                checkConversion.Output = "invalid";
                return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "Fahrenheit" && checkConversion.TargetUnitOfMeasure == "Fahrenheit")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Fahrenheit" && checkConversion.TargetUnitOfMeasure == "Kelvin")
            {
                double inputNumber = (checkConversion.InputNumericalValue + 459.67) * (5 / 9);
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Fahrenheit" && checkConversion.TargetUnitOfMeasure == "Celsius")
            {
                double inputNumber = (checkConversion.InputNumericalValue - 32) * (5 / 9);
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Fahrenheit" && checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                double inputNumber = checkConversion.InputNumericalValue + 459.67;
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            return checkConversion;
        }
        public CheckConversion Rankine(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "Rankine" && checkConversion.TargetUnitOfMeasure == "liters" || checkConversion.TargetUnitOfMeasure == "tablespoons" || checkConversion.TargetUnitOfMeasure == "cubic - inches" || checkConversion.TargetUnitOfMeasure == "cups" || checkConversion.TargetUnitOfMeasure == "cubic - feet" || checkConversion.TargetUnitOfMeasure == "gallons")
            {
                checkConversion.Output = "invalid";
                return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "Rankine" && checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Rankine" && checkConversion.TargetUnitOfMeasure == "Kelvin")
            {
                double inputNumber = checkConversion.InputNumericalValue * (5 / 9);
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Rankine" && checkConversion.TargetUnitOfMeasure == "Celsius")
            {
                double inputNumber = (checkConversion.InputNumericalValue - 491.67) * (5 / 9);
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "Rankine" && checkConversion.TargetUnitOfMeasure == "Fahrenheit")
            {
                double inputNumber = checkConversion.InputNumericalValue - 459.67;
                inputNumber = Math.Round(inputNumber, 2);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 2);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            
            return checkConversion;
        }
        public CheckConversion Liters(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "liters" && checkConversion.TargetUnitOfMeasure == "Kelvin" || checkConversion.TargetUnitOfMeasure == "Celsius" || checkConversion.TargetUnitOfMeasure == "Fahrenheit" || checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                checkConversion.Output = "invalid";
                return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "liters" && checkConversion.TargetUnitOfMeasure == "liters")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "liters" && checkConversion.TargetUnitOfMeasure == "tablespoons")
            {
                double inputNumber = checkConversion.InputNumericalValue * 67.628;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "liters" && checkConversion.TargetUnitOfMeasure == "cubic-inches")
            {
                double inputNumber = checkConversion.InputNumericalValue * 61.024;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "liters" && checkConversion.TargetUnitOfMeasure == "cups")
            {
                double inputNumber = checkConversion.InputNumericalValue * 4.227;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "liters" && checkConversion.TargetUnitOfMeasure == "cubic-feet")
            {
                double inputNumber = checkConversion.InputNumericalValue / 28.317;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "liters" && checkConversion.TargetUnitOfMeasure == "gallons")
            {
                double inputNumber = checkConversion.InputNumericalValue / 3.785;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            return checkConversion;
        }
        public CheckConversion TableSpoons(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "tablespoons" && checkConversion.TargetUnitOfMeasure == "Kelvin" || checkConversion.TargetUnitOfMeasure == "Celsius" || checkConversion.TargetUnitOfMeasure == "Fahrenheit" || checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                checkConversion.Output = "invalid";
                return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "tablespoons" && checkConversion.TargetUnitOfMeasure == "tablespoons")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "tablespoons" && checkConversion.TargetUnitOfMeasure == "liters")
            {
                double inputNumber = checkConversion.InputNumericalValue / 67.628;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "tablespoons" && checkConversion.TargetUnitOfMeasure == "cubic-inches")
            {
                double inputNumber = checkConversion.InputNumericalValue / 1.108;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "tablespoons" && checkConversion.TargetUnitOfMeasure == "cups")
            {
                double inputNumber = checkConversion.InputNumericalValue / 16;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "tablespoons" && checkConversion.TargetUnitOfMeasure == "cubic-feet")
            {
                double inputNumber = checkConversion.InputNumericalValue / 1915;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "tablespoons" && checkConversion.TargetUnitOfMeasure == "gallons")
            {
                double inputNumber = checkConversion.InputNumericalValue / 256;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            return checkConversion;
        }
        public CheckConversion CubicInches(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "cubic-inches" && checkConversion.TargetUnitOfMeasure == "Kelvin" || checkConversion.TargetUnitOfMeasure == "Celsius" || checkConversion.TargetUnitOfMeasure == "Fahrenheit" || checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                checkConversion.Output = "invalid";
                return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-inches" && checkConversion.TargetUnitOfMeasure == "cubic-inches")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            if (checkConversion.InputUnitOfMeasure == "cubic-inches" && checkConversion.TargetUnitOfMeasure == "liters")
            {
                double inputNumber = checkConversion.InputNumericalValue / 61.024;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-inches" && checkConversion.TargetUnitOfMeasure == "tablespoons")
            {
                double inputNumber = checkConversion.InputNumericalValue * 1.108;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-inches" && checkConversion.TargetUnitOfMeasure == "cups")
            {
                double inputNumber = checkConversion.InputNumericalValue / 14.438;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-inches" && checkConversion.TargetUnitOfMeasure == "cubic-feet")
            {
                double inputNumber = checkConversion.InputNumericalValue / 1728;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-inches" && checkConversion.TargetUnitOfMeasure == "gallons")
            {
                double inputNumber = checkConversion.InputNumericalValue / 231;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            return checkConversion;
        }
        public CheckConversion Cups(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "cups" && checkConversion.TargetUnitOfMeasure == "Kelvin" || checkConversion.TargetUnitOfMeasure == "Celsius" || checkConversion.TargetUnitOfMeasure == "Fahrenheit" || checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                checkConversion.Output = "invalid";
                return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "cups" && checkConversion.TargetUnitOfMeasure == "cups")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cups" && checkConversion.TargetUnitOfMeasure == "liters")
            {
                double inputNumber = checkConversion.InputNumericalValue / 4.227;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cups" && checkConversion.TargetUnitOfMeasure == "tablespoons")
            {
                double inputNumber = checkConversion.InputNumericalValue * 16;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cups" && checkConversion.TargetUnitOfMeasure == "cubic-inches")
            {
                double inputNumber = checkConversion.InputNumericalValue * 14.438;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cups" && checkConversion.TargetUnitOfMeasure == "cubic-feet")
            {
                double inputNumber = checkConversion.InputNumericalValue / 120;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cups" && checkConversion.TargetUnitOfMeasure == "gallons")
            {
                double inputNumber = checkConversion.InputNumericalValue / 16;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            return checkConversion;
        }
        public CheckConversion CubicFeet(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "cubic-feet" && checkConversion.TargetUnitOfMeasure == "Kelvin" || checkConversion.TargetUnitOfMeasure == "Celsius" || checkConversion.TargetUnitOfMeasure == "Fahrenheit" || checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                checkConversion.Output = "invalid";
                return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-feet" && checkConversion.TargetUnitOfMeasure == "cubic-feet")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-feet" && checkConversion.TargetUnitOfMeasure == "liters")
            {
                double inputNumber = checkConversion.InputNumericalValue * 28.317;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-feet" && checkConversion.TargetUnitOfMeasure == "tablespoons")
            {
                double inputNumber = checkConversion.InputNumericalValue * 1915;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-feet" && checkConversion.TargetUnitOfMeasure == "cubic-inches")
            {
                double inputNumber = checkConversion.InputNumericalValue * 1728;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-feet" && checkConversion.TargetUnitOfMeasure == "cups")
            {
                double inputNumber = checkConversion.InputNumericalValue / 120;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "cubic-feet" && checkConversion.TargetUnitOfMeasure == "gallons")
            {
                double inputNumber = checkConversion.InputNumericalValue * 7.481;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            return checkConversion;
        }
        public CheckConversion Gallons(CheckConversion checkConversion) 
        {
            if (checkConversion.InputUnitOfMeasure == "gallons" && checkConversion.TargetUnitOfMeasure == "Kelvin" || checkConversion.TargetUnitOfMeasure == "Celsius" || checkConversion.TargetUnitOfMeasure == "Fahrenheit" || checkConversion.TargetUnitOfMeasure == "Rankine")
            {
                checkConversion.Output = "invalid";
                return checkConversion;
            }
            else if (checkConversion.InputUnitOfMeasure == "gallons" && checkConversion.TargetUnitOfMeasure == "gallons")
            {
                if (checkConversion.InputNumericalValue == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "gallons" && checkConversion.TargetUnitOfMeasure == "liters")
            {
                double inputNumber = checkConversion.InputNumericalValue * 3.785;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "gallons" && checkConversion.TargetUnitOfMeasure == "tablespoons")
            {
                double inputNumber = checkConversion.InputNumericalValue * 256;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "gallons" && checkConversion.TargetUnitOfMeasure == "cubic-inches")
            {
                double inputNumber = checkConversion.InputNumericalValue * 231;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "gallons" && checkConversion.TargetUnitOfMeasure == "cups")
            {
                double inputNumber = checkConversion.InputNumericalValue * 16;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            else if (checkConversion.InputUnitOfMeasure == "gallons" && checkConversion.TargetUnitOfMeasure == "cubic-feet")
            {
                double inputNumber = checkConversion.InputNumericalValue / 7.481;
                inputNumber = Math.Round(inputNumber, 5);
                checkConversion.StudentResponse = Math.Round(checkConversion.StudentResponse, 5);
                if (inputNumber == checkConversion.StudentResponse)
                {
                    checkConversion.Output = "correct";
                    return checkConversion;
                }
                else
                {
                    checkConversion.Output = "incorrect";
                    return checkConversion;
                }
            }
            return checkConversion;
        }
    }
}