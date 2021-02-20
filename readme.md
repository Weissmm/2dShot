2021/2/15

​	白天吃席，22.30到家（总算结束了。

​	①视频学习完毕，gameplay 30个要素：

1.动画和声音 2.敌人hp 3.射击频率 4.更多的敌人 5.更强的子弹 6.枪口闪光 7.弹道速度加快 8.精度降低 9.子弹击中不同的效果 10.子弹击中的动画 11.敌人被击退  12.敌人尸体  13.相机跟随  14.相机位置（视图位置）15.窗口震动  16.后坐力（移动射击移速降低） 自动射击 17.击中敌人敌人的暂时停止效果  18.gun delay  19.gun kick  20.扫射 21.子弹屑（射出后的弹壳） 22.more bases 23.特殊武器 24.随机爆炸（敌人死后30%几率自爆 25.敌人移速更快 26.更多敌人 27.even higher rate of fire & camera kick 28.更大的爆炸 29.产生更多的特效 30.死亡意义  

​	②明确了技术要点，确定了仍需学习的技术（线程池、AI制作等

​	③在unity社区找到了像素风素材，简单绘制了地图



2021/2/16

​	下午在刷题和背八股 大概花了3个小时学习和开发（包括学习制作GIF等一系列

​	先是写完了人物的移动，然后学了子弹的制作![1](C:\Users\Administrator\Desktop\凉屋GamePlay\GIFs\1.gif)



​	添加动画

![2](C:\Users\Administrator\Desktop\凉屋GamePlay\GIFs\2.gif)



2021/2/17

​	今天也是吃席的一天，晚上22.30开工 一直到0点 完成AI制作和子弹实体化

![3](C:\Users\Administrator\Desktop\凉屋GamePlay\GIFs\3.gif)



2021/2/18

​	相机跟随、敌人受伤效果、连续射击与CameraShake

​	![4](C:\Users\Administrator\Desktop\凉屋GamePlay\GIFs\4.gif)

​	开枪后坐力，敌人受伤击退以及伤害显示（为了演示，把后退效果弄的比较明显

![5](C:\Users\Administrator\Desktop\凉屋GamePlay\GIFs\5.gif)

问题待解决：代码修改能持续开火后，按一次会造成两次伤害



2021/2/19

问题解决：因为AI有两个collider，子弹碰撞时会检测两次 所以会造成双倍伤害



​	AI自动巡逻 以及特殊攻击方式制作

![6](C:\Users\Administrator\Desktop\凉屋GamePlay\GIFs\6.gif)



​	地图完善、菜单Menu、暂停游戏（按ESC键）、游戏BGM添加

![7](C:\Users\Administrator\Desktop\凉屋GamePlay\GIFs\7.gif)



2021/2/20

​	将地面检测从collider检测换成射线检测![8](C:\Users\Administrator\Desktop\凉屋GamePlay\GIFs\8.gif)

​	真·枪口火焰（没找到好的素材） 、AI死亡粒子特效

![9](C:\Users\Administrator\Desktop\凉屋GamePlay\GIFs\9.gif)