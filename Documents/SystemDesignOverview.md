# 系统设计概要  
作者：Project Minazuki项目组

## 可玩性模式设计  
### 0.1 经典模式的可玩性模式设置  
经典模式是无尽的跑酷游戏，操控十六夜咲夜越过地图上的种种障碍追击偷书的魔理沙。随着追击的距离增加，新的地图元素会不断出现，咲夜奔跑的速度也将逐渐增加。每当追击的距离达到一定值，将会与魔理沙展开战斗。当玩家游戏结束时，根据玩家的游戏进程结算分数。  

进入游戏后，玩家操控的人物将不断向前奔跑，玩家可以通过控制人物进行跳跃和Dsah越过障碍。跳跃时人物将向前跳出一段距离，并受到重力影响而下落。除此之外，玩家可以通过滑动屏幕进行指定方向的Dash，Dash将使玩家向指定方向迅速移动一段距离直到碰到障碍物。为了精确指定Dash的方向并等待Dash的时机，玩家可以通过长按屏幕进入时停，此时背景变暗，摄像头拉近且游戏运行速度变慢，出现提示线指示玩家进行Dash的方向。通过跳跃或Dash至某些障碍物上，玩家可以迅速攀附其上。游戏中会出现多种随机生成的可拾取增益道具，拾取它们将可以使你的游戏进程更加轻松或在结算时得到更多分数。  

当玩家触碰到尖刺，或被魔理沙成功逃脱时游戏结束，系统将根据玩家奔跑的距离，拾取的散落书籍，击败魔理沙的次数结算分数。具体分数为奔跑的距离+拾取书籍×5+击败魔理沙次数×50。*具体实装进游戏中的得分规则可能有差异。*

可能出现的地形元素初步设计如下：
|地形|图例|功能|
|:--|:--|:--|
|墙壁||普通的墙壁，会阻挡你的前进，可以简单跃过或攀附其上进行更有效的移动|
|尖刺||锋利的尖刺，触碰到尖刺将会导致追击失败游戏结束|
|蘑菇||触碰到蘑菇会被弹起一段距离|
|||触碰到将刷新Dash冷却，可以在空中再次Dash|
|移动墙壁||沿某些固定轨迹移动的墙壁|
|气流||气流将给予人物一个指定方向的速度，影响人物移动|
|水域||在水中人物的移动将受到浮力等要素影响|
注意：某些变化的地形将无视时停效果，在时停时依然运转。  

*上述所有功能为初步设计所确定的功能，在正式发布的游戏中出现的道具可能与上述设计存在差异。*

可能出现的随机掉落道具初步设计的功能如下：
|道具|图例|功能|
|:--|:--|:--|
|书籍||失窃的书籍，拾取可以获得更高的分数|
|魔法阵||提供一段时间的防御，时间内玩家将无视尖刺与魔理沙的攻击|

### 0.2 经典模式的可玩性模式设置  
禅模式的
整体游戏规则和经典模式一致，但是玩家不会因为刺或其他碰撞而游戏结束。

## 一、UI设计  
用户界面设计的具体内容参见[界面设计概要](./UIDesignOverview.md).

## 二、数据库设计  
### 2.1 高分榜记录表  
记录最高一次游戏的得分、前近距离以及各种道具的收集数量以及达成日期；记录游戏第一次运行的日期；记录游戏自初始化以来所有游戏中前进距离、游戏的次数以及游戏中收集各种物品的数量。

需要的数据的表格如下：
|数据名|变量名|类型|描述|
|------|-----|----|---|
|最高游戏得分|HIGHSCORE|`int`||
|最高得分时的位移|HIGHMOVE|`int`||
|全局位移|ALLTIMESMOVE|`int`||
|音量开关|SOUNDISON|`int`|写入二进制游戏存档时，使用`bool`类型会导致错误。|

## 三、系统架构设计  
### 3.1 类和对象的说明  
下表说明了`Scripts`文件夹下所有的脚本文件关联的类以及它们在游戏中的作用。  

    cd ${REPOS_HOME}/touhou_the_big_coffer/touhou_the_big_coffer/Assets/Scripts

|对象|描述|位置|备注|
|----|----|----|----|
|`EnemyAnimation`||`./Animations/`|继承自`MonoBehaviour`|
|`PlayerAnimation`||`./Animations/`|继承自`MonoBehaviour`|
|`BackgroundMove00`||`./Background/`|继承自`MonoBehaviour`|
|`CameraFollow`||`./Camera/`|继承自`MonoBehaviour`|
|`DayAndNight`||`./Camera/`|继承自`MonoBehaviour`|
|`Bolt`||`./Enemy/`|继承自`MonoBehaviour`|
|`Enemy`||`./Enemy/`|继承自`MonoBehaviour`|
|`Bubble`||`./Items/`|继承自`MonoBehaviour`|
|`DeathBonus`||`./Items/`|继承自`MonoBehaviour`|
|`Panding`||`./Items/`|继承自`MonoBehaviour`|
|`Rotate1`||`./Items/`|继承自`MonoBehaviour`|
|`Rotate2`||`./Items/`|继承自`MonoBehaviour`|
|`StarPlatinum`||`./Items/`|继承自`MonoBehaviour`|
|`DestroyByInvisibleWall`||`./Managers/`|继承自`MonoBehaviour`|
|`DestroyByTime`||`./Managers/`|继承自`MonoBehaviour`|
|`GameOver`||`./Managers/`|继承自`MonoBehaviour`|
|`MapCreator`||`./Managers/`|继承自`MonoBehaviour`|
|`Savedata`||`./Managers/`||
|`Score`||`./Managers/`|继承自`MonoBehaviour`|
|`StatefulInspection`||`./Managers/`|继承自`MonoBehaviour`|
|`DeathTouch`||`./Map/`|继承自`MonoBehaviour`|
|`MagicCircle`||`./Map/`|继承自`MonoBehaviour`|
|`Shadow`||`./Map/`|继承自`MonoBehaviour`|
|`Afterimage`||`./Player/`|继承自`MonoBehaviour`|
|`PlayerControl`||`./Player/`|继承自`MonoBehaviour`|
|`PlayerMoving`||`./Player/`|继承自`MonoBehaviour`|
|`GameManage`||`./UI/`|继承自`MonoBehaviour`|
|`PauseButton`||`./UI/`|继承自`MonoBehaviour`|
