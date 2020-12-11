void setParameterByName(Document doc, List<Element> FilteredElementCollector, string ParameterName, string newParameterValue)
{
  using (Transaction tx = new Transaction(doc, "setParameterByName"))
  {
    tx.Start();
    foreach (Element i in FilteredElementCollector)
    {
      foreach (Parameter para in i.Parameters)
      {
          Definition p = para.Definition;

          if (p.Name == ParameterName)
          {
              try
              {
                  para.Set(newParameterValue);
              }
              catch (Exception ex)
              {

              }
          }
      }
    }
    tx.Commit();
  }
}
