string getParameterByName(Document doc, Element element, string ParameterName, string ParameterValue)
{
  foreach (Parameter para in element.Parameters)
  {
    Definition p = para.Definition;
    if (p.Name == ParameterName)
    {
      return para.AsValueString();
    }
  }            
  return null;
}
