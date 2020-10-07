Void ExportIFC (Document doc, ElementId ExportViewId, string ExportDirectory)
{
  //Create an Instance of the IFC Export Class
  IFCExportOptions IFCExportOptions = new IFCExportOptions();

  //Apply the IFC Export Setting (Those are equivalent to the Export Setting in the IFC Export User Interface)
  myIFCExportConfiguration.VisibleElementsOfCurrentView = true;

  //Create an instance of the IFC Export Configuration Class
  BIM.IFC.Export.UI.IFCExportConfiguration myIFCExportConfiguration = BIM.IFC.Export.UI.IFCExportConfiguration.CreateDefaultConfiguration();

  //Pass the setting of the myIFCExportConfiguration to the IFCExportOptions
  myIFCExportConfiguration.UpdateOptions(IFCExportOptions, ExportViewId);

  //Process the IFC Export
  doc.Export(ExportDirectory, doc, IFCExportOptions);
}
