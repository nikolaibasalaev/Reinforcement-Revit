

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
using System.Collections;
//using Reinforcement.WinForm;
#endregion

namespace Reinforcement
{
    [Transaction(TransactionMode.Manual)]
    public class WinFormTest : IExternalCommand
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

            ArrayList m_titleblockMaps = new ArrayList();       //list of columns' type
            ArrayList m_multTagMaps = new ArrayList();      //list of beams' type
            ArrayList m_braceMaps = new ArrayList();        //list of braces' type

            ///////////////////////////////////
            using (Transaction t = new Transaction(doc, "Apply Filter"))
            {
                t.Start();
                try
                {

                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    collector.OfClass(typeof(FamilySymbol));
                    collector.OfCategory(BuiltInCategory.OST_TitleBlocks);

                    IList<Element> arrayFamily = collector.ToElements();

                    foreach (Autodesk.Revit.DB.Element ee in arrayFamily)
                    {
                        FamilySymbol f = ee as FamilySymbol;
                        if (null != f)
                        {

                            m_titleblockMaps.Add(new SymbolMap(f));

                        }
                    }
                    FilteredElementCollector collector2 = new FilteredElementCollector(doc);

                    collector2.OfCategory(BuiltInCategory.OST_MultiReferenceAnnotations);

                    IList<Element> arrayFamilytag = collector2.ToElements();

                    //MessageBox.Show(arrayFamilytag.Count.ToString());

                    foreach (Autodesk.Revit.DB.Element ee in arrayFamilytag)
                    {
                        MultiReferenceAnnotationType ff = ee as MultiReferenceAnnotationType;
                        if (null != ff)
                        {
                            //MessageBox.Show("ok");
                            m_multTagMaps.Add(new SymbolMap2(ff));
                            //MessageBox.Show(m_multTagMaps.Count.ToString());
                        }
                        else
                        {
                        }
                    }
                }
                catch
                {
                }
                t.Commit();
            }

            ///////////////////////////////////
            return Result.Succeeded;
        }
    }





    public class SymbolMap
    {
        string m_symbolName = "";
        FamilySymbol m_symbol = null;

        /// <summary>
        /// constructor without parameter is forbidden
        /// </summary>
        private SymbolMap()
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="symbol">family symbol</param>
        public SymbolMap(FamilySymbol symbol)
        {
            m_symbol = symbol;
            string familyName = "";
            if (null != symbol.Family)
            {
                familyName = symbol.Family.Name;
            }
            m_symbolName = familyName + " : " + symbol.Name;
        }

        /// <summary>
        /// SymbolName property
        /// </summary>
        public string SymbolName
        {
            get
            {
                return m_symbolName;
            }
        }
        /// <summary>
        /// ElementType property
        /// </summary>
        public FamilySymbol ElementType
        {
            get
            {
                return m_symbol;
            }
        }
    }


    public class SymbolMap2
    {
        string m_symbolName = "";
        MultiReferenceAnnotationType m_symbol = null;

        /// <summary>
        /// constructor without parameter is forbidden
        /// </summary>
        private SymbolMap2()
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="symbol">family symbol</param>
        public SymbolMap2(MultiReferenceAnnotationType symbol)
        {
            m_symbol = symbol;
            string familyName = "";
            //if (null != symbol.Family)
            //{
            //	familyName = symbol.Family.Name;
            //}
            //m_symbolName = familyName + " : " + symbol.Name;
            m_symbolName = symbol.Name;
        }

        /// <summary>
        /// SymbolName property
        /// </summary>
        public string SymbolName
        {
            get
            {
                return m_symbolName;
            }
        }
        /// <summary>
        /// ElementType property
        /// </summary>
        public MultiReferenceAnnotationType ElementType
        {
            get
            {
                return m_symbol;
            }
        }
    }
}
