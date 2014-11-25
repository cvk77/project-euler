module Problem54

// In the card game poker, a hand consists of five cards and are ranked, from lowest to highest, in the following way:
// 
//     High Card: Highest value card.
//     One Pair: Two cards of the same value.
//     Two Pairs: Two different pairs.
//     Three of a Kind: Three cards of the same value.
//     Straight: All cards are consecutive values.
//     Flush: All cards of the same suit.
//     Full House: Three of a kind and a pair.
//     Four of a Kind: Four cards of the same value.
//     Straight Flush: All cards are consecutive values of same suit.
//     Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.
// 
// The cards are valued in the order:
// 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace.
// 
// If two players have the same ranked hands then the rank made up of the highest value wins; for example, 
// a pair of eights beats a pair of fives (see example 1 below). But if two ranks tie, for example, both 
// players have a pair of queens, then highest cards in each hand are compared (see example 4 below); 
// if the highest cards tie then the next highest cards are compared, and so on.
// 
// The file, poker.txt, contains one-thousand random hands dealt to two players. Each line of the file 
// contains ten cards (separated by a single space): the first five are Player 1's cards and the last five 
// are Player 2's cards. You can assume that all hands are valid (no invalid characters or repeated cards), 
// each player's hand is in no specific order, and in each hand there is a clear winner.
// 
// How many hands does Player 1 win?
// 
// Answer: 376

open Tools.General

type Suit = 
    | Diamond | Heart | Spade | Club
    static member ofString s = match s with | 'S' -> Spade | 'H' -> Heart | 'D' -> Diamond | 'C' -> Club 
    
type Rank =
    | NumberedCard of int | Jack | Queen | King | Ace

    static member ofString s = match s with | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> NumberedCard(int(s.ToString()))
                                            | 'T' -> NumberedCard(10) 
                                            | 'J' -> Jack | 'Q' -> Queen | 'K' -> King  | 'A' -> Ace 

    static member next (value:Rank) = match value with | NumberedCard n -> if n < 10 then NumberedCard (n+1) else Jack
                                                       | Jack -> Queen | Queen -> King | King -> Ace | Ace -> NumberedCard(2)

type Score = 
    | HighCard of Rank | Pair of Rank | TwoPairs of Rank * Rank | ThreeOfAKind of Rank | Straight of Rank | Flush of Rank 
    | FullHouse of Rank * Rank | FourOfAKind of Rank | StraightFlush of Rank

type Card = { Rank:Rank; Suit:Suit } with
    static member public ofString s =
        match s with
            | [|(rank:char);(suit:char)|] -> { Card.Rank = Rank.ofString rank; Suit = Suit.ofString suit }

module Hand =

    let ofString(s: string) = 
        s.Split [|' '|] 
            |> Seq.map (fun s -> Card.ofString (s.ToCharArray()))
            |> Seq.sort
    
    let highestCard cards
        = Seq.maxBy (fun c -> c.Rank) cards

    let isFlush cards = 
        let head = Seq.head cards
        cards
            |> Seq.skip 1
            |> Seq.forall (fun x -> x.Suit = head.Suit) 

    let isStraight cards =
        Seq.zip (Seq.take 4 cards) (Seq.skip 1 cards)
            |> Seq.forall (fun (card1, card2) -> card2.Rank = Rank.next card1.Rank)

    let couples cards = 
        cards 
            |> Seq.groupBy (fun card -> card.Rank)
            |> Seq.map (fun (k, seq) -> (k, Seq.length seq))
            |> Seq.filter (fun (k, len) -> len > 1)
            |> Seq.sortBy (fun(k, len) -> len)

    let identify cards = 
        let hc = highestCard cards
        
        if isStraight cards && isFlush cards 
            then StraightFlush hc.Rank
        else if isFlush cards 
            then Flush hc.Rank
        else if isStraight cards 
            then Straight hc.Rank
        else 
            match cards |> couples |> List.ofSeq with
                | [(rank, 2)] -> Pair rank
                | [(rank, 3)] -> ThreeOfAKind rank
                | [(rank, 4)] -> FourOfAKind rank
                | [(rank1, 2); (rank2, 2)] -> TwoPairs(rank1, rank2)
                | [(rank1, 2); (rank2, 3)] -> FullHouse(rank1, rank2)
                | _ -> HighCard hc.Rank
                
    let isWin hand1 hand2 =
        let rev = List.ofSeq >> List.rev

        let mine, theirs = identify hand1, 
                           identify hand2

        if mine <> theirs then
            mine > theirs
        else 
            (rev hand1, rev hand2) 
                ||> Seq.compareWith (fun p1 p2 -> compare p1.Rank p2.Rank) > 0
    
let result = 

    let splitAndApply f (str: string) = 
        let pos = String.length str / 2
        f (str.[0..pos-1].Trim()), f (str.[pos..].Trim())
            
    readLines "poker.txt"
        |> Seq.map (splitAndApply Hand.ofString)
        |> Seq.filter (!> Hand.isWin)
        |> Seq.length
    