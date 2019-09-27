#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;

#endregion

namespace Reinforcement
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            //Create Ribbon Tab

                a.CreateRibbonTab("NB");

            string path = Assembly.GetExecutingAssembly().Location;
            PushButtonData button = new PushButtonData("Button1", "Views", path, "Reinforcement.DublicateViews");

                RibbonPanel panel = a.CreateRibbonPanel("NB", "RC Drawings");
            // string pictPath = @"C:\Users\Nikolai\Google Drive\Shared\_Revit plug-in development\desk.png";
            string pictPath = @"C:\Users\nikolai.basalaev\Desktop\Goole Disk\Shared\_Revit plug-in development\desk.png";
            //Add button image
           Uri imagePath = new Uri(pictPath);
           BitmapImage image = new BitmapImage(imagePath);

            PushButton pushButton = panel.AddItem(button) as PushButton;
            pushButton.LargeImage = image;

            PushButtonData button2 = new PushButtonData("Button2", "Create Sheet", path, "Reinforcement.CreateSheet");

            //Add button image
            Uri imagePath2 = new Uri(pictPath);
            BitmapImage image2 = new BitmapImage(imagePath2);

            PushButton pushButton2 = panel.AddItem(button2) as PushButton;
            pushButton.LargeImage = image2;

            PushButtonData button3 = new PushButtonData("Button3", "Win Form Test", path, "Reinforcement.WinForm");

            //Add button image
            Uri imagePath3 = new Uri(pictPath);
            BitmapImage image3 = new BitmapImage(imagePath3);

            PushButton pushButton3 = panel.AddItem(button3) as PushButton;
            pushButton.LargeImage = image2;

            PushButtonData button4 = new PushButtonData("Button4", "Sheet Create", path, "Reinforcement.SheetCreate");

            //Add button image
            Uri imagePath4 = new Uri(pictPath);
            BitmapImage image4 = new BitmapImage(imagePath4);

            PushButton pushButton4 = panel.AddItem(button4) as PushButton;
            pushButton.LargeImage = image4;


            PushButtonData button5 = new PushButtonData("Button5", "Dublicates", path, "Reinforcement.DublicateView.DublicateViews");

            //Add button image
            Uri imagePath5 = new Uri(pictPath);
            BitmapImage image5 = new BitmapImage(imagePath4);

            PushButton pushButton5 = panel.AddItem(button5) as PushButton;
            pushButton.LargeImage = image5;


            PushButtonData button6 = new PushButtonData("Button6", "testtss", path, "Reinforcement.TestsWF.ForTests");

            //Add button image
            Uri imagePath6 = new Uri(pictPath);
            BitmapImage image6 = new BitmapImage(imagePath4);

            PushButton pushButton6 = panel.AddItem(button6) as PushButton;
            pushButton.LargeImage = image6;


            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}

