open canopy.configuration
open canopy.runner.classic
open System
open OpenQA.Selenium
open canopy.classic

let maximizeBrowser (browser : IWebDriver) =
  browser.Manage().Window.Maximize()

chromeDir <- "C:\\"
start chrome

maximizeBrowser browser

"Left bottom repostitory should be staionwalk.server" &&& fun _ ->
    url "https://github.com/Wkalmar"
    let repo = nth 4 ".pinned-repo-item"
    let firstRepoCaption = repo |> someElementWithin ".js-repo"
    match firstRepoCaption with
    | Some caption -> read caption == "stationwalk.server"
    | None _ -> failwith "Element not found"

"Left bottom repostitory should be staionwalk.client" &&& fun _ ->
    url "https://github.com/Wkalmar"
    let repo = nth 5 ".pinned-repo-item"
    let firstRepoCaption = repo |> someElementWithin ".js-repo"
    match firstRepoCaption with
    | Some caption -> read caption == "stationwalk.client"
    | None _ -> failwith "Element not found"

"Bio should contain twitter link" &&& fun _ ->
    url "https://github.com/Wkalmar"
    ".user-profile-bio" == "https://twitter.com/BohdanStupak1"

run()

printfn "Press any key to exit..."
Console.ReadKey() |> ignore

quit()