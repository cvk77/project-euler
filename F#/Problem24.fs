module Problem24

// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation 
// of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, 
// we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
// 
// 012   021   102   120   201   210
// 
// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
// 
// Answer: 2783915460

let distrib e L =
    let rec aux pre post = 
        seq {
            match post with
            | [] -> yield (L @ [e])
            | h::t -> yield (List.rev pre @ [e] @ post)
                      yield! aux (h::pre) t 
        }
    aux [] L

let rec perms = function 
    | [] -> Seq.singleton []
    | h::t -> Seq.collect (distrib h) (perms t)

let result = perms [0..9] |> Seq.sort |> Seq.nth 1000000

