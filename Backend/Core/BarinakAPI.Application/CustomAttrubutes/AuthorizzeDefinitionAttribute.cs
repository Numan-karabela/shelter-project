using BarinakAPI.Application.Enums;


namespace BarinakAPI.Application.CustomAttrubutes
{
    public class AuthorizzeDefinitionAttribute:Attribute
    {
        public string Menu { get; set; }
        public string Definition { get; set; }
        public ActionType  ActionType{ get; set; }


    }
}
