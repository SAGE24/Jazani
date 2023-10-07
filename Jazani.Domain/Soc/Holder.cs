using Jazani.Domain.Mc.Models;

namespace Jazani.Domain.Soc;
public class Holder
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Maidenname { get; set; }
    public string Documentnumber { get; set; }
    public string? Documentnumber2 { get; set; }
    public string? Landline { get; set; }
    public string? Mobile { get; set; }
    //public string? Address { get; set; }
    public string? Corporatemail {  get; set; }
    public string? Personalmail { get; set; }
    //public string? Publicrecord { get; set; }
    public string? Districtid {  get; set; }
    public int Holderregimeid { get; set; }
    public int Holdergroupid {  get; set; }
    public int Registryofficeid { get; set; }
    public int Identificationdocumentid { get; set; }
    public int? Nationalityid { get; set; }
    public int? Civilstatusid { get; set; }
    public int Holdertypeid {  get; set; }
    public DateTime? Regimedatestart { get; set; }
    public DateTime? Regimedateend { get; set; }
    public string? Regimenumberconstancy { get;set; }
    public DateTime Registrationdate { get; set; }
    public bool State { get; set; }
    public int? Holdercategoryid { get; set; }
    public bool? Isexternal { get; set; }
    public string? Ingemmetname { get;set; }

    public virtual ICollection<Investment>? Investments { get; set; }
}
