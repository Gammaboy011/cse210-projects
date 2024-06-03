using System;
using System.ComponentModel;

class CashDrawer {
    private DenominationBin[] _bins;
    public CashDrawer() { // construct for new shift drawer
        _bins = new DenominationBin[9];
        _bins[0] = new DenominationBin("penny", 1, 50);
        _bins[1] = new DenominationBin("nickel", 5, 40);
        _bins[2] = new DenominationBin("dime", 10, 50);
        _bins[3] = new DenominationBin("quarter", 25, 40);
        _bins[4] = new DenominationBin("half dollar", 50, 0);
        _bins[5] = new DenominationBin("dollar bill", 100, 25);
        _bins[6] = new DenominationBin("five dollar bill", 500, 10);
        _bins[7] = new DenominationBin("ten dollar bill", 1000, 10);
        _bins[8] = new DenominationBin("twenty dollar bill", 2000, 5);
    }
    // transaction
    public void Update(int binIndex, int countParam){  //nagativecount
        // negative count for withdraw, positive count for deposit
        int newCount = _bins[binIndex].GetCount() + countParam;
        _bins[binIndex].SetCount(newCount);
    }
}