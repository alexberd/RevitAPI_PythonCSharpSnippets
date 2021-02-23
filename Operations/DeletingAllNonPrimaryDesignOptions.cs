public void DeletingAllNonPrimaryDesignOptions(Document doc)
{
	//Selecting All Design Options
	FilteredElementCollector collector = new FilteredElementCollector(doc);
	collector.OfCategory(BuiltInCategory.OST_DesignOptions);

	//Selecting All non-Primary Design Options
	List<ElementId> DesignOptionsNotPrimaryIDs = new List<ElementId>();
	foreach (Element i in collector)
	{
		Autodesk.Revit.DB.DesignOption ii = i as Autodesk.Revit.DB.DesignOption;
		if (ii != null)
		{
			if (ii.IsPrimary != true)
			DesignOptionsNotPrimaryIDs.Add(ii.Id);
		}
	}

	//Deleting All non-Primary Design Options
	using (Transaction tx = new Transaction(doc))
	{
		tx.Start("Deleting all non-primary design options")
		doc.Delete(DesignOptionsNotPrimaryIDs);
		tx.Commit();
	}
}
