namespace benchmark;

public class Deposant
{
    public required Guid Id {get;set;}
    public required string FirstName {get;set;}
    public required string LastName {get;set;}
    public required string Email {get;set;}
    public required string CountryCode {get;set;}
    public required string Bsn {get;set;}
    public string Street { get; set; }
    public string Postcode { get; set; }
    public string City { get; set; }
}

public class Address
{
    public string Street { get;set;}
    public string Postcode { get;set;}
    public string City { get;set;}
}
