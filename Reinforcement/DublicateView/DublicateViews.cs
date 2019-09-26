#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Collections;
using System.Xml;

using Autodesk.Revit;
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
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class DublicateViews : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Transaction newTran = null;
            try
            {
                if (null == commandData)
                {
                    throw new ArgumentNullException("commandData");
                }

                Document doc = commandData.Application.ActiveUIDocument.Document;
                ViewDubl view = new ViewDubl(doc);
                Autodesk.Revit.DB.View viewcur = doc.ActiveView;

                newTran = new Transaction(doc);
                newTran.Start("SheetCreate");

                Reinforcement.DublicateView.DublicateViewsForm dlg = new Reinforcement.DublicateView.DublicateViewsForm(view);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    view.DublicateView(doc);
                }
                newTran.Commit();

                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception e)
            {
                message = e.Message;
                if ((newTran != null) && newTran.HasStarted() && !newTran.HasEnded())
                    newTran.RollBack();
                return Autodesk.Revit.UI.Result.Failed;
            }
        }


#endregion IExternalCommand Members Implementation
    }
    public class ViewDubl
    {
        private string m_curViewName;

    }
    public string curViewName
    {
        get
        {
            return m_curViewName;
        }
        set
        {
            m_curViewName = value;
        }
    }

    public ViewDubl(Document doc)
    {
        //GetAllViews(doc);
       // GetTitleBlocks(doc);
    }

    public void DublicateView(Document doc)
    {
        Autodesk.Revit.DB.View viewcur = doc.ActiveView;
        if (null == doc)
        {
            throw new ArgumentNullException("doc");
        }

        if (null == viewcur)
        {
            throw new InvalidOperationException("No view be selected, generate sheet be canceled.");
        }
        ViewSheet sheet = ViewSheet.Create(doc, m_titleBlock.Id);
        sheet.Name = SheetName;
        PlaceView(viewcur, sheet);
    }




    /*

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
    }*/
}
