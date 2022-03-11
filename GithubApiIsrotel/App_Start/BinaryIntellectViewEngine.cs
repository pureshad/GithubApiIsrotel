namespace GithubApiIsrotel.App_Start;

public class BinaryIntellectViewEngine : RazorViewEngine
{
    public BinaryIntellectViewEngine()
    {
        string[] locations = new string[] {
            "~/Views/GithubAPI/_PartialSearch.cshtml"
        };

        ViewLocationFormats = locations;
        PartialViewLocationFormats = locations;
        MasterLocationFormats = locations;
    }
}
