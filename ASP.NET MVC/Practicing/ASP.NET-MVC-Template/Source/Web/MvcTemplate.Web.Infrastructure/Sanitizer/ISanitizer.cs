namespace MvcTemplate.Web.Infrastructure.Sanitizer
{
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}
