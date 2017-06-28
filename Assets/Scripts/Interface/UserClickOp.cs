using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UserClickOp {

    void setClickedStubIndex(int index);
    void setClickedTowerIndex(int index);

    void buildIceTower();
    void buildDrinkTower();
    void buildPizzaTower();
    void buildMelonTower();
    void buildGuandongTower();

    void upgradeTower();
    void sellTower();
}


