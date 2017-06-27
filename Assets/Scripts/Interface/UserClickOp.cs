using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UserClickOp {

    void setClickedStubIndex(int index);
    void setClickedTowerIndex(int index);

    void buildArrowTower();
    void buildSoldierTower();
    void buildWizardTower();
    void buildCannonTower();

    void upgradeTower();
    void sellTower();
}


