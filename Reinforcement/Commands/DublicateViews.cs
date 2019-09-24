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
    public class DublicateViews : IExternalCommand
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
            ElementId newViewId = ElementId.InvalidElementId;
            View newView = null;
            ParameterFilterElement filter = null;
            FilteredElementCollector coll = new FilteredElementCollector(doc).OfClass(typeof(ParameterFilterElement));
            string topRebarFilter = "Rebar Layer Top";
            string bottomRebarFilter = "Rebar Layer Bottom";

            // Modify document within a transaction

            using (Transaction t = new Transaction(doc, "Apply Filter"))
            {
                t.Start();
                // create copyes of views
                newViewId = view.Duplicate(ViewDuplicateOption.Duplicate);
                newView = view.Document.GetElement(newViewId) as View;

                IEnumerable<Element> paramFilters = from element in coll where element.Name.Equals(topRebarFilter) select element;
                foreach (Element element in paramFilters)
                {
                    if (element.Name.Equals(topRebarFilter))
                    {
                        filter = element as ParameterFilterElement;
                    }
                }
                OverrideGraphicSettings ogs = new OverrideGraphicSettings();
                try
                {
                    newView.SetFilterOverrides(filter.Id, ogs);
                    newView.SetFilterVisibility(filter.Id, false);
                }
                catch { }
            


                //newView.Name = "Reinforcement top";
                newView.Name = newView.Name + "-Reinforcement top";
                newViewId = view.Duplicate(ViewDuplicateOption.Duplicate);
                newView = view.Document.GetElement(newViewId) as View;
                newView.Name = newView.Name + "-Reinforcement bottom";

                paramFilters = from element in coll where element.Name.Equals(bottomRebarFilter) select element;
                foreach (Element element in paramFilters)
                {
                    if (element.Name.Equals(bottomRebarFilter))
                    {
                        filter = element as ParameterFilterElement;
                    }
                }
                try
                {
                    newView.SetFilterOverrides(filter.Id, ogs);
                    newView.SetFilterVisibility(filter.Id, false);
                }
                catch { }
                t.Commit();
            }

            return Result.Succeeded;
        }
    }
}
