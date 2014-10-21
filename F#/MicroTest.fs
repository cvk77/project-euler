module MicroTest

type Result = Success of string | Fail of string

let shouldEqual expected actual : Result =
    if actual = expected then Success(string actual)
    else Fail("Expected " + (string expected) + ", but was " + (string actual))