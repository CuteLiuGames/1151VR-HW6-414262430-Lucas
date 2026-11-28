製作流程： 將basket、apple與bomb模型導入至場景中，撰寫basket、item與director腳本，並導入UI與難度調整。
操作：一開始可以選擇關卡難度，有簡單(Easy)、中等(Medium)、困難(Hard)與極限(Extreme)模式。各模式會針對apple與bomb的生成比例、生成間隔與掉落速度進行調整。在主選單點選難度後會倒數開始遊戲，開始後點擊九宮格中的位置來移動basket。每一回合有60秒的時間，目標是在這60秒內獲得更高的分數。遊戲中會有apple與bomb掉落，撿到apple會加100分，檢到bomb則是會扣除一半的分數。當遊戲結束時會顯示最終分數並且可以選擇回到主選單或再次遊玩當前難度。

各模式的困難度調整如下：(span：生成間隔，ratio：apple與bomb的比例，speed：掉落速度)
Easy: span = 1.0f, ratio = 2, speed = -0.03f
Medium: span = 0.8f, ratio = 3, speed = -0.04f
Hard: span = 0.6f, ratio = 4, speed = -0.06f
Extreme: span = 0.4f. ratio = 6, span = -0.04f
