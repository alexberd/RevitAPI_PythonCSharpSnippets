//implementation is based on the following sources
//https://github.com/jeremytammik/the_building_coder_samples/blob/master/BuildingCoder/BuildingCoder/CmdCopyWallType.cs#L148
//https://forums.autodesk.com/t5/revit-api-forum/transfer-project-standards-revit-api/td-p/6828310
//https://forums.autodesk.com/t5/revit-api-forum/copying-and-overwriting-types-between-projects/td-p/4830249

void transferWallTypes(Document doc_source, Document doc_target, String WallTypeName)
{
    using (Transaction tx = new Transaction(doc_target, "TransferWallTypes"))
    {
        tx.Start();
        FilteredElementCollector wallTypes1 = new FilteredElementCollector(doc_source).OfClass(typeof(WallType));

        WallType wt_source = null;
        foreach (WallType wt_ in wallTypes1)
        {
            if (wt_.Name == WallTypeName)
            {
                wt_source = wt_;
                break; //we pick only the first type with that name
            }
        }
        //get the target wall type in doc.
        FilteredElementCollector wallTypes2 = new FilteredElementCollector(doc_target).OfClass(typeof(WallType));
        WallType wtTarget = null;

        foreach (WallType wt_ in wallTypes2)
        {
            if (wt_.Name == WallTypeName)
            {
                wtTarget = wt_;
                break; //we pick only the first type with that name
            }
        }

        if (wtTarget != null & wt_source != null)
        {
            wtTarget.SetCompoundStructure(wt_source.GetCompoundStructure());
            foreach (Parameter para in wtTarget.Parameters)
            {
                Definition d = para.Definition;

                if (!(para.IsReadOnly))
                {
                    Parameter p = wt.get_Parameter(d);
                    if (p == null)
                    {
                        Debug.Print(string.Format("Parameter '{0}' not found on source wall type.", d.Name));
                    }
                    else if (para.StorageType == StorageType.Double)
                    {
                        para.Set(p.AsDouble());
                    }
                    else if (para.StorageType == StorageType.ElementId)
                    {
                        para.Set(p.AsElementId());
                    }
                    else if (para.StorageType == StorageType.Integer)
                    {
                        para.Set(p.AsInteger());
                    }
                    else if (para.StorageType == StorageType.String)
                    {
                        para.Set(p.AsString());
                    }
                    else
                    {
                        int donothing = 0;
                    }
                }
            }
        }

        tx.Commit();
    }
}
