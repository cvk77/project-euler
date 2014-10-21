module MicroTest

type Result = Success | Fail of string

let shouldEqual expected actual : Result =
    if actual = expected then Success
    else Fail("Expected " + (string expected) + ", but was " + (string actual))