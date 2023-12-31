﻿namespace Jazani.Application.Mc.Dtos.Investments;
public class InvestmentDto
{
    public int Id { get; set; }
    public decimal Amountinvestd { get; set; }
    public int? Year { get; set; }
    public string? Description { get; set; }
    //public int Miningconcessionid { get; set; }
    public InvestmentMiningconcessionSimpleDto? Miningconcession { get; set; }
    //public int Investmenttypeid { get; set; }
    public InvestmentInvestmentTypeSimpleDto Investmenttype { get; set; }
    public int Currencytypeid { get; set; }
    //public int? Periodtypeid { get; set; }
    public InvestmentPeriodtypeSimpleDto? Periodtype { get; set; }
    //public int? Measureunitid { get; set; }
    public InvestmentMeasureunitSimpleDto? Measureunit { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool State { get; set; }
    public string? Monthname { get; set; }
    public int? Monthid { get; set; }
    public string? Accreditationcode { get; set; }
    public string? Accountantcode { get; set; }
    //public int Holderid { get; set; }
    public InvestmentHolderSimpleDto? Holder { get; set; }
    public int Declaredtypeid { get; set; }
    public int? Documentid { get; set; }
    //public int Investmentconceptid { get; set; }
    public InvestmentConceptSimpleDto? Investmentconcept { get; set; } 
    public bool? Module { get; set; }
    public int? Frecuency { get; set; }
    public int? Isdac { get; set; }
    public string? Metrictons { get; set; }
    public DateTime? Declarationdate { get; set; }
}
