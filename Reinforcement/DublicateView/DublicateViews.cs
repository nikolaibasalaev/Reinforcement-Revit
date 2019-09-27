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

namespace Reinforcement.DublicateView
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class DublicateViews : IExternalCommand
    {
        // Private Members
        Autodesk.Revit.UI.UIApplication m_revit = null;    // application of Revit
        bool m_topRebarView;
        bool m_bottomRebarView;
        bool m_topAddRebarView;
        bool m_bottomAddRebarView;
        string m_currentViewName;
        ParameterFilterElement f_topRebarView = null;
        ParameterFilterElement f_bottomRebarView = null;
        ParameterFilterElement f_topAddRebarView = null;
        ParameterFilterElement f_bottomAddRebarView = null;

        public bool topRebarView
        {
            get
            {
                return m_topRebarView;
            }
            set
            {
                m_topRebarView = value;
            }
        }

        public bool bottomRebarView
        {
            get
            {
                return m_bottomRebarView;
            }
            set
            {
                m_bottomRebarView = value;
            }
        }

        public bool topAddRebarView
        {
            get
            {
                return m_topAddRebarView;
            }
            set
            {
                m_topAddRebarView = value;
            }
        }

        public bool bottomAddRebarView
        {
            get
            {
                return m_bottomAddRebarView;
            }
            set
            {
                m_bottomAddRebarView = value;
            }
        }

        public string currentViewName
        {
            get
            {
                return m_currentViewName;
            }
            set
            {
                m_currentViewName = value;
            }
        }

        public DublicateViews()
        {
            topRebarView = true;
            bottomRebarView = true;
            topAddRebarView = true;
            bottomAddRebarView = true;
        }
        #region IExternalCommand Members Implementation
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            Autodesk.Revit.UI.UIApplication revit = commandData.Application;
            UIDocument project = revit.ActiveUIDocument;

            // Application app = uiapp.Application;
            Document doc = project.Document;

            // Show the dialog for the user select the wall style
            using (DublicateViewsForm displayForm = new DublicateViewsForm(this))
            {
                if (DialogResult.OK != displayForm.ShowDialog())
                {
                    return Autodesk.Revit.UI.Result.Failed;
                }
            }

            // If everything goes right, return succeeded.
            return Autodesk.Revit.UI.Result.Succeeded;
        }

        #endregion IExternalCommand Members Implementation

        Boolean CreateCopy(Autodesk.Revit.UI.UIDocument project, ParameterFilterElement filter) //select filters (or create them)
        {
            //search filters
            //ParameterFilterElement filter = null;
           // FilteredElementCollector coll = new FilteredElementCollector(project.Document).OfClass(typeof(ParameterFilterElement));
           // string topRebarFilter = "Rebar Layer Top";
           // string bottomRebarFilter = "Rebar Layer Bottom";

            return true;
        }

        Boolean CreateFilters(Autodesk.Revit.UI.UIDocument project) //select filters (or create them)
        {
           // FilteredElementCollector coll = new FilteredElementCollector(project.Document).OfClass(typeof(ParameterFilterElement));
            string topRebarFilter = "Rebar Layer Top";
            string bottomRebarFilter = "Rebar Layer Bottom";
            string topAddRebarFilter = "Rebar Layer Top Add";
            string bottomAddRebarFilter = "Rebar Layer Bottom Add";

            /*
             ParameterFilterElement f_topRebarView = null;
        ParameterFilterElement f_bottomRebarView = null;
        ParameterFilterElement f_topAddRebarView = null;
        ParameterFilterElement f_bottomAddRebarView = null;
             * */
            IEnumerable<Element> filters = new FilteredElementCollector(project.Document).OfClass(typeof(ParameterFilterElement)).ToElements();
            //List<ElementId> categories = new List<ElementId>();
            //categories.Add(new ElementId(BuiltInCategory.OST_Rebar));
           // List<FilterRule> filterRules = new List<FilterRule>();
            foreach (Element element in filters)
            {
                if (element.Name.Equals(topRebarFilter))
                {
                    f_topRebarView = element as ParameterFilterElement;
                }
                else { }//create new filter
                if (element.Name.Equals(bottomRebarFilter))
                {
                    f_bottomRebarView = element as ParameterFilterElement;
                }
                else { }//create new filter
                if (element.Name.Equals(topAddRebarFilter))
                {
                    f_topAddRebarView = element as ParameterFilterElement;
                }
                else { }//create new filter
                if (element.Name.Equals(bottomAddRebarFilter))
                {
                    f_bottomAddRebarView = element as ParameterFilterElement;
                }
            }

            return true;
        }

            public void CreateDublicate(Document doc, string filtername)
            {
                Autodesk.Revit.DB.View viewcur = doc.ActiveView;

                Transaction t = new Transaction(doc);
                t.Start("Create new dublicate");



                t.Commit();

            }

        
    }
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
    

