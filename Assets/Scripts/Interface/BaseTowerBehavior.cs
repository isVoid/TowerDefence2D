using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseTowerBehavior {

    int getID();
    void setID(int id);

    int getStubID();
    void setStubID(int stubID);

    void upgrade();
    int valueOf();
    void sell();
}
