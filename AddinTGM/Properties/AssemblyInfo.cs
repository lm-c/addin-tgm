using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle(InfoAssembly.TitleView)]
[assembly: AssemblyDescription(InfoAssembly.DescrView)]
[assembly: AssemblyConfiguration(InfoAssembly.Configuration)]
[assembly: AssemblyCompany(InfoAssembly.Company)]
[assembly: AssemblyProduct(InfoAssembly.Product)]
[assembly: AssemblyCopyright(InfoAssembly.Copyright)]
[assembly: AssemblyTrademark(InfoAssembly.Trademark)]
[assembly: AssemblyCulture(InfoAssembly.Culture)]

[assembly: ComVisible(true)]

[assembly: Guid("bae086c4-c99f-470c-83b9-31abd7784e3e")]

[assembly: AssemblyVersion(InfoAssembly.Version)]
[assembly: AssemblyFileVersion(InfoAssembly.Version)]

public class InfoAssembly {
  public const string Version = "4.0.1.8";

  public const string TitleView = "Addin Leonardo Michalak";

  public const string DescrView = "Sistema de Gerenciamento de desenhos";

  public const string Copyright = "Copyright © 2024 Leonardo Adriano Michalak.  Todos os direitos reservados.";
  public const string Company = "Leonardo Adriano Michalak";
  public const string Product = "Suplemento Solidworks para Gerenciamento de Desenhos";
  public const string Configuration = "";
  public const string Trademark = "";
  public const string Culture = "";
}
