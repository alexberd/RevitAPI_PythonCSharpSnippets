FilteredElementCollector PhysicalElements = new FilteredElementCollector(doc);
PhysicalElements.WhereElementIsNotElementType();
PhysicalElements.WhereElementIsViewIndependent();
List<Element> PhysicalElementsList = new List<Element>();
foreach (Element i in PhysicalElements)
{
  if ( (null != i.Category) && (null != i.get_Geometry(new Options())))
  {
    PhysicalElementsList.Add(i);
  }
}
