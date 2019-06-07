# 交換介面格式
向後台發送請求，後台將會做出相對應的回應。
- 後台位置 https://dinnersystem.com/dinnersystem_beta/backend/backend.php
- 你可以採用 `get` 方法進行傳輸，也可以採用 `post` 進行傳輸

## 使用方法
> # 登入
>> 呼叫方法
>> - URL Suffix `?cmd=login&id={your_id}&password={your_password}&device_id={device_id}`
>> - 例如 `?cmd=login&id=seanpai&password=131313&device_id=HELLO_FROM_ANDROID`
>> 
>> 回傳
>> - 一個使用者 `json` 物件
>>
>> 附註
>> - `device_id` 其實並沒有限制，只是方便識別哪一種應用程式登入系統而已
>> - 系統不限制一隻帳號同時能有幾個人登入
>> - 登入失敗會被記載到 `error_log` 中，某隻帳號登入失敗太多次會被鎖
>> - 更改密碼後，並不會強制要求使用者跳出系統
>>

> # 登出
>> 呼叫方法
>> - URL Suffix `?cmd=logout`
>> - 例如 `?cmd=logout`
>>
>> 回傳
>> - `Successfully logout.`
> # 更改密碼
>> 呼叫方法
>> - URL Suffix `?cmd=change_password&old_pswd={old_password}&new_pswd={new_password}`
>> - 例如 `?cmd=change_password&old_pswd=5487580&new_pswd=5487580`
>> 
>> 回傳
>> - 一個使用者 `json` 物件
>>
>> 附註
>> - 密碼打錯並不會被記錄到 `error_log`，可以嘗試無限次
>> 

> # 展現菜單
>> 呼叫方法
>> - URL Suffix `?cmd=show_dish`
>> - 例如 `?cmd=show_dish`
>> 
>> 回傳
>> - 菜單的 `json` 陣列
>>
>> 附註
>> - 取得剩下多少餐時，採用 `S` 鎖進行上鎖，增加資料庫效能
>> - 人氣餐點的判斷是經由 `regex` 來判斷的，如果餐點名稱被 `regex` 判斷為真，則該餐點屬於人氣餐點
>> 

> # 展現點單
>> 呼叫方法
>> - 請自行組合 URL Suffix
>>> - 較常使用
>>> 
>>>> 限制要抓出哪些資料 `?cmd=select_{self, class ,other ,factory}`
>>>>
>>>>- `self` 僅限抓出自己的資料
>>>> - `class` 僅限抓出自己班的資料
>>>> - `other` 不限制，~~不要問我為什麼叫做 `other`~~
>>>> - `factory` 僅限抓出自己廠商的資料
>>>>
>>>> 時間上界 `?esti_start={Year/Month/Date-Hour:Minute:Second}`
>>>>
>>>> 時間下界 `?esti_end={Year/Month/Date-Hour:Minute:Second}`
>>>>
>>>> 取得實際歷史資料 `?history={true}`
>>> - 較少使用
>>>>
>>>> 抓出特定使用者的 `?user_id={user_id}`
>>>>
>>>> 只抓出自己的 `?person={true}`
>>>>
>>>> 只抓出自己班的 `?class={true}`
>>>>
>>>> 點單編號 `?oid={order_id}`
>>>>
>>>> 是否繳款 `?payment={true ,false}`
>>>>
>>>> 廠商編號 `?factory_id={factory_id}`
>>>>
>>>
>> - 例如 `?cmd=select_self&esti_start=2019/01/01-00:00:00&history=true`
>> 
>> 回傳
>> - 點單的 `json` 陣列
>>
>> 附註
>> - 取得是否繳款時，採用 `S` 鎖進行上鎖，增加資料庫效能
>> - 由於餐點名稱、金額會變動，取得實際歷史資料才能得到真正的資料，但是效能會較慢
>> 

> # 點餐
>> 呼叫方法
>> - URL suffix `?cmd=make_self_order&dish_id[]={dish_id}&time={Year/Month/Date-Hour:Minute:Second}`
>> - 例如 `?cmd=make_self_order&dish_id[]=1&dish_id[]=1&time=2019/06/07-00:00:00`
>>>
>> 回傳
>> - 點餐資料的 `json` 物件
>>
>> 附註
>> - 取得剩下多少餐時，採用 `X` 鎖進行上鎖，確保資料庫一致性
>> - 遇到資料庫死結時，直接回傳 `database deadlock`
>> 
> # 取消點餐
>> 呼叫方法
>> - URL suffix `?cmd=delete_{self, everyone}&order_id={order_id}`
>>> - `self` 意思是指能刪除自己的點單
>>> - `everyone` 意思是能夠刪除任何人的點單
>> - 例如 `?cmd=delete_self&order_id=5487`
>>
>> 回傳
>> - 被刪除那個點單的 `json` 物件
>>
>> 附註
>> - 改變剩下多少餐時，採用 `X` 鎖進行上鎖，確保資料庫一致性
>> - 遇到資料庫死結時，直接回傳 `database deadlock`
>> - 資料庫並不會真的刪除那筆資料，而是在欄位中標記為 `deleted`
>> 

> # 付款
>> 呼叫方法
>> - URL suffix `?cmd=set_payment&password={password}&order_id={order_id}&target={true,false}`
>> - 例如 `?cmd=set_payment&password=5487&order_id=6969&target=true`
>>>
>> 回傳
>> - 被繳款點單的 `json` 陣列
>>
>> 附註
>> - `target = true` 代表標記為有付款 `target = false` 代表標記為尚未付款
>> - 改變付款狀態時，採用 `X` 鎖進行上鎖，確保資料庫一致性
>> - 遇到資料庫死結時，直接回傳 `database deadlock`

> # 請求 pos 資料
>> 呼叫方法
>> - URL suffix `?cmd=get_pos`
>> - 例如 `?cmd=get_pos`
>>>
>> 回傳
>> - 一個使用者 `json` 物件
>>
>> 附註
>> - 飛宇的系統如果出問題，回傳 `pos is dead`

> # 更新菜單
>> 呼叫方法
>> - URL suffix 
>>> - `?cmd=update_dish`
>>> - `?id={dish_id}`
>>> - `?dish_name={dish name}`
>>> - `?charge_sum={charge}`
>>> - `?is_vege={MEAT ,VEGE ,PURE}`
>>> - `?is_idle={true ,false}'`
>>> - `?daily_limit={廠商一天能供應多少量}`
>> - 例如 `?cmd=update_dish&id=1&dish_name=Fei Yu GGYY&charge_sum=87&is_vege=MEAT&is_idle=true&daily_limit=-1`
>>
>> 回傳
>> - `Successfully updated food.`
>>
>> 附註
>> -  `daily_limit` 設定為 `-1` 代表不限制
## 回傳格式
基本上所有的回傳 `json` 都是點單資料的子集，在此僅展現點單資料的資料格式

命名原則應該是非常清楚，僅對可能有疑惑的部分進行解釋
- `order_maker` 是痕跡功能，代表是誰代替使用者點餐的
- 登入時，`user` 會有額外的欄位，叫做 `valid_oper`，代表使用者可以對後台進行什麼操作
```json
{
   "id":"38930",
   "user":{  
      "id":"-1",
      "name":"-",
      "daily_limit":"",
      "vege":{  
         "number":"-1",
         "name":"unknown"
      },
      "class":{  
         "id":"-1",
         "year":"-1",
         "grade":"-1",
         "class_no":"-1"
      },
      "seat_no":"-1",
      "prev_sum":"0",
      "money":"",
      "card":""
   },
   "order_maker":{  
      "id":"-1",
      "name":"-",
      "daily_limit":"",
      "vege":{  
         "number":"-1",
         "name":"unknown"
      },
      "class":{  
         "id":"-1",
         "year":"-1",
         "grade":"-1",
         "class_no":"-1"
      },
      "seat_no":"-1",
      "prev_sum":"0",
      "money":"",
      "card":""
   },
   "dish":[  
      "1"
   ],
   "money":{  
      "id":"38930",
      "charge":"40",
      "payment":[  
         {  
            "id":"154769",
            "paid":"true",
            "able_dt":"2019-02-25 00:00:00",
            "paid_dt":"2019-02-25 09:29:04",
            "freeze_dt":"2019-02-25 10:30:00",
            "name":"payment",
            "reversable":"0"
         }
      ]
   },
   "recv_date":"2019-02-25 12:00:00"
}
```
# 設定檔
命名原則應該是非常清楚，僅對可能有疑惑的部分進行解釋
- `bank` 是連結 `pos` 系統的設定檔
- 在 `{login ,payment}.time` 的時間內，密碼驗證失敗了 `{login ,payment}.tolerance` 次，就會鎖定 `{login ,payment}.punish` 秒， `login` 與 `payment` 的失敗次數、懲罰時間分別計算
- `announce` 是因為飛宇的系統太容易掛掉了，所以每次系統掛掉聊天機器人會去聊天室提醒大家系統掛了
```php
[
    "bank" => [
        "ip" => "192.168.0.2",
        "port" => 8787,
        "password" => "Fei Yu GGYY"
    ],
    "database" => [
        "ip" => "localhost",
        "account" => "dinnersystem",
        "password" => "########",
        "name" => "dinnersys"
    ],
    "login" => [
        "time" => "60",
        "tolerance" => "3",
        "punish" => "60"
    ],
    "payment" => [
        "time" => "60",
        "tolerance" => "3",
        "punish" => "60"
    ],
    "announce" => [
        "url" => "www.google.com",
        "auth" => "##############" 
    ]
]
```

# 常見問題集
> 無法更新菜單
> - 檢查資料夾裡面有沒有錯誤訊息檔

> 系統無法連線
> - 確認 dns 解析正常
> - 確認有開啟 Nginx MySQL PHP

> 如果 App 一打開就 crash
> - 確認 u_move_u_dead 存在於 frontend
> - 確認 version.txt 存在於 u_move_u_dead

> 附註
> - pos 掛掉，午餐系統也很容易連累掛掉，跟其他伺服器溝通是很耗費效能的事情
> - 如果還有遇到什麼問題，請聯絡我，我會再把東西寫入問題集


-----------------------------------------------
編寫的文件不可能 100% 詳盡，有問題自己去翻原始碼找答案。

編寫於 2019/06 ，如有問題，請用 github 聯繫我。~~白翔云，別再靠北我不寫文件了~~
