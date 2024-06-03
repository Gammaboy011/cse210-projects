using System;

class DenominationBin
{
    private string _id;
    private int _centsValue;
    private int _count;
    // contstructor
    public DenominationBin(string idParam, int cvParam, int countParam) {
        _id = idParam;
        _centsValue = cvParam;
        _count = countParam;
    }
    // accessors
    public string GetId() { return _id; }
    public int GetValueInCents() { return _centsValue; }
    public int GetCount() { return _count; }

    // mutators
    public void SetId(string idParam) { _id = idParam; }
    public void SetValueInCents(int cvParam) { _centsValue = cvParam; }
    public void SetCount(int countParam) { _count = countParam; }
}