using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTips : MonoBehaviour
{
    static int tipsIndex;
    public Text TipsText;
    public float time0;
    private string[] tips =
    {
        "点击游戏进入开始界面，轻触进入经典模式，左滑进入禅模式，右滑进入设置界面。",
            "角色自动向前行进，当角色在墙的上方时，点击屏幕左侧角色会向上跳动一段固定的距离。",
            "当角色在墙的左侧时，点击屏幕左侧角色会向上翻滚一段固定的距离。",
            "玩家长按屏幕右侧，镜头向角色拉近，时间流速变得缓慢",
            "玩家滑动屏幕，角色会向玩家滑动屏幕的方向冲刺一定的距离，当玩家在空中时只能使用一次冲刺。",
            "发动角色能力时，即玩家按住屏幕右侧一段时间并进行滑动操作时，出现一条清晰的辅助线帮助玩家掌握冲刺方向。",
            "地图由一块块独立的墙体构成。",
            "墙体上会随机生成刺阻拦角色移动，当角色触碰到刺时结束游戏。",
            "魔法书随机生成在地图四处，玩家触碰到魔法书时分数增加100。",
            "在一定距离后玩家会遭遇魔法阵，每隔2秒会释放强大的魔法并产生蓝色的光，玩家在魔法阵暗淡时可安全通过魔法阵。",
            "无敌泡泡随机生成在地图四处，当角色触碰到无敌泡泡时，会在周围产生一个7.5秒的护盾保护角色。",
            "敌人会在玩家前方一定距离并发射魔法攻击角色，角色可通过冲刺追上敌人，当角色触碰到敌人时，敌人会被角色击退并掉落魔法书。",
            "敌人散射出的红色魔法子弹不会受到时停影响，当玩家触碰到子弹时结束游戏。",
            "敌人散射出黄色魔法子弹会受到时停影响，当玩家触碰到子弹时结束游戏。"
    };
    // Start is called before the first frame update
    void Start()
    {
        tipsIndex = Random.Range(0,tips.Length);
        TipsText.text = tips[tipsIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time0 > 1.5)
        {
            TipsText.text = tips[tipsIndex];
            if (tipsIndex != tips.Length-1)
                tipsIndex++;
            else
                tipsIndex = 0;
            time0 = Time.time;
        }
    }
}
