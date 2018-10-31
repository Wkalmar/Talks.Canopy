module GithubProfileTests

open canopy.runner.classic
open canopy.classic

let all() =
    context "Github page tests"

    "Left bottom repostitory should be staionwalk.server" &&& fun _ ->
        url "https://github.com/Wkalmar"
        let repo = nth 4 GithubProfilePage.pinnedRepository
        let firstRepoCaption = repo |> someElementWithin GithubProfilePage.pinndedRepositoryContainer
        match firstRepoCaption with
        | Some caption -> read caption == "stationwalk.server"
        | None _ -> failwith "Element not found"

    "Right bottom repostitory should be staionwalk.client" &&& fun _ ->
        url "https://github.com/Wkalmar"
        let repo = nth 5 GithubProfilePage.pinnedRepository
        let firstRepoCaption = repo |> someElementWithin GithubProfilePage.pinndedRepositoryContainer
        match firstRepoCaption with
        | Some caption -> read caption == "stationwalk.client"
        | None _ -> failwith "Element not found"

    "Bio should contain twitter link" &&& fun _ ->
        url "https://github.com/Wkalmar"
        GithubProfilePage.bio == "https://twitter.com/BohdanStupak1"

