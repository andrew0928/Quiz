# Quiz: 交易處理的測驗題

這個 sample code, 用 ```MainAccount``` 這個類別，模擬銀行的帳戶。提供餘額查詢 ```GetBalance()```, 與轉入轉出 ```Transfer(long amount)``` 的功能。
衍生的類別 ```NetworkAccount``` 提供一模一樣的功能，唯一的差別是 ```Transfer()``` 有一定的機率 (5%) 會在執行的過程中擲出例外
```NetworkException```。

需要特別注意的是，```Transfer()``` 丟出例外狀況時，無法得知交易本身是否成功的執行。進行交易的一方，必須自行確認餘額。


## 測驗1 - 單一帳戶並行的正確性

程式會產生 10000 個執行緒，同時對同一個帳號進行 10000 次存款的交易 (每次存 1 元)。預期的結果應該是執行結束後帳號應該有 10000 x 10000 = 100000000 元。
若無法妥善處理並行的問題，則餘額會有落差。

請改寫 /Quiz.Accounts/MainAccount.cs 的 ```long Transfer(long value)```, 直到通過測試為止。

## 測驗2 - 網路轉帳交易的正確性

程式會隨機 (4 ~ -5) 在兩個帳戶之間進行轉帳。每次轉帳，會從第一個帳戶扣除 N 元，同時在第二個帳號存入 N 元。不斷在這兩個帳號之間隨機的轉帳 10000 次，
預期的結果是兩個帳號的總額應該跟程式一開始一樣 (1000 + 1000 = 2000)。

不過這個測驗要求用 ```NetworkAccount```, 因此在 ```GetBalance()``` 與 ```Transfer()``` 都伴隨著隨機發生 ```NetworkException``` 的潛在問題。請確保無論在甚麼狀態下，交易
都必須正確的執行完畢。若無法成功執行的話，則必須取消交易。不能發生第一個帳號被扣款，而第二個帳號卻沒有成功的儲值問題。

這個範例不需考慮併行交易，因此交易執行後可查詢餘額，來確認先前的交易是否正確。
請改寫 /Quiz.Accounts/AccountBase.cs 的 ```static bool ExecTransaction(params TransactionCmd[] transes)```, 直到通過測試為止。


# Quiz: 資料結構相關測驗題

## 測驗1 - 找出陣列中(list)是否存在兩個值的合等於指定數值(target)?

給定一個不限長度的整數陣列 (int[] list), 及一個指定的整數 (int target)。請寫程式檢查 list 之中是否
存在任兩筆的合等於 target ?

只要存在一組以上的組合，就傳回 true, 否則傳回 false。

請留意時間的複雜度。測試程式會確保每個測試案例都必須在 1ms 之內完成。實際測試用的 PC 會採取高規格，以 Intel i7
的設備來執行。



# 測驗方式

請勿修改整個 project 除了上述範圍之外的任何程式。
請勿對 test project 做任何修改。實際驗證時我們可能會用另一套 test project 來驗證您的 code

測試方式，會在具備 4 cores 的 windows PC (intel i7), 用 visual studio 2015 開啟專案，執行三次 unit test (Run All), 三次都全數通過 (綠燈) 算是測試完成。


# Quiz: 串流統計的測驗題

補上 Engine 的實作，讓 Engine 可以即時的統計過去 {Period} 時間內，所有透過 {Input()} 輸入的數值總和。Engine 每秒執行的 Input() 次數可能高達上百萬次，請用有效率的架構與演算法，設計這個 Engine。
計算的時間精確度，可以容許些許時間誤差為 {Interval}。

請在有限的 CPU 運算能力，有限的儲存空間，並且能長時間執行的要求下，設計這 Engine。