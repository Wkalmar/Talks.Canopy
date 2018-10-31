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

GithubProfileTests.all()

run()

printfn "Press any key to exit..."
Console.ReadKey() |> ignore

quit()