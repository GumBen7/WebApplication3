using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace WebApplication3.Models {
    public static class Database {
        public static List<LoginViewModel> Users { get; set; } = 
            [new LoginViewModel { Login="George", Password= "202CB962AC59075B964B07152D234B70" }]; // парволь: 123 на md5
    }
}
