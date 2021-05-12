//By H.echeva
//https://forums.autodesk.com/t5/revit-api-forum/purge-unused-via-the-api/td-p/6431564 

public void Purge(Document doc)
{
    //note this won't purge materials
    string desiredRule = "Project contains unused families and types";

    //access the Performance adviser
    PerformanceAdviser perfAdviser = PerformanceAdviser.GetPerformanceAdviser();

    //create a list with all the rules
    IList<PerformanceAdviserRuleId> allRulesList = perfAdviser.GetAllRuleIds();

    //create an empty list to save the rules that we want to run 
    //(in the purge case just one rule)
    IList<PerformanceAdviserRuleId> rulesToExecute = new List<PerformanceAdviserRuleId>();

    //Iterate through each
    foreach (PerformanceAdviserRuleId r in allRulesList)
    {
        if (perfAdviser.GetRuleName(r).Equals(desiredRule))
        {
            rulesToExecute.Add(r);
        }
    }
    for (int i = 0; i < 5; i++)
    {
        //execute the rules and get the results
        IList<FailureMessage> failureMessages = perfAdviser.ExecuteRules(doc, rulesToExecute);

        //Check if there are results
        if (failureMessages.Count() == 0) return;

        ICollection<ElementId> failingElementsIds = failureMessages[0].GetFailingElements();

        using (Transaction t = new Transaction(doc, "Purge:" + doc.Title))
        {
            t.Start();
            foreach (ElementId eid in failingElementsIds)
            {
                try
                {
                    doc.Delete(eid);
                }
                catch
                {

                }
            }

            t.Commit();
        }
    }
}
