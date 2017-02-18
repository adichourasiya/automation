namespace Framework.Pages
{
    public class astroAssignment
    {
        public void GotoAstroMyPage()
        {
            Browser.Goto(".my");

        }

        public bool IsAtMyPage()
        {
            return (Browser.Title.Contains("Google"));
        }

    }
}