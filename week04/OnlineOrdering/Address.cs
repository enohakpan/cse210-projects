public class Address{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country){
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    /* getters and setters */

    public string GetStreet(){
        return _street;
    }

    public void SetStreet(string street){
        _street = street;
    }

    public string GetCity(){
        return _city;
    }

    public void SetCity(string city){
        _street = city;
    }

    public string GetState(){
        return _state;
    }

    public void SetState(string state){
        _street = state;
    }

    public string GetCountry(){
        return _country;
    }

    public void SetCountry(string country){
        _street = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}