open System

canopy.configuration.chromeDir <- "C:\\"

GithubProfileTests.all()

prunner.run 3 |> ignore

printfn "Press any key to exit..."
Console.ReadKey() |> ignore

