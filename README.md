# 交換介面格式
向後台發送這些請求，後台將會做出相對應的回應。
- 後台位置 https://dinnersystem.ddns.net/dinnersyste_beta/backend/backend.php


## 使用方法
> # 登入
>> 呼叫方法
>> - URL Suffix `?cmd=login&id={your_id}&password={your_password}&device_id={device_id}`
>> - 例如 `?cmd=login&id=06610089&password=910426&device_id=HELLO_FROM_ANDROID`
>> 
>> 回傳
>> - 一個使用者 `json` 資料
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
>> - Successfullwerqwerqwe qwe7r8qew7r89qw7 
> # 更改密碼
>> 呼叫方法
>> - URL Suffix `?cmd=change_password&old_pswd={old_password}&new_pswd={new_password}`
>> - 例如 `?cmd=change_password&old_pswd=5487580&new_pswd=5487580`
>> 
>> 回傳
>> - 211321231
>>
>> 附註
>> - 舊密碼打錯會被記載到 `error_log` 中，某隻帳號登入失敗太多次會被鎖
>> - 更改密碼後，並不會強制要求使用者跳出系統
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
>> - 例如 `?cmd=show_dish`
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
>> - URL suffix `?cmd=make_self_order`
>>> - 點什麼餐 `?dish_id[]={dish_id}`
>>> 
>>> - 什麼時候取餐 `?time={Year/Month/Date-Hour:Minute:Second}`
>>>
>> - 例如 `?cmd=show_dish`
>>>
>> 回傳
>> - ioreupiquwerpiquwepoi的 `json` 陣列
>>
>> 附註
>> - 取得剩下多少餐時，採用 `X` 鎖進行上鎖，確保資料庫一致性
>> - 遇到資料庫死結時，直接回傳 `database deadlock`
>> 
> # 取消點餐
>> 呼叫方法
>> - URL suffix `?cmd=make_self_order`
>>> - 點什麼餐 `?dish_id[]={dish_id}`
>>> 
>>> - 什麼時候取餐 `?time={Year/Month/Date-Hour:Minute:Second}`
>>>
>> - 例如 `?cmd=show_dish`
>>>
>> 回傳
>> - ioreupiquwerpiquwepoi的 `json` 陣列
>>
>> 附註
>> - 改變剩下多少餐時，採用 `X` 鎖進行上鎖，確保資料庫一致性
>> - 遇到資料庫死結時，直接回傳 `database deadlock`
>> 
> # 付款
>> 呼叫方法
>> - URL suffix `?cmd=make_self_order`
>>> - 點什麼餐 `?dish_id[]={dish_id}`
>>> 
>>> - 什麼時候取餐 `?time={Year/Month/Date-Hour:Minute:Second}`
>>>
>> - 例如 `?cmd=show_dish`
>>>
>> 回傳
>> - ioreupiquwerpiquwepoi的 `json` 陣列
>>
>> 附註
>> - 改變付款狀態時，採用 `X` 鎖進行上鎖，確保資料庫一致性
>> - 遇到資料庫死結時，直接回傳 `database deadlock`
>> - 飛宇的系統如果出問題，回傳 `qwerioquweoiruqwepor`
>> - 飛宇雞雞歪歪，他們的業務經理曾經說過 2^6 = 36，我懷疑他智商不足
> # 請求 pos 資料
>> 呼叫方法
>> - URL suffix `?cmd=get_pos`
>> - 例如 `?cmd=get_pos`
>>>
>> 回傳
>> - ioreupiquwerpiquwepoi的 `json` 陣列
>>
>> 附註
>> - 飛宇的系統如果出問題，回傳 `qwerioquweoiruqwepor`
>> - 飛宇雞雞歪歪，他們的餘額用浮點數存，我懷疑資料庫分析師智商不足
> # 更新菜單

## 回傳格式

# 設定檔

# 資料庫架構


# 常見問題集





編寫的文件不可能 100% 詳盡，有問題自己去翻原始碼找答案。

編寫於 2019/06 ，如有問題，請用 github 聯繫我。~~白翔云，別再靠北我不寫文件了~~
