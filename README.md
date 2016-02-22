# PureMVC for Unity
幾個月前改用 Unity 開發遊戲，到目前的心得為：組件式開發真的是很便利，但是當組件數量多到一定程度時，結構上就有點可怕，常常在某 GameObject  上掛了組件後就忘了它的存在，雖然可以使用 Singleton design pattern 來製作主要的 Manager（本人對 Singleton 並不是很熱愛），程式還是會亂到一定程度，搜尋了一些 Unity with MVC 討論，一部分的人都對實作 MVC 不是很熱絡，也許是 Unity 特有的開發環境導致。

以前開發 Adobe Flex 專案最愛用的 MVC Framework 就是 PureMVC，即使後來有更方便的 MVC Framework 的也擋不住我對它的熱愛。Unity 是沒有所謂的全域 Root Scene，所有場景都是獨立，想要將 AS3 實作邏輯套用在 Unity 上將控制項都在 PureMVC 架構中實作是有點矯情多餘。如何保持 Unity 組件開發模式，導入 PureMVC 鬆綁主要邏輯，就是這次實驗的重點。

不清楚 PureMVC 的朋友們可以到這邊參觀一下：[PureMVC 我也會](http://www.erinylin.com/2011/03/puremvc-0.html)
[PureMVC C# Standard Framework on GitHub](https://github.com/PureMVC/puremvc-csharp-standard-framework)

### ViewComponent 與 Mediator 整合是首要工作：
由於 Unity 沒有全域 Root Scene，如果將 new Mediator( viewComponent ) 寫在 PureMVC 架構下，即使透過 GameObject.Find 找那個對應的 GameObject 就轉了九彎十八拐，寫起來一點都不愉快，尤其考慮到場景的轉換，兩個場景中相關 Mediator 的註冊與移除處理，何況對 Unity 組件來說，能不能用被打包動態載入是件重要的事。綜合以上問題點，反向思考，改由 GameObject 掛載中介組件，在 OnEnable 與 OnDisable 通知 Facade 去註冊與移除其 Mediator，一來簡化為了實作 Meditaor 掛載 ViewComponent 而對 static class GameObject 的依賴，二來也不會對 Unity 組件開發模式有太大的影響。
  
#### 修改 MediatorPlug 的執行順序
為確保 MediatorPlug 執行時間在場景起始後，需修改 Script Execution Order。打開 Edit / Project Settings / Script Execution Order，修改如下：
<a href="https://2.bp.blogspot.com/-3J5p7t3qndY/VsXuaAFpLbI/AAAAAAAA2sg/ZC4tjqohoDI/s1600/Scene1_unity_-_PureMVC_-_Web_Player__Personal___OpenGL_4_1_.png" imageanchor="1" ><img border="0" src="https://2.bp.blogspot.com/-3J5p7t3qndY/VsXuaAFpLbI/AAAAAAAA2sg/ZC4tjqohoDI/s320/Scene1_unity_-_PureMVC_-_Web_Player__Personal___OpenGL_4_1_.png" /></a>
#### 執行結果：
<a href="https://2.bp.blogspot.com/-XbAqINc91uI/VsX3m3GhafI/AAAAAAAA2sw/W_1moBWy6QQ/s1600/Scene1_unity.png" imageanchor="1" ><img border="0" src="https://2.bp.blogspot.com/-XbAqINc91uI/VsX3m3GhafI/AAAAAAAA2sw/W_1moBWy6QQ/s320/Scene1_unity.png" /></a>
最後試驗結果挺令人滿意的，轉換場景後也沒有垃圾留下來，測試專案內寫了兩種 ViewComponent <-> Mediator 與 Proxy 更新範例。

### notification branche
拿掉 IMediatorPlug 版本，改由 SendNotification 傳送



