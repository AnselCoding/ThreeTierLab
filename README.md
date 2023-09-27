# ThreeTierLab
分層架構模式，是將一個軟體系統進行分層，通過層來隔離不同的關注點，其中最為經典的就是三層架構。小型的專案可以使用分資料夾的方式，較大型的專案就能用類別庫的方式。
## 此專案的三層式架構建立
### Web API+EF Core+Three-Tier + TinyMapper
- 主要流程是：
    - 切出分層
    - 開介面和用到的 DTO
    - 用實作銜接各層
    - 測試
- 規劃細項操作
    1. 建立專案(Controll 層，MVC, API…)
    2. 建立 Service 層、Repository 層、Common 層(類別庫)
    3. 加入參考
        1. Controller (API or APP) : Service + Common
        2. Service : Repository + Common
        3. Repository : Common
        4. 建置完成後可以在解決方案選單中的”專案相依性”確認。
    4. 開各層要用到的介面和 DTO
        1. 在 Repository 層建立 DbContext，在專案加到 DI 容器，讓後續能在各層進行注入(主要是Repository 層要使用，其他層不應該使用)。
        2. 此專案想讓 Service 層與 Repository 層共用 table 的 DTO，將其移至 Common 層。
        3. 建立 Controller 層需求的 DTO。
        4. 建立 Service 層與 Repository 層的 Interface。
    5. 實作 Repository 層
        1. 建立 Implement。
        2. 將 Repository 層建立的服務，在專案加到 DI 容器，讓 Service 層能夠注入使用。
    6. 實作 Service 層
        1. 建立  Implement。
        2. 將 Service 層建立的服務，在專案加到 DI 容器，讓 Controller 層能夠注入使用。
    7. 實作 Controller 層
        1. 使用 TinyMapper 作 DTO 的轉換。
    8. 進行整合測試，呼叫 Controller 試試看是否成功取得資料。

* 如果是一個非常大型的專案，將每層都實際清楚分割，大致會是如下的設計
  ![2023-09-24 3-Tier](https://github.com/AnselCoding/ThreeTierLab/assets/77433280/e41be543-0bf5-4c6e-b2af-4681ce83480f)
