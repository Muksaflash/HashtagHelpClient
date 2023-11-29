namespace HashtagHelpClient.Models;
public class FormDataModel
{
    public string TableName { get; set; }
    public string SemiAreasSheetName { get; set; }
    public string AreaSheetName { get; set; }
    public string ParsedSheetName { get; set; }
    public int MinHashtagFollowers { get; set; }
    public string OutputGoogleSheet { get; set; }
}
