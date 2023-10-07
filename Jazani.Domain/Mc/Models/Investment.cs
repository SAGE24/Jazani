using Jazani.Domain.Cores.Models;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Soc;

namespace Jazani.Domain.Mc.Models;
public class Investment : CoreModel<int>
{
    public decimal Amountinvestd { get; set; }
    public int? Year { get; set; }
    public string? Description { get; set; }
    public int Miningconcessionid { get; set; }
    public int Investmenttypeid { get; set; }
    public int Currencytypeid { get; set; }
    public int? Periodtypeid { get; set; }
    public int? Measureunitid { get; set; }
    public string? Monthname { get; set; }
    public int? Monthid { get; set; }
    public string? Accreditationcode { get; set; }
    public string? Accountantcode { get; set; }
    public int Holderid { get; set; }
    public int Declaredtypeid { get; set; }
    public int? Documentid { get; set; }
    public int? Investmentconceptid { get; set; }
    public bool? Module { get; set; }
    public int? Frecuency { get; set; }
    public int? Isdac { get; set; }
    public string? Metrictons { get; set; }
    public DateTime? Declarationdate { get; set; }

    public virtual Investmentconcept? Investmentconcept { get; set; }
    public virtual Holder? Holder { get; set; }
    public virtual Investmenttype? Investmenttype { get; set; }
    public virtual Miningconcession? Miningconcession { get; set; }
    public virtual Measureunit? Measureunit { get; set; }
    public virtual Periodtype? Periodtype { get; set; }
}
