open System

type codeColor = Red | Green | Yellow | Purple | White | Black
type code = codeColor list
type answer = int * int
type board = (code * answer) list
type player = Human | Computer

let stringToColor n =
  match n with
  | "Red" -> Red
  | "Green" -> Green
  | "Yellow" -> Yellow
  | "Purple" -> Purple
  | "White" -> White
  | "Black" -> Black
  | _ -> failwith "invalid color request try with:\nRed | Green | Yellow | Purple | White | Black"

let stringToPlayer n =
 match n with
 | "Human" -> Human
 | "Computer" -> Computer
 | _ -> failwith "invalid player request try with: \nHuman | Computer"

let (codeColorList : code) =[Red; Green; Yellow; Purple; White; Black]
let mutable makeListe = []
let makeCode player =
  match player with
  | Human -> Console.WriteLine "Request first color - Should be one of the following: \nRed | Green | Yellow | Purple | White | Black"
             let frst = stringToColor (Console.ReadLine())
             Console.WriteLine "Request second color"
             let scnd = stringToColor (Console.ReadLine())
             Console.WriteLine "Request third color"
             let thrd = stringToColor (Console.ReadLine())
             Console.WriteLine "Request fourth color"
             let frth = stringToColor (Console.ReadLine())
             makeListe <- frst :: scnd :: thrd :: frth :: []
  | Computer -> Console.WriteLine "Computer has decided upon a combination"
                let mutable nmbr = 0
                let rnd = System.Random()
                for i=1 to 4 do
                  let nmbr = rnd.Next(0, 5)
                  makeListe <- codeColorList.[nmbr] :: makeListe
  (*| _ -> failwith "Invalid player"*)
printfn "Who wants to make the codecombination?\nHuman | Computer"
let (makePlayer : player) = stringToPlayer (Console.ReadLine())
makeCode makePlayer
printfn "%A" makeListe

let mutable guessListe = []
let guessCode player =
  match player with
  | Human -> Console.WriteLine "Request first color - Should be one of the following: \nRed | Green | Yellow | Purple | White | Black"
             let frst = stringToColor (Console.ReadLine())
             Console.WriteLine "Request second color"
             let scnd = stringToColor (Console.ReadLine())
             Console.WriteLine "Request third color"
             let thrd = stringToColor (Console.ReadLine())
             Console.WriteLine "Request fourth color"
             let frth = stringToColor (Console.ReadLine())
             guessListe <- frst :: scnd :: thrd :: frth :: []
  | Computer -> Console.WriteLine "Computer has decided upon a random guess combination"
                let mutable nmbr = 0
                let rnd = System.Random()
                for i=1 to 4 do
                  let nmbr = rnd.Next(0, 5)
                  guessListe <- codeColorList.[nmbr] :: guessListe
  (*| _ -> failwith "Invalid player"*)
printfn "Who wants to guess the codecombination?\nHuman | Computer"
let (guessPlayer : player) = stringToPlayer (Console.ReadLine())
guessCode guessPlayer
printfn "%A" guessListe



let validateCode (tryCode : code) (trueCode : code) =
  let mutable (hvid: int) = 0
  for i = 0 to (tryCode.Length - 1) do
    if List.contains tryCode.[i] trueCode then
        hvid <- hvid + 1
  printfn "temphvid %A" hvid
  let mutable (sort: int) = 0
  if hvid > 0 then
      for i = 0 to (tryCode.Length - 1) do
          if tryCode.[i] = trueCode.[i] then
              hvid <- hvid - 1
              sort <- sort + 1
  printfn "Hvid : %A \nSort : %A" hvid sort

validateCode guessListe makeListe
 





