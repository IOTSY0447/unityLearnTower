using UnityEngine;
using UnityEngine.Events;
public enum EventEnum {
    BuildMenu,
    tower1,
    tower2,
    showUpdateMenu,
}
public class TowerEvent : UnityEvent<EventEnum, GameObject> {

}
public class Global {
    public static Global instance = null;
    public TowerEvent myEvent = new TowerEvent ();
    public static EnemyController EnemyController = null;
    public static Global GetInstance {
        get {
            if (instance == null) {
                instance = new Global ();
            }
            return instance;
        }
    }
    public TowerEvent GetEvent () {
        return myEvent;
    }
    private static ObjectPool buttlePool;
    public static ObjectPool GetButtlePool{
        get{
            if(buttlePool == null){
                buttlePool = new ObjectPool();
            }
            return buttlePool;
        }
    }
}