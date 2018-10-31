module GithubProfileTests

open OpenQA.Selenium
open canopy.parallell.functions
open canopy.types
open prunner


let maximizeBrowser (browser : IWebDriver) =
  browser.Manage().Window.Maximize()

let all() =
    "Left bottom repostitory should be staionwalk.server" &&& fun _ ->
        let browser = start Chrome
        maximizeBrowser browser
        url "https://github.com/Wkalmar" browser
        let repo = nth 4 GithubProfilePage.pinnedRepository browser
        let firstRepoCaption = someElementWithin GithubProfilePage.pinndedRepositoryContainer repo browser
        match firstRepoCaption with
        | Some caption -> equals (read caption browser) "stationwalk.server" browser
        | None _ -> failwith "Element not found"

    "Right bottom repostitory should be staionwalk.client" &&& fun _ ->
        let browser = start Chrome
        maximizeBrowser browser
        url "https://github.com/Wkalmar" browser
        let repo = nth 5 GithubProfilePage.pinnedRepository browser
        let firstRepoCaption = someElementWithin GithubProfilePage.pinndedRepositoryContainer repo browser
        match firstRepoCaption with
        | Some caption -> equals (read caption browser) "stationwalk.client" browser
        | None _ -> failwith "Element not found"

    "Bio should contain twitter link" &&& fun _ ->
        let browser = start Chrome
        maximizeBrowser browser
        url "https://github.com/Wkalmar" browser
        equals GithubProfilePage.bio "https://twitter.com/BohdanStupak1" browser
