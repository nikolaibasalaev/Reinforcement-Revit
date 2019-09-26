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
        Autodesk.Revit.UI.UIApplication m_revit = null;    // application of Revit
        bool m_topRebarView;
        bool m_bottomRebarView;
        bool m_topAddRebarView;
        bool m_bottomAddRebarView;
        string m_currentViewName;

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
        { }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            {
                Autodesk.Revit.UI.UIApplication revit = commandData.Application;
                m_revit = revit;
                DublicateViewsForm displayForm = new DublicateViewsForm(this);
                displayForm.StartPosition = FormStartPosition.CenterParent;


            }




            //#endregion IExternalCommand Members Implementation
        }
        public class ViewDubl
        {
            private string m_curViewName;


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
               // ViewSheet sheet = ViewSheet.Create(doc, m_titleBlock.Id);
               // sheet.Name = SheetName;
               // PlaceView(viewcur, sheet);
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
    }
}
