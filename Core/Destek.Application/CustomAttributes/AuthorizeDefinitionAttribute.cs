using Destek.Application.Enums;

namespace Destek.Application.CustomAttributes
{
    public class AuthorizeDefinitionAttribute:Attribute
    {
        //test
        public string Menu { get; set; }
        public string Definition { get; set; }
        public ActionType ActionType { get; set; }
    }
}
