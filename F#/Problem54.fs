﻿module Problem54

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


open Microsoft.FSharp.Reflection
open Tools.General

type Suit = 
    | Diamond | Heart | Spade | Club
    static member ofString s = 
        match s with
            | 'S' -> Spade 
            | 'H' -> Heart 
            | 'D' -> Diamond 
            | 'C' -> Club 
            | _ -> invalidArg "suit" "suit not found"
    
    override s.ToString() =
        match s with
            | Spade -> "Spade"
            | Heart -> "Heart"
            | Diamond -> "Diamond"
            | Club -> "Club"

type Rank =
    | NumberedCard of int | Jack | Queen | King | Ace

    static member ofString s =
        match s with
        | '2' | '3' | '4' | '5' | '6' | '7' | '8' | '9' -> NumberedCard(int(s.ToString()))
        | 'T' -> NumberedCard(10) 
        | 'J' -> Jack 
        | 'Q' -> Queen 
        | 'K' -> King 
        | 'A' -> Ace 
        | _ -> invalidArg "value" "value not found"

    override s.ToString() =
        match s with
        | NumberedCard(n) -> string n
        | Jack -> "Jack"
        | Queen -> "Queen"
        | King -> "King"
        | Ace -> "Ace"

    static member next (value:Rank) =
        match value with
        | NumberedCard n -> if n < 10 then NumberedCard (n+1) else Jack
        | Jack -> Queen 
        | Queen -> King 
        | King -> Ace 
        | Ace -> NumberedCard(2)

type Score = 
    | HighCard of Rank 
    | Pair of Rank 
    | TwoPairs of Rank * Rank 
    | ThreeOfAKind of Rank 
    | Straight of Rank
    | Flush of Rank
    | FullHouse of Rank * Rank 
    | FourOfAKind of Rank 
    | StraightFlush of Rank

type Card = { Rank:Rank; Suit:Suit } with
            
    override this.ToString() = System.String.Format("{0} of {1}s", this.Rank, this.Suit)
            
    static member public ofString s =
        match s with
        |[|(rank:char);(suit:char)|] -> { Card.Rank = Rank.ofString rank; Suit = Suit.ofString suit }
        | _ -> invalidArg "s" "wtf"
            
end

type Hand() =

    static member public ofString(s: string) = 
        s.Split [|' '|] 
        |> Seq.map (fun s -> Card.ofString (s.ToCharArray()))
        |> List.ofSeq
    
    static member highestCard (cards : Card list) : Card = 
        cards |> List.maxBy (fun c -> c.Rank)

    static member isFlush(cards: seq<Card>) = 
        let head = Seq.head cards
        cards
            |> List.ofSeq
            |> List.tail
            |> List.forall (fun x -> x.Suit = head.Suit) 

    static member isStraight (cards:Card list) =
        List.zip (Seq.take 4 cards |> List.ofSeq) (List.tail cards)
        |> Seq.forall (fun (card1, card2) -> card2.Rank = Rank.next card1.Rank)

    static member couples (cards:Card list) =
        cards
        |> Seq.groupBy (fun card -> card.Rank)
        |> List.ofSeq
        |> List.map (fun (k, seq) -> (k, Seq.length seq))
        |> List.filter (fun (k, len) -> len > 1)
        |> List.sortBy (fun(k, len) -> len)

    static member public identify(cards: Card list): Score = 
        let hc = Hand.highestCard cards
        if Hand.isStraight cards && Hand.isFlush cards then StraightFlush hc.Rank
        else if Hand.isFlush cards then Flush hc.Rank
        else if Hand.isStraight cards then Straight hc.Rank
        else 
            match cards |> Hand.couples with
            | [(rank, 2)] -> Pair rank
            | [(rank, 3)] -> ThreeOfAKind rank
            | [(rank, 4)] -> FourOfAKind rank
            | [(rank1, 2); (rank2, 2)] -> TwoPairs(rank1, rank2)
            | [(rank1, 2); (rank2, 3)] -> FullHouse(rank1, rank2)
            | _ -> HighCard hc.Rank
            
    static member public isWin (hands: Card list * Card list): bool =
        
        let rec compareHighestCard (me: Card list) (other: Card list): bool =
            let mine, theirs = Hand.highestCard me, Hand.highestCard other
            if mine <> theirs then mine > theirs
            else 
                let me' = me |> List.filter(fun c -> c <> mine)
                let other' = other |> List.filter(fun c -> c <> theirs) 
                compareHighestCard  me' other'

        let mine, theirs = Hand.identify (fst hands), 
                           Hand.identify (snd hands)
                                      
        if mine <> theirs then
            mine > theirs
        else 
            compareHighestCard (fst hands) (snd hands)
  
let result = 

    let splitToHands (line: string): (Card list * Card list) = 
        line 
        |> Hand.ofString
        |> fun c -> (Seq.take 5 c |> Seq.sort |> List.ofSeq, 
                     Seq.skip 5 c |> Seq.sort |> List.ofSeq)

    readLines "poker.txt"
    |> Seq.map splitToHands
    |> Seq.filter Hand.isWin
    |> Seq.length

    