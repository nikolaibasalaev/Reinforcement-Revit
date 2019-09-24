#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Linq;
#endregion

namespace Reinforcement
{
    [Transaction(TransactionMode.Manual)]
    public class CreateSheet : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            View view = doc.ActiveView;
            FamilySymbol fs = null;
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(FamilySymbol));
            collector.OfCategory(BuiltInCategory.OST_TitleBlocks);

            IEnumerable<Element> titleblock = from element in collector where element.Name.Equals("A0h") select element;
            foreach (Element element in titleblock)
            {
                if (element.Name.Equals("A0h"))
                {
                    fs = element as FamilySymbol;
                }
            }
            if (fs == null)
            {
                TaskDialog.Show("Sheet", "no titleblocks");
            }


            //FamilySymbol fs = collector.FirstElement() as FamilySymbol;
            if (fs != null)
            {
                using (Transaction t = new Transaction(doc, "Create a new ViewSheet"))
                {
                    t.Start();
                    try
                    {
                        // Create a sheet view
                        ViewSheet viewSheet = ViewSheet.Create(doc, fs.Id);
                        if (null == viewSheet)
                        {
                            throw new Exception("Failed to create new ViewSheet.");
                        }

                        // Add passed in view onto the center of the sheet
                        UV location = new UV((viewSheet.Outline.Max.U - viewSheet.Outline.Min.U) / 2,
                                             (viewSheet.Outline.Max.V - viewSheet.Outline.Min.V) / 2);

                        //viewSheet.AddView(view3D, location);
                        Viewport.Create(doc, viewSheet.Id, view.Id, new XYZ(location.U, location.V, 0));

                        // Print the sheet out
                        if (viewSheet.CanBePrinted)
                        {
                            TaskDialog taskDialog = new TaskDialog("Revit");
                            taskDialog.MainContent = "Print the sheet?";
                            TaskDialogCommonButtons buttons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;
                            taskDialog.CommonButtons = buttons;
                            TaskDialogResult result = taskDialog.Show();

                            if (result == TaskDialogResult.Yes)
                            {
                                viewSheet.Print();
                            }
                        }

                        t.Commit();
                    }
                    catch
                    {
                        t.RollBack();
                    }
                }
            }

            return Result.Succeeded;
        }
    }
}
